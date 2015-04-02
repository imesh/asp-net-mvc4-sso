using TicketsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace TicketsApi.Controllers
{
    public class TicketsController : ApiController
    {
        private static Ticket[] tickets = new Ticket[] 
        {
            new Ticket("1", "Bryan Adams Live", "NY"),
            new Ticket("2", "Enrique Live", "Boston"),
            new Ticket("3", "FIFA World Cup 2015", "AZ")
        };
      

        // GET api/tickets
        public IEnumerable<Ticket> GetAllTickets()
        {
            return tickets;
        }

        // GET api/tickets/5
        public Ticket GetTicket(String id)
        {
            return tickets.FirstOrDefault((t) => t.ID.Equals(id));
        }

        // POST api/tickets
        public void Post([FromBody]string value)
        {
        }

        // PUT api/tickets/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/tickets/5
        public void Delete(int id)
        {
        }
    }
}
