using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SBS.Common.WebAPI.GlobalHttpClient
{
    public static class GlobalHttpClient
    {
        public static HttpClient webAPIClient = new HttpClient();
        static GlobalHttpClient()
        {
            webAPIClient.BaseAddress = new Uri("https://localhost:44372/");
            webAPIClient.DefaultRequestHeaders.Clear();
            webAPIClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
