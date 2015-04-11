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

namespace Mvc4SingleSignOnSAML2.Controllers.Utils
{
    public class TicketsApiClient
    {
        public List<Ticket> GetTicketsAsync(string token)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var authHeader = new AuthenticationHeaderValue("Bearer", token);
                httpClient.DefaultRequestHeaders.Authorization = authHeader;

                Task<String> response = httpClient.GetStringAsync(Configuration.TicketsApiEndpoint);
                if (response.Result.Contains("xmlPayload"))
                {
                    TicketsResponse ticketsResponse = JsonConvert.DeserializeObject<TicketsResponse>(response.Result);
                    return ticketsResponse.xmlPayload;
                }
                else
                {
                    return JsonConvert.DeserializeObject<List<Ticket>>(response.Result);
                }
            }
        }
    }
}