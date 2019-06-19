using Onlive_VRP_Portal.Models.DB;
using Onlive_VRP_Portal.Models.ViewModel;
using System.Configuration;
using System.Linq;

namespace Onlive_VRP_Portal.Models.EntityManager
{
    public class WorkOrderSetupManager
    {
        public WorkOrderSetupView GetWorkOrderView(string WOType)
        {
            using (Entities db = new Entities())
            {
                WorkOrderSetupView WSV = new WorkOrderSetupView();
                var WorkOrderSetup = db.dWorkorder_Setup.Where(o => o.cWorkorder_Type.Equals(WOType) && o.cLevel.Equals("1"));
                WSV.WOType = WorkOrderSetup.First().cWorkorder_Type;
                WSV.WODescription = WorkOrderSetup.First().cService_description;
                WSV.Department = WorkOrderSetup.First().cDepartment_ID;

                return WSV;
            }
        }
    }
}