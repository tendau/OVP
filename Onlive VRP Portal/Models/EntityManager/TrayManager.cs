using Onlive_VRP_Portal.Models.DB;
using System;
using System.Linq;
using System.Web.Configuration;

namespace Onlive_VRP_Portal.Models.EntityManager
{
    public class TrayManager
    {
        public void CreateTrayItem(string account, string subject, string message)
        {
            using (Entities db = new Entities())
            {
                UserManager UM = new UserManager();
                dTray trayItem = new dTray();
                trayItem.cID = "TY" + db.VrpGetNextID("TY", "DTRAY.DBF", 1).FirstOrDefault().ToString();
                trayItem.cAccount = account.PadLeft(10);
                trayItem.dCreate_date = DateTime.Now;
                trayItem.cCreate_time = DateTime.Now.ToString("hh:mm:ss");
                trayItem.cSource_ID = account.PadLeft(10);
                trayItem.cSubject = subject;
                trayItem.cTo_Tray_ID = WebConfigurationManager.AppSettings["SendToTray"];
                trayItem.cTray_ID = WebConfigurationManager.AppSettings["SendToTray"];
                trayItem.cSend_Tray_ID = WebConfigurationManager.AppSettings["SendToTray"];
                trayItem.lSend = false;
                trayItem.lAuto_show = false;
                trayItem.mComment = message;
                trayItem.tTime_stamp = DateTime.Now;
                trayItem.lPriority = false;
                trayItem.lComplete = false;
                trayItem.cSend_time = DateTime.Now.ToString("hh:mm:ss");
                trayItem.dSchedule_date = DateTime.Now;
                trayItem.cSchedule_time = DateTime.Now.ToString("hh:mm:ss");
                trayItem.cFrom_user_id = "999";
                trayItem.cEntity_id = "";
                trayItem.lForward_email = false;

                db.dTray.Add(trayItem);
                db.SaveChanges();
            }
        }
    }
}