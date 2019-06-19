using Onlive_VRP_Portal.Security;
using System.Web.Mvc;

namespace Onlive_VRP_Portal.Controllers
{
    public class SettingsController : Controller
    {
        [AuthorizeRoles("Admin")]
        public ActionResult Index()
        {
            return View();
        }

        [AuthorizeRoles("Admin")]
        public ActionResult UpdateSetting(string key, string value)
        {
            return View();
        }
    }
}