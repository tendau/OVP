using Onlive_VRP_Portal.Models.EntityManager;
using Onlive_VRP_Portal.Models.ViewModel;
using Onlive_VRP_Portal.Security;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Onlive_VRP_Portal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Welcome()
        {
            return View();
        }

        [AuthorizeRoles("Admin")]
        public ActionResult AdminOnly()
        {
            return View();
        }

        public ActionResult UnAuthorized()
        {
            return View();
        }

        [Authorize]
        public ActionResult Main()
        {
            return View();
        }

        [AuthorizeRoles("Admin")]
        public ActionResult ManageUserPartial(string status = "")
        {
            if (User.Identity.IsAuthenticated)
            {
                string loginName = User.Identity.Name;
                UserManager UM = new UserManager();
                UserDataView UDV = UM.GetUserDataView(loginName);

                string message = string.Empty;
                if (status.Equals("update")) message = "Update Successful";
                else if (status.Equals("delete")) message = "Delete Successful";

                ViewBag.Message = message;

                return PartialView(UDV);
            }

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult AccountInfoPartial(string status = "")
        {
            UserManager UM = new UserManager();
            CustomerManager CM = new CustomerManager();
            String account = UM.GetUserAccount(User.Identity.Name);
            CustomerDataView CDV = CM.GetCustomerData(account);

            string message = string.Empty;
            if (status.Equals("update")) message = "Update Successful";

            ViewBag.Message = message;

            return PartialView(CDV);
        }

        [Authorize]
        public ActionResult WOPartial()
        {
            UserManager UM = new UserManager();
            WorkOrderManager WM = new WorkOrderManager();
            string account = UM.GetUserAccount(User.Identity.Name);
            WorkOrderView WOV = WM.GetWorkOrderData(account);
            return PartialView(WOV);
        }

        [Authorize]
        public ActionResult ServicePartial()
        {
            UserManager UM = new UserManager();
            ServiceManager SM = new ServiceManager();
            string account = UM.GetUserAccount(User.Identity.Name);
            ServicePartialView SPV = new ServicePartialView();
            SPV.currentServices = SM.GetServiceData(account);
            SPV.ChangeServiceOptions = SM.GetChangeServiceSelector();
            SPV.FrequencyOptions = SM.GetChangeFrequencySelector();
            SPV.SizeOptions = SM.GetChangeSizeSelector();
            List<ServiceSelector> list = new List<ServiceSelector>();
            list = SM.GetServiceSelector(account);
            SPV.CurrentServicesDD = new SelectList(list, "serviceID", "serviceDisplay");
            SPV.AvailableRecurringServices = SM.GetAvailableServices("R");
            SPV.AvailableOneTimeServices = SM.GetAvailableServices("T");
            return PartialView(SPV);
        }

        [Authorize]
        public ActionResult MessagesPartial()
        {
            UserManager UM = new UserManager();
            MessageManager MM = new MessageManager();
            string account = UM.GetUserAccount(User.Identity.Name);
            string area = UM.GetUserArea(User.Identity.Name);
            List<MessageDataView> MDV = MM.GetMessages(account, area);
            return PartialView(MDV);
        }

        [Authorize]
        [HttpPost]
        public ActionResult StopService(string[] ServiceIds, ServicePartialView SPV)
        {
            if (ServiceIds.Length == 0)
            {
                return Redirect("Home/Index");
            }
            UserManager UM = new UserManager();
            ServiceManager SM = new ServiceManager();
            string account = UM.GetUserAccount(User.Identity.Name);

            SM.StopService(account, SPV.RestartDate, ServiceIds);

            var stoppedServices = new List<string>();

            foreach (string id in ServiceIds)
            {
                System.Diagnostics.Debug.WriteLine("canceling charge with id: " + id);
                stoppedServices.Add(id);
            }
            ViewBag.stoppedServices = stoppedServices;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult NewService(ServicePartialView SPV)
        {
            UserManager UM = new UserManager();
            TrayManager TM = new TrayManager();
            string account = UM.GetUserAccount(User.Identity.Name);
            TM.CreateTrayItem(account, "OVP - Request for new service", $"The account: {account} has requested a new service of type: " +
                $"{SPV.SelectedServiceType} to start on {SPV.StartDate}");
            return Redirect(Request.UrlReferrer.ToString());
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangeFrequency(ServicePartialView SPV, string changeDetails)
        {
            UserManager UM = new UserManager();
            TrayManager TM = new TrayManager();
            string account = UM.GetUserAccount(User.Identity.Name);
            TM.CreateTrayItem(account, "OVP - Request for change frequency", $"The account: {account} has requested to change the frequency of their service for: " +
                $"{SPV.SelectedCurrentService} to be picked up {SPV.SelectedFrequency} times a week. The user has added the following details: {changeDetails}");
            return Redirect(Request.UrlReferrer.ToString());
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangeSize(ServicePartialView SPV, string changeDetails)
        {
            UserManager UM = new UserManager();
            TrayManager TM = new TrayManager();
            string account = UM.GetUserAccount(User.Identity.Name);
            TM.CreateTrayItem(account, "OVP - Request for change bin size", $"The account: {account} has requested to change the size of their bin for service: " +
                $"{SPV.SelectedCurrentService}. The user has requested a {SPV.SelectedSize} bin. The user has added the following details: {changeDetails}");
            return Redirect(Request.UrlReferrer.ToString());
        }

        [Authorize]
        [HttpPost]
        public ActionResult NewMessage(string message, string subject)
        {
            UserManager UM = new UserManager();
            TrayManager TM = new TrayManager();
            string account = UM.GetUserAccount(User.Identity.Name);
            TM.CreateTrayItem(account, $"OVP - {subject}", message);
            return Redirect(Request.UrlReferrer.ToString());
        }

        [Authorize]
        [HttpPost]
        public ActionResult NewOneTimeService(ServicePartialView SPV)
        {
            UserManager UM = new UserManager();
            TrayManager TM = new TrayManager();
            string account = UM.GetUserAccount(User.Identity.Name);
            TM.CreateTrayItem(account, "OVP - Request for new single service", $"The account: {account} has requested a new service of type: " +
                $"{SPV.SelectedOTServiceType} for {SPV.OTServiceDate}");
            return Redirect(Request.UrlReferrer.ToString());
        }

        [Authorize]
        public ActionResult CreateWO(string WOType, DateTime WODate)
        {
            WorkOrderManager WM = new WorkOrderManager();
            UserManager UM = new UserManager();
            string account = UM.GetUserAccount(User.Identity.Name);
            WM.CreateNewWorkOrder(WOType, WODate, account);
            return Redirect(Request.UrlReferrer.ToString());
        }

        [Authorize]
        public ActionResult RequestServicePause(DateTime PauseDate)
        {
            CustomerManager CM = new CustomerManager();
            UserManager UM = new UserManager();
            string account = UM.GetUserAccount(User.Identity.Name);
            CM.PauseService(PauseDate, account);
            return Redirect(Request.UrlReferrer.ToString());
        }

        [Authorize]
        public ActionResult ReportbinDamage(string Description)
        {
            TrayManager TM = new TrayManager();
            UserManager UM = new UserManager();
            string account = UM.GetUserAccount(User.Identity.Name);
            TM.CreateTrayItem(account, "OVP - Reported Bin Damage", "The attached customer has reported damage to their bin. Please review the damage report and take the appropriate actions. Damage report: " + Description);
            return Redirect(Request.UrlReferrer.ToString());
        }

        [Authorize]
        public ActionResult EditAccount(CustomerDataView CDV)
        {
            EditCustomerview ECV = new EditCustomerview();
            ECV.BillingName = CDV.BillingName;
            ECV.Billingphone = CDV.BillingPhone;
            ECV.BillingEmail = CDV.BillingEmail;
            ECV.SiteName = CDV.SiteName;
            ECV.SitePhone = CDV.SitePhone;
            ECV.SiteEmail = CDV.SiteEmail;

            CustomerManager CM = new CustomerManager();
            UserManager UM = new UserManager();
            string account = UM.GetUserAccount(User.Identity.Name);
            CM.UpdateCustomer(ECV, account);

            return Redirect(Request.UrlReferrer.ToString());
        }

        [Authorize]
        public ActionResult reportNewAddress(CustomerDataView CDV)
        {
            CustomerManager CM = new CustomerManager();
            UserManager UM = new UserManager();
            string account = UM.GetUserAccount(User.Identity.Name);
            CM.ReportNewAddress(CDV.BillingAddress, CDV.BillingState, CDV.BillingCity, CDV.BillingZip, CDV.SiteAddress, CDV.SiteCity, CDV.SiteState, CDV.SiteZip, account);

            return Redirect(Request.UrlReferrer.ToString());
        }

        [AuthorizeRoles("Admin")]
        public ActionResult DeleteUser(int userID)
        {
            UserManager UM = new UserManager();
            UM.DeleteUser(userID);
            return Json(new { success = true });
        }

        [AuthorizeRoles("Admin")]
        public ActionResult UpdateUserData(int userID, string loginName, string password, string firstName, string lastName, string gender, int roleID = 0)
        {
            UserProfileView UPV = new UserProfileView();
            UPV.SYSUserID = userID;
            UPV.LoginName = loginName;
            UPV.Password = password;
            UPV.FirstName = firstName;
            UPV.LastName = lastName;
            UPV.Gender = gender;

            if (roleID > 0)
                UPV.LOOKUPRoleID = roleID;

            UserManager UM = new UserManager();
            UM.UpdateUserAccount(UPV);

            return Json(new { success = true });
        }
    }
}