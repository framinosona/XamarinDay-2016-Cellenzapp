using System;
using Newtonsoft.Json;

namespace Cellenzapp.Core
{
    [JsonObject]
    public class Expert
    {
        [JsonProperty]
        public string Id { get; set; }
        [JsonProperty]
        public string Picture { get; set; }
        [JsonProperty]
        public int Company { get; set; }
        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public string Job { get; set; }
        [JsonProperty]
        public string Twitter { get; set; }
        [JsonProperty]
        public string Email { get; set; }
        [JsonProperty]
        public string Tel { get; set; }
        [JsonProperty]
        public string About { get; set; }
    }
}

