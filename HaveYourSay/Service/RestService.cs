using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HaveYourSay.Model;
using Newtonsoft.Json;

namespace HaveYourSay.Service
{
    public class RestService : IRestService
    {
        HttpClient client;

        public RestService()
        {
            client = new HttpClient
            {
                MaxResponseContentBufferSize = 256000
            };

        }

        public async Task SaveEntryAsync(Entry item )
        {
            var RestUrl = "https://hzsites.azurewebsites.net/api/hys";
            var uri = new Uri(RestUrl);

            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await client.PostAsync(uri, content);
                

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"             Item successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"             ERROR {0}", ex.Message);
            }
        }
    }
}
