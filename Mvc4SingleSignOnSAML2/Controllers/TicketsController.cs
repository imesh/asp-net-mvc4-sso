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
            object tokenObj = Session["ApiAccessToken"];
            if ((tokenObj == null) || String.IsNullOrEmpty(tokenObj.ToString())) 
            {
                throw new Exception("Acces token not found in session");
            }
            List<Ticket> tickets = apiClient.GetTicketsAsync(tokenObj.ToString());
            return View(tickets);
        }
    }
}
