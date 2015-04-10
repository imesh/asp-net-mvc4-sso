using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc4SingleSignOnSAML2.Controllers.Utils
{
    /// <summary>
    /// Runtime configuration
    /// Author: imesh@apache.org
    /// </summary>
    public class Configuration
    {
        public static string TokenApiEndpoint { get; set; }
        public static string ConsumerKey { get; set; }
        public static string ConsumerSecret { get; set; }
        public static string TicketsApiEndpoint { get; set; }
    }
}