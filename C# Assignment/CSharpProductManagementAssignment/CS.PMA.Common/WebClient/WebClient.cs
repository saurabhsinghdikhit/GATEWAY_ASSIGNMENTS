using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CS.PMA.Common.WebClient
{
    public static class WebClient
    {
        public static HttpClient webAPIClient = new HttpClient();
        static WebClient()
        {
            webAPIClient.BaseAddress = new Uri("https://localhost:44358/");
            webAPIClient.DefaultRequestHeaders.Clear();
            webAPIClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
