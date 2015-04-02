using Mvc4SingleSignOnSAML2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Mvc4SingleSignOnSAML2.Controllers
{
    public class TicketsController : Controller
    {
        private TokenApiClient tokenClient = new TokenApiClient();
        private TicketsApiClient apiClient = new TicketsApiClient();
        //
        // GET: /Tickets/

        [Authorize]
        public ActionResult Index()
        {
            string token = tokenClient.GetAccessToken();
            if(String.IsNullOrEmpty(token)) 
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Index", "Home");
            }
            List<Ticket> tickets = apiClient.GetTicketsAsync(token);
            return View(tickets);
        }
    }
}
