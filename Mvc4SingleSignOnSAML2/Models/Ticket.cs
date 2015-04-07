using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc4SingleSignOnSAML2.Models
{
    public class Ticket
    {
        public String ID { get; set; }
        public String Event { get; set; }
        public String Venue { get; set; }

        public Ticket()
        {
        }

        public Ticket(String id, String event_, String venue)
        {
            ID = id;
            Event = event_;
            Venue = venue;
        }
    }
}