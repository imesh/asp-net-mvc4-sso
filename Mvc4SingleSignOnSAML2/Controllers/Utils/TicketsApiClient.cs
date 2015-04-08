using ComponentSpace.SAML2;
using Mvc4SingleSignOnSAML2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace Mvc4SingleSignOnSAML2.Controllers
{
    public class TicketsApiClient
    {
        // Change api url to api exposed by api manager
        readonly string url = "http://localhost:8281/tickets/v1.0.0";

        public List<Ticket> GetTicketsAsync(string token)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var authHeader = new AuthenticationHeaderValue("Bearer", token);
                httpClient.DefaultRequestHeaders.Authorization = authHeader;

                Task<String> response = httpClient.GetStringAsync(url);
                return JsonConvert.DeserializeObject<List<Ticket>>(response.Result);
            }
        }
    }
}