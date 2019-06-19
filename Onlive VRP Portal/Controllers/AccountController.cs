using Onlive_VRP_Portal.Models.EntityManager;
using Onlive_VRP_Portal.Models.ViewModel;
using System.Web.Mvc;
using System.Web.Security;

namespace Onlive_VRP_Portal.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult NewCustomerSignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCustomerSignUp(NewCustomerView NCV)
        {
            CustomerManager CM = new CustomerManager();
            CM.CreateNewCustomer(NCV);
            NCV.USV.Account = NCV.Account;
            NCV.USV.FirstName = NCV.BillingFirstName;
            NCV.USV.LastName = NCV.BillingLastName;
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                TrayManager TM = new TrayManager();
                if (!UM.IsLoginNameExist(NCV.USV.LoginName))
                {
                    if (UM.IsAccountExist(NCV.USV.Account))
                    {
                        UM.AddUserAccount(NCV.USV);
                        TM.CreateTrayItem(NCV.USV.Account, "New Customer Request", "Please review and finish the new customer created from OVP");
                        System.Net.Mail.MailMessage mm = new System.Net.Mail.MailMessage(
                            new System.Net.Mail.MailAddress("support@rams-pro.com", "Web Registration"),
                            new System.Net.Mail.MailAddress(NCV.USV.Email));
                        mm.Subject = "Email confirmation";
                        mm.Body = string.Format("Dear {0} <BR/> Thank you for your registration, please click on the below link to complete your registration: <a href =\"{1}\" title =\"User Email Confirm\">{1}</a>",
                             NCV.USV.LoginName, Url.Action("ConfirmEmail", "Account", new { NCV.USV.LoginName, NCV.USV.Token, NCV.USV.Email }, Request.Url.Scheme));
                        mm.IsBodyHtml = true;
                        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com");
                        smtp.Credentials = new System.Net.NetworkCredential("jrekct@gmail.com", "1726354Cte");
                        smtp.EnableSsl = true;
                        smtp.Send(mm);
                        return RedirectToAction("Confirm", "Account", new { NCV.USV.Email });
                    }
                    else
                        ModelState.AddModelError("", "No Account Found!");
                }
                else
                    ModelState.AddModelError("", "Login Name already taken.");
            }
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult ConfirmEmail(string LoginName, string Token, string Email)
        {
            UserManager UM = new UserManager();
            string email = UM.GetUserEmail(LoginName);
            if (Token != null && UM.isTokenValid(Token, LoginName))
            {
                if (email == Email)
                {
                    UM.ConfirmEmail(LoginName);
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    return RedirectToAction("Confirm", "Account", new { Email = email });
                }
            }
            else
            {
                return RedirectToAction("Confirm", "Account", new { Email = "" });
            }
        }

        [AllowAnonymous]
        public ActionResult Confirm(string Email)
        {
            ViewBag.Email = Email;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(UserSignUpView USV)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                TrayManager TM = new TrayManager();
                if (!UM.IsLoginNameExist(USV.LoginName))
                {
                    if (UM.IsAccountExist(USV.Account))
                    {
                        UM.AddUserAccount(USV);
                        TM.CreateTrayItem(USV.Account, "New OVP User", "A user has signed up with the Online VRP Portal");
                        System.Net.Mail.MailMessage mm = new System.Net.Mail.MailMessage(
                            new System.Net.Mail.MailAddress("support@rams-pro.com", "Web Registration"),
                            new System.Net.Mail.MailAddress(USV.Email));
                        mm.Subject = "Email confirmation";
                        mm.Body = string.Format("Dear {0} <BR/> Thank you for your registration, please click on the below link to complete your registration: <a href =\"{1}\" title =\"User Email Confirm\">{1}</a>",
                             USV.LoginName, Url.Action("ConfirmEmail", "Account", new { USV.LoginName, USV.Token, USV.Email }, Request.Url.Scheme));
                        mm.IsBodyHtml = true;
                        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com");
                        smtp.Credentials = new System.Net.NetworkCredential("jrekct@gmail.com", "1726354Cte");
                        smtp.EnableSsl = true;
                        smtp.Send(mm);
                        return RedirectToAction("Confirm", "Account", new { USV.Email });
                    }
                    else
                        ModelState.AddModelError("", "No Account Found!");
                }
                else
                    ModelState.AddModelError("", "Login Name already taken.");
            }
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(UserLoginView ULV, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                CustomerManager CM = new CustomerManager();
                string password = UM.GetUserPassword(ULV.LoginName);
                ULV.Email = UM.GetUserEmail(ULV.LoginName);
                ULV.ConfirmedEmail = UM.IsEmailConfirmed(ULV.LoginName);

                if (string.IsNullOrEmpty(password))
                    ModelState.AddModelError("", "The user login or password provided is incorrect.");
                else
                {
                    if (UM.VerifyPassword(ULV.Password, password))
                    {
                        if (ULV.ConfirmedEmail == true)
                        {
                            FormsAuthentication.SetAuthCookie(ULV.LoginName, false);
                            if (UM.IsUserInRole(ULV.LoginName, "Admin")) return RedirectToAction("Index", "Admin");
                            else return RedirectToAction("Main", "Home");
                        }
                        else
                        {
                            return RedirectToAction("Confirm", "Account", new { Email = ULV.Email });
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "The password provided is incorrect.");
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(ULV);
        }

        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}