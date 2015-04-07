using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;

using ComponentSpace.SAML2;
using ComponentSpace.SAML2.Exceptions;

namespace Mvc4SingleSignOnSAML2.Controllers {
    public static class AppSettings {
        public const string PartnerIdP = "PartnerIdP";
    }

    [Authorize]
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult LogOut() {
            // Logout locally.
            FormsAuthentication.SignOut();

            try
            {
                // Request logout at the identity provider.
                string partnerIdP = WebConfigurationManager.AppSettings[AppSettings.PartnerIdP];
                SAMLServiceProvider.InitiateSLO(Response, null, partnerIdP);
            }
            catch (SAMLProtocolException e)
            {
                if (!e.Message.Contains("There is no SSO session to partner"))
                {
                    throw e;
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
