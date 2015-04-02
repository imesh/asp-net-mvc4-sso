using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;

using ComponentSpace.SAML2;

namespace Mvc4SingleSignOnSAML2.Controllers {
    public static class AppSettings {
        public const string PartnerIdP = "PartnerIdP";
    }

    [Authorize]
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult Logout() {
            // Logout locally.
            FormsAuthentication.SignOut();

            // Request logout at the identity provider.
            string partnerIdP = WebConfigurationManager.AppSettings[AppSettings.PartnerIdP];
            SAMLServiceProvider.InitiateSLO(Response, null, partnerIdP);

            return new EmptyResult();
        }
    }
}
