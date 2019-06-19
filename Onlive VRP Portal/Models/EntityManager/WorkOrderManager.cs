using Onlive_VRP_Portal.Models.DB;
using Onlive_VRP_Portal.Models.ViewModel;
using System;
using System.Configuration;
using System.Linq;

namespace Onlive_VRP_Portal.Models.EntityManager
{
    public class WorkOrderManager
    {
        public WorkOrderView GetWorkOrderData(string account)
        {
            using (Entities db = new Entities())
            {
                WorkOrderView WOV = new WorkOrderView();

                var workOrders = db.dWorkOrder.Where(o => o.cAccount.Equals(account) && o.lCompleted == false);
                foreach (var workOrder in workOrders)
                {
                    WorkOrderDataView dataView = new WorkOrderDataView();
                    dataView.WorkOrderID = workOrder.cWorkorder;
                    dataView.Description = workOrder.cService_description;
                    dataView.ScheduleDate = workOrder.dSchd_dt;
                    dataView.ScheduleTime = workOrder.cSchd_time;
                    dataView.SiteAddress = workOrder.cSite_address;
                    dataView.SiteName = workOrder.cSite_name;
                    dataView.Level = workOrder.cLevel.PadLeft(2);

                    WOV.WDV.Add(dataView);
                }

                WOV.types.Add(new WorkOrderType
                {
                    typeDisplay = "Dump and Return",
                    type = "DPR"
                });

                WOV.types.Add(new WorkOrderType
                {
                    typeDisplay = "Pull and Return",
                    type = "P&R"
                });

                return WOV;
            }
        }

        public void CreateNewWorkOrder(string WOType, DateTime WODate, string account)
        {
            using (Entities db = new Entities())
            {
                CustomerManager CM = new CustomerManager();
                CustomerDataView CDV = CM.GetCustomerData(account);
                WorkOrderSetupManager WSM = new WorkOrderSetupManager();
                WorkOrderSetupView WSV = WSM.GetWorkOrderView(WOType);
                dWorkOrder WO = new dWorkOrder();
                WO.lSelected = false;
                WO.cSelected_user = "";
                WO.cAccount = account.PadLeft(10);
                WO.cSite_address = CDV.BillingAddress;
                WO.dSchd_dt = WODate;
                WO.cSchd_time = DateTime.Now.ToString("h:mm:ss");
                WO.cWorkorder = "WO" + db.VrpGetNextID("WO", "DWORKORDER>DBF", 1).First().ToString();
                WO.cWorkorder_Type = WSV.WOType;
                WO.cLevel = "1";
                WO.cDepartment_ID = WSV.Department;
                WO.cService_description = WSV.WODescription;
                WO.cContract_ID = "";
                WO.cPurchase_order = "";
                WO.cInvoice = "";
                WO.cUser_cod = "";
                WO.lPrinted = false;
                WO.lRequired_check_passed = false;
                WO.lCompleted = false;
                WO.cAcct_Route_ID = "";
                WO.cRoute_ID = "";
                WO.cTransporter_ID = "";
                WO.cVehicle_ID = "";
                WO.nOdom_in = 0;
                WO.nOdom_out = 0;
                WO.cReceiver_ID = "";
                WO.cDocket_ID = "";
                WO.nVolume = 0;
                WO.cUnit_Of_Measure_ID = "";
                WO.nLf_cost = 0;
                WO.dCritical_date = DateTime.Now;
                WO.cCritical_start_time = "";
                WO.cCritical_end_time = "";
                WO.nCritical_duration = 0;
                WO.nTotal_cost = 0;
                WO.nTotal_revenue = 0;
                WO.nProfit = 0;
                WO.lBatch_created = false;
                WO.nSequence = 0;
                WO.cCroute_fk = "";
                WO.tTime_stamp = DateTime.Now;
                WO.cCanceled_Level = "";
                WO.cWO_User_Character_1 = "";
                WO.cWO_User_Character_2 = "";
                WO.cWO_User_Character_3 = "";
                WO.lWO_User_Checkbox_1 = false;
                WO.lWO_User_Checkbox_2 = false;
                WO.lWO_User_Checkbox_3 = false;

                db.dWorkOrder.Add(WO);
                db.SaveChanges();
            }
        }
    }
}