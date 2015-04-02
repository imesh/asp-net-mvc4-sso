using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketsApi.Models
{
    public class Ticket
    {
        public String ID { get; set; }
        public String Title { get; set; }
        public String Venue { get; set; }

        public Ticket()
        {
        }

        public Ticket(String id, String title, String venue)
        {
            ID = id;
            Title = title;
            Venue = venue;
        }
    }
}