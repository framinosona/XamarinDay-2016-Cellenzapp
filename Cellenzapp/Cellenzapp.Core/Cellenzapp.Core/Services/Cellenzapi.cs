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
        private const string SUBSCRIPTION_KEY = "7967e8f89c93428686a7489886bb0b5c";

        public Cellenzapi()
        {
        }

        public async Task<List<Expert>> GetExperts()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("Ocp-Apim-Trace", "true");
            _client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "7967e8f89c93428686a7489886bb0b5c");

            var uri = "https://cellenzamanagementrandomapi.azure-api.net/cellenzapi/api/Experts?";

            var response = await _client.GetAsync(uri);

            List<Expert> experts = JsonConvert.DeserializeObject<List<Expert>>(response.Content.ToString());

            return experts;
        }

        public async Task<List<Expert>> UpdateAbout()
        {
            return null;
        }

        public async Task<List<Expert>> AddExpert()
        {
            return null;
        }
    }
}

