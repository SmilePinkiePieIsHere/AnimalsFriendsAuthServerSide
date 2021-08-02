using Newtonsoft.Json;
using System.Collections.Generic;

namespace AnimalsFriends.Helpers
{
    public class AnimalQueryParameters : QueryParameters
    {     
        [JsonProperty("status")]
        public List<string> Status { get; set; }

        [JsonProperty("gender")]
        public List<string> Gender { get; set; }

        [JsonProperty("species")]
        public List<string> Species { get; set; }
    }
}
