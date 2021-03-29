using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace HRM.Common.WebClient
{
    public static class WebHttpClient
    {
        public static HttpClient webAPIClient = new HttpClient();
        static WebHttpClient()
        {
            webAPIClient.BaseAddress = new Uri("https://localhost:44380/");
            webAPIClient.DefaultRequestHeaders.Clear();
            webAPIClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
