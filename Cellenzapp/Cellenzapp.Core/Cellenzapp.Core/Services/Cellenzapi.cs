using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Cellenzapp.Core
{
    public class Cellenzapi
    {
        private HttpClient _client;

        public Cellenzapi()
        {
            _client = new HttpClient();
        }

        public async Task<List<Expert>> GetExperts()
        {
            _client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "{subscription key}");

            var uri = "https://cellenzamanagementrandomapi.azure-api.net/cellenzapi/api/Experts";

            var response = await _client.GetAsync(uri);

            List<Expert> experts = JsonConvert.DeserializeObject<List<Expert>>(response.Content.ToString());

            return experts;
        }
    }
}

