using Onlive_VRP_Portal.Models.EntityManager;
using Onlive_VRP_Portal.Models.ViewModel;
using Onlive_VRP_Portal.Security;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Onlive_VRP_Portal.Controllers
{
    public class AdminController : Controller
    {
        [AuthorizeRoles("Admin")]
        public ActionResult Index()
        {
            return View();
        }

        [AuthorizeRoles("Admin")]
        public ActionResult AdminMessagePartial()
        {
            MessageManager MM = new MessageManager();
            List<AdminMessageView> MDV = MM.GetAllMessages();
            return PartialView(MDV);
        }

        [AuthorizeRoles("Admin")]
        public ActionResult CreateMessage(string account, string subject, string message)
        {
            MessageManager MM = new MessageManager();
            MM.CreateNewMessage(account, subject, message);
            return Json(new { success = true });
        }

        [AuthorizeRoles("Admin")]
        public ActionResult DeleteMessage(string id)
        {
            MessageManager MM = new MessageManager();
            MM.DeleteMessage(id);
            return Json(new { success = true });
        }
    }
}