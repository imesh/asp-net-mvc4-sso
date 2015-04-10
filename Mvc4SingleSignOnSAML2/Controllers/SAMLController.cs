using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;

using ComponentSpace.SAML2;
using ComponentSpace.SAML2.Protocols;
using System.Text;
using System.Xml;
using Mvc4SingleSignOnSAML2.Controllers.Utils;
using System.Text.RegularExpressions;

namespace Mvc4SingleSignOnSAML2.Controllers {

    public class SAMLController : Controller {
    
        public const string AttributesSessionKey = "";

        private ActionResult RedirectToLocal(string returnUrl) {
            if (Url.IsLocalUrl(returnUrl)) {
                return Redirect(returnUrl);
            } else {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult AssertionConsumerService() {

            bool isInResponseTo = false;
            string partnerIdP = null;
            string userName = null;
            IDictionary<string, string> attributes = null;
            string targetUrl = null;

            byte[] bytes = Encoding.Default.GetBytes(Request.Form[0]);
            String samlResponseStr = Encoding.UTF8.GetString(bytes);
            samlResponseStr = Encoding.Default.GetString(Convert.FromBase64String(samlResponseStr));

            Regex regex = new Regex("<saml2:Assertion(.*)?</saml2:Assertion>");
            Match match = regex.Match(samlResponseStr);
            if (!match.Success)
            {
                throw new Exception("SAML assertion not found in response: " + samlResponseStr);
            }

            TokenApiClient tokenClient = new TokenApiClient();
            String samlAssertion = match.Value;
            String apiAccessToken = tokenClient.GetAccessToken(samlAssertion);
            if (String.IsNullOrEmpty(apiAccessToken))
            {
                throw new Exception("Could not retrieve API access token");
            }
            Runtime.ApiAccessToken = apiAccessToken;

            try
            {
                // Receive and process the SAML assertion contained in the SAML response.
                // The SAML response is received either as part of IdP-initiated or SP-initiated SSO.
                SAMLServiceProvider.ReceiveSSO(Request, out isInResponseTo, out partnerIdP, out userName, out attributes, out targetUrl);
            }
            catch (Exception e)
            {
                if((e.Message != null) && (e.Message.Contains("The XML is not a SAMLResponse"))) 
                {
                    // Due to some reason SAMLResponse of the logout is not properly processed
                    return RedirectToLocal(targetUrl);
                }
            }

            // If no target URL is provided, provide a default.
            if (targetUrl == null) {
                targetUrl = "~/";
            }

            // Login automatically using the asserted identity.
            // This example uses forms authentication. Your application can use any authentication method you choose.
            // There are no restrictions on the method of authentication.
            FormsAuthentication.SetAuthCookie(userName, false);

            // Save the attributes.
            Session[AttributesSessionKey] = attributes;

            // Redirect to the target URL.
            return RedirectToLocal(targetUrl);
        }

        public ActionResult SLOService() {
            // Receive the single logout request or response.
            // If a request is received then single logout is being initiated by the identity provider.
            // If a response is received then this is in response to single logout having been initiated by the service provider.
            bool isRequest = false;
            string logoutReason = null;
            string partnerSP = null;

            SAMLServiceProvider.ReceiveSLO(Request, out isRequest, out logoutReason, out partnerSP);

            if (isRequest) {
                // Logout locally.
                FormsAuthentication.SignOut();

                // Respond to the IdP-initiated SLO request indicating successful logout.
                SAMLServiceProvider.SendSLO(Response, null);
            } else {
                // SP-initiated SLO has completed.
                FormsAuthentication.RedirectToLoginPage();
            }

            return new EmptyResult();
        }
    }
}
