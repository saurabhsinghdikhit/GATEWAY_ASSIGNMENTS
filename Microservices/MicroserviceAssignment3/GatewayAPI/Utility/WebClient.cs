using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GatewayAPI.Utility
{
    public static class WebClient
    {
        public static async Task<T> GetRequest<T>(string uri)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                    using HttpResponseMessage response = await client.GetAsync(uri);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<T>(responseBody);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return default(T);
            }
        }
    }
}
