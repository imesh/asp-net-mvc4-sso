using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc4SingleSignOnSAML2.Models
{
    public class XmlPayload
    {
        public List<Ticket> Tickets { get; set; }
    }
}