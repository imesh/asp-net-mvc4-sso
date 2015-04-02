using Mvc4SingleSignOnSAML2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc4SingleSignOnSAML2.Controllers
{
    public class TicketsController : Controller
    {
        private TicketsApiClient apiClient = new TicketsApiClient();
        //
        // GET: /Tickets/

        [Authorize]
        public ActionResult Index()
        {
            List<Ticket> tickets = apiClient.GetTicketsAsync();
            return View(tickets);
        }

    }
}
