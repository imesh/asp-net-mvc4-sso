using Mvc4SingleSignOnSAML2.Controllers.Utils;
using Mvc4SingleSignOnSAML2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Mvc4SingleSignOnSAML2.Controllers
{
    /// <summary>
    /// Tickets controller
    /// Author: imesh@apache.org
    /// </summary>
    public class TicketsController : Controller
    {
        private TicketsApiClient apiClient = new TicketsApiClient();
        //
        // GET: /Tickets/

        [Authorize]
        public ActionResult Index()
        {
            string token = Runtime.ApiAccessToken;
            if (String.IsNullOrEmpty(token)) 
            {
                throw new Exception("Access token not found!");
            }
            List<Ticket> tickets = apiClient.GetTicketsAsync(token);
            return View(tickets);
        }
    }
}
