using System;
using System.Web.Mvc;
using Freetime.Authentication;
using Freetime.Base.Business;
using Freetime.Base.Business.Implementable;
using Freetime.Web.Context;

namespace Freetime.Web.Controller
{
    public class AccountController : BaseController<IAuthenticationLogic>
    {
        protected override IAuthenticationLogic DefaultLogic
        {
            get { return new AuthenticationLogic(); }
        }


        public ActionResult Logon()
        {
            return View("Logon");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult LogOn(string userName, string password, bool rememberMe, string returnUrl)
        {
            if (!ValidateLogOn(userName, password))
            {
                return View();
            }
            if (!String.IsNullOrEmpty(returnUrl))
                return Redirect(returnUrl);
            return RedirectToAction("Index", "Root");  
        }

        public ActionResult Logoff()
        {
            CurrentLogic.SignOutUser(CurrentUser);
            string theme = UserHandle.CurrentUser.DefaultTheme;
            SetCurrentUser(null);
            UserHandle.CurrentUser.DefaultTheme = theme;
            return View("Logoff");
        }

        public ActionResult Register()
        {
            return View();
        }

        private bool ValidateLogOn(string userName, string password)
        {
            if (String.IsNullOrEmpty(userName))
            {
                ModelState.AddModelError("username", "You must specify a username.");
            }
            if (String.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("password", "You must specify a password.");
            }

            FreetimeUser user = null;
            bool isAuthorized = CurrentLogic.SignInUser(userName, password, "", ref user);

            SetCurrentUser(user);
            return isAuthorized;
            //return ModelState.IsValid;
        }

        private static void SetCurrentUser(FreetimeUser user)
        {
            UserHandle.SetCurrentFreetimeUser(user);
        }

    }
}
