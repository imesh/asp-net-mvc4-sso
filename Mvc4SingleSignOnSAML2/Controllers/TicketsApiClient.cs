using Mvc4SingleSignOnSAML2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Mvc4SingleSignOnSAML2.Controllers
{
    public class TicketsApiClient
    {
        readonly string uri = "http://localhost:2423/api/tickets";

        public List<Ticket> GetTicketsAsync()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<List<Ticket>>(response.Result);
            }
        }
    }
}