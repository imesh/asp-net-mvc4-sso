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
            new Ticket("1", "2015 NCAA Final Four", "Indianapolis, Lucas Oil Stadium"),
            new Ticket("2", "New York Yankees vs. Toronto Blue Jays", "Bronx, NY, Yankee Stadium"),
            new Ticket("3", "The Eagles", "Austin, TX Frank Erwin Center"),
            new Ticket("4", "Phantom of the Opera", "Majestic Theatre - NY"),
            new Ticket("5", "Elton John: The Million Dollar Piano", "Caesars Palace - Colosseum")
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
