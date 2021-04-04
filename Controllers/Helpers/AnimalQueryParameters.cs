using Newtonsoft.Json;

namespace AnimalsFriends.Helpers
{
    public class AnimalQueryParameters : QueryParameters
    {     
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("species")]
        public string Species { get; set; }
    }
}
