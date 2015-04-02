using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc4SingleSignOnSAML2.Models
{
    //"scope":"default","token_type":"Bearer","expires_in":3300,"refresh_token":"14257d8854df37d156e3210171ae49","access_token":"56cb8673647fc95b53bb2fcc08e86a4"
    public class TokenGenerationResponse
    {
        public string scope { get; set; }
        public string token_type { get; set; }
        public long expires_in { get; set; }
        public string refresh_token { get; set; }
        public string access_token { get; set; }
    }
}