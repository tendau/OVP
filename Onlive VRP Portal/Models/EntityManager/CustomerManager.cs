using Onlive_VRP_Portal.Models.DB;
using Onlive_VRP_Portal.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Onlive_VRP_Portal.Models.EntityManager
{
    public class CustomerManager
    {
        public CustomerDataView GetCustomerData(string account)
        {
            using (Entities db = new Entities())
            {
                CustomerDataView CDV = new CustomerDataView();
                var customer = db.dCustomer.Where(o => o.cAccount.Equals(account));
                if (customer.Any())
                {
                    CDV.Account = customer.First().cAccount;
                    CDV.BillingName = customer.First().cName;
                    CDV.BillingAddress = customer.First().cAddress_1;
                    CDV.BillingCity = customer.First().cCity;
                    CDV.BillingState = customer.First().cState;
                    CDV.BillingZip = customer.First().cZip;
                    CDV.BillingPhone = customer.First().cPhone;
                    CDV.BillingEmail = customer.First().cE_mail;
                    CDV.Balance = customer.First().nBalance;

                    CDV.SiteName = customer.First().cSite_name;
                    CDV.SiteAddress = customer.First().cSite_address;
                    CDV.SiteCity = customer.First().cSite_city;
                    CDV.SiteState = customer.First().cSite_state;
                    CDV.SiteZip = customer.First().cSite_zip;
                    CDV.SitePhone = customer.First().cSite_phone;
                    CDV.SiteEmail = customer.First().cSite_e_mail;
                }
                return CDV;
            }
        }

        public void UpdateCustomer(EditCustomerview ECV, string account)
        {
            using (Entities db = new Entities())
            {
                var customer = db.dCustomer.Where(o => o.cAccount.Equals(account));
                if (customer.Any())
                {
                    customer.First().cName = ECV.BillingName.Trim();
                    customer.First().cPhone = ECV.Billingphone.Trim();
                    customer.First().cE_mail = ECV.BillingEmail.Trim();
                    customer.First().cSite_name = ECV.SiteName.Trim();
                    customer.First().cSite_phone = ECV.SitePhone.Trim();
                    customer.First().cSite_e_mail = ECV.SiteEmail.Trim();

                    db.SaveChanges();
                }
            }

            TrayManager TM = new TrayManager();
        }

        //When a customer wants to pause their service we take i a date to stop service, a date to restart service, and an account number.
        //We then set the customers stop date, restart date, and status accordingly.
        //Finally we send a tray item to the CSR to have them check that everything worked correctly.
        public void PauseService(DateTime restartDate, string account)
        {
            using (Entities db = new Entities())
            {
                var customer = db.dCustomer.Where(o => o.cAccount.Equals(account));
                if (customer.Any())
                {
                    TrayManager TM = new TrayManager();

                    customer.First().cStatus_ID = "VAC";
                    customer.First().dStop = DateTime.Today.Date;
                    customer.First().dRestart = restartDate.Date;
                    db.SaveChanges();

                    TM.CreateTrayItem(account, "OVP - Service Pause Request", "A customer has requested to pause their service until " + restartDate.Date.ToString() + ". Please confirm that the customer has been paused successfully");
                }
            }
        }

        //Method to stop service that takes in the account number, the service ID(s) to stop and a restart date if applicapble
        public void StopService(string account, List<string> ids, DateTime RestartDate)
        {
            using (Entities db = new Entities())
            {
                var customer = db.dCustomer.Where(o => o.cAccount.Equals(account));
                if (customer.Any())
                {
                    TrayManager TM = new TrayManager();

                    customer.First().cStatus_ID = "CAN";
                    customer.First().dStop = DateTime.Today.Date;
                    db.SaveChanges();

                    TM.CreateTrayItem(account, "OVP - Service Canceled", "A customer has canceled their service via the online portal. Please confirm that the customer has been canceled successfully");
                }
            }
        }

        public void ReportNewAddress(string billAddress, string billState, string billCity, string billZip, string siteAddress, string siteCity, string siteState, string siteZip, string account)
        {
            TrayManager TM = new TrayManager();

            string message = "A customer has requested a change of address. Please review the following information and update the customer.\r\n" +
                "Billing Address: " + billAddress + "\r\n" +
                "Billing State: " + billState + "\r\n" +
                "Billing City: " + billCity + "\r\n" +
                "Billing Zip: " + billZip + "\r\n" +
                "Site Address: " + siteAddress + "\r\n" +
                "Site State: " + siteState + "\r\n" +
                "Site City: " + siteCity + "\r\n" +
                "Site Zip: " + siteZip;

            TM.CreateTrayItem(account, "Request for change of address", message);
        }

        /**
         * Site and billing address info goes into comment on customer for CSR to fill in.
         * Use Google to get geocode of Service and put it in geocode field
         * Set as sales type template
         **/

        public void CreateNewCustomer(NewCustomerView NCV)
        {
            using (Entities db = new Entities())
            {
                dCustomer Customer = new dCustomer();
                dCustomer template = db.dCustomer.Where(o => o.cAccount.Equals("         1")).First();
                CommentManager CM = new CommentManager();

                Customer.cAccount = db.VrpGetNextID("CU", "DCUSTOMER.DBF", 1).First().ToString().PadLeft(10);
                NCV.Account = Customer.cAccount;
                Customer.cName = NCV.BillingFirstName + " " + NCV.BillingLastName;
                Customer.cName_2 = "";
                Customer.cPhone = "";
                Customer.cAddress_1 = NCV.BillingAddressNumber + " " + NCV.BillingStreet + " " + NCV.BillingSuf;
                Customer.cCity = NCV.BillingCity;
                Customer.cState = NCV.BillingState.PadLeft(3);
                Customer.cZip = NCV.BillingZip;
                Customer.cPhone = NCV.Billingphone;
                Customer.cE_mail = "";
                Customer.cSite_address = NCV.StreetNum + " " + NCV.StreetName + " " + NCV.StreetSuf;
                Customer.cSite_name = NCV.SiteFirstName + " " + NCV.SiteLastName;
                Customer.cSite_street_number = NCV.StreetNum;
                Customer.cSite_street_name = NCV.StreetName;
                Customer.cSite_street_suffix = NCV.StreetSuf;
                Customer.cSite_city = NCV.SiteCity;
                Customer.cSite_state = NCV.SiteState.PadLeft(3);
                Customer.cSite_zip = NCV.SiteZip;
                Customer.cSite_phone = NCV.Sitephone;
                Customer.cSite_e_mail = NCV.USV.Email;
                Customer.cType_ID = template.cType_ID;
                Customer.cArea_ID = template.cArea_ID;
                Customer.cCycle_ID = template.cCycle_ID;
                Customer.cStatus_ID = template.cStatus_ID;
                Customer.cSite_ID = template.cSite_ID;
                Customer.cIndex_type = template.cIndex_type;
                Customer.cAddress_2 = template.cAddress_2;
                Customer.cBank_acct = template.cBank_acct;
                Customer.cBank_drawr = template.cBank_drawr;
                Customer.cBank_ID = template.cBank_ID;
                Customer.cBill_account = template.cBill_account;
                Customer.cCarrier_rt = template.cCarrier_rt;
                Customer.cCell_Phone = template.cCell_Phone;
                Customer.cChanges = template.cChanges;
                Customer.cContact = template.cContact;
                Customer.cCurrent_invoice = template.cCurrent_invoice;
                Customer.cFax = template.cFax;
                Customer.cGroup_ID = template.cGroup_ID;
                Customer.cNew_status_ID = template.cNew_status_ID;
                Customer.cSystem_ID = template.cSystem_ID;
                Customer.cTax_Table_ID = template.cTax_Table_ID;
                Customer.cUser_1 = "";
                Customer.cUser_2 = "";
                Customer.cUser_3 = "";
                Customer.cUser_4 = "";
                Customer.cUser_5 = "";
                Customer.cUser_num = template.cUser_num;
                Customer.cZip_barcode = template.cZip_barcode;
                Customer.dDate_paid = template.dDate_paid;
                Customer.dDepos_date = template.dDepos_date;
                Customer.dLast_late_charge_date = template.dLast_late_charge_date;
                Customer.dLast_notice_date = template.dLast_notice_date;
                Customer.dLast_servc = template.dLast_servc;
                Customer.dNew_status_date = DateTime.Now;
                Customer.dPo_expires = template.dPo_expires;
                Customer.dProrate_date = Customer.dProrate_date;
                Customer.cProrate_type = template.cProrate_type;
                Customer.dRestart = template.dRestart;
                Customer.dReview = template.dReview;
                Customer.dStart = template.dStart;
                Customer.dStop = template.dStop;
                Customer.dSuspend = template.dSuspend;
                Customer.dZip_date = template.dZip_date;
                Customer.lBank_eft = false;
                Customer.lContract_required = false;
                Customer.lEmail_Only_Statement = false;
                Customer.lEmail_Statement = false;
                Customer.lMaster_billing = false;
                Customer.lRequires_financial_approval = false;
                Customer.lRequires_operations_approval = false;
                Customer.nBalance = 0;
                Customer.nCharges = 0;
                Customer.nComments = 0;
                Customer.nComputd_on = 0;
                Customer.nContainers = 0;
                Customer.nContracts = 0;
                Customer.nCr_limit = 0;
                Customer.nCurrent = 0;
                Customer.nDeposit = 0;
                Customer.nInvoices = 0;
                Customer.nLast_l_chg = 0;
                Customer.nLast_notic = 0;
                Customer.nLast_paid = 0;
                Customer.nLate_charg = 0;
                Customer.nNinety = 0;
                Customer.nOne_twenty = 0;
                Customer.nRoutes = 0;
                Customer.nServicelinks = 0;
                Customer.nSixty = 0;
                Customer.nThirty = 0;
                Customer.nUnbilled = 0;
                Customer.nWorkorders = 0;
                Customer.tTime_stamp = DateTime.Now;

                //var locationService = new GoogleLocationService();
                //var point = locationService.GetLatLongFromAddress(NCV.SiteAddress + ", " + NCV.SiteCity + ", " + NCV.SiteState + ", " + NCV.SiteZip);
                //Customer.cLatitude = point.Latitude.ToString();
                //Customer.cLongitude = point.Longitude.ToString();

                db.dCustomer.Add(Customer);
                db.SaveChanges();

                //Create customer comments to help CSR finish customer information
                //Find customer near new customer to suggest for routing
                if (db.dCustomer.Where(o => o.cSite_street_name.Equals(NCV.StreetName, StringComparison.OrdinalIgnoreCase) && o.cAccount != NCV.Account).Count() > 0)
                {
                    dCustomer nearCustomer = db.dCustomer.Where(o => o.cSite_street_name.Equals(NCV.StreetName, StringComparison.OrdinalIgnoreCase) && o.cAccount != NCV.Account).First();
                    CM.NewCustomerRoutingComment(nearCustomer.cAccount, NCV);
                }

                CM.NewCustomerComment(NCV);
            }
        }
    }
}