using Onlive_VRP_Portal.Models.DB;
using Onlive_VRP_Portal.Models.EntityManager;
using Onlive_VRP_Portal.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

public class CommentManager
{
    public void NewCustomerComment(NewCustomerView NewCustomer)
    {
        using (Entities db = new Entities())
        {
            dComment NCV = new dComment();
            NCV.cId = ("CU" + db.VrpGetNextID("CO", "DCOMMENT.DBF", 1).First().ToString()).PadLeft(14);
            NCV.cAccount = NewCustomer.Account;
            NCV.dDate = DateTime.Now;
            NCV.dThru = Convert.ToDateTime("1900-01-01");
            NCV.mComment = "New customer created from on-line portal.\r\n" +
                "Please confirm the information entered and finish the customer with the following information:\r\n" +
                "Billing Address: " + NewCustomer.BillingAddressNumber + " " + NewCustomer.BillingStreet + " " + NewCustomer.BillingSuf + " " + NewCustomer.BillingCity + " " + NewCustomer.BillingState + " " + NewCustomer.BillingZip + "\r\n" +
                "Site Address: " + NewCustomer.StreetNum + " " + " " + NewCustomer.StreetName + " " + NewCustomer.StreetSuf + " " + NewCustomer.SiteCity + " " + NewCustomer.SiteState + " " + NewCustomer.SiteZip + "\r\n";
            NCV.nThru_date_interval = 0;
            NCV.cInverse_julian = "7549702";
            NCV.lActive = true;
            NCV.lPin_note = true;
            NCV.lRoute = false;
            NCV.lStatement = false;
            NCV.cOld_day = "";
            NCV.nOld_route = 0;
            NCV.tTime_stamp = DateTime.Now;
            NCV.cType_ID = "P";

            db.dComment.Add(NCV);
            db.SaveChanges();
        }
    }

    public void NewCustomerRoutingComment(string nearCustomerAccount, NewCustomerView NewCustomer)
    {
        using (Entities db = new Entities())
        {
            RouteManager RM = new RouteManager();
            List<string> routes = RM.GetRoutes(nearCustomerAccount);
            dComment NCV = new dComment();
            NCV.cId = ("CU" + db.VrpGetNextID("CO", "DCOMMENT.DBF", 1).First().ToString()).PadLeft(14);
            NCV.cAccount = NewCustomer.Account;
            NCV.dDate = DateTime.Now;
            NCV.dThru = DateTime.Now.AddDays(30);
            NCV.mComment = "We found a customer on the same street as this customer. Account: " + nearCustomerAccount +
                "\r\nThis customer has the following routes:";
            foreach (string route in routes)
            {
                NCV.mComment = NCV.mComment + "\r\n" + route;
            }
            NCV.nThru_date_interval = 0;
            NCV.cInverse_julian = "7549702";
            NCV.lActive = true;
            NCV.lPin_note = true;
            NCV.lRoute = false;
            NCV.lStatement = false;
            NCV.cOld_day = "";
            NCV.nOld_route = 0;
            NCV.tTime_stamp = DateTime.Now;
            NCV.cType_ID = "P";

            db.dComment.Add(NCV);
            db.SaveChanges();
        }
    }
}