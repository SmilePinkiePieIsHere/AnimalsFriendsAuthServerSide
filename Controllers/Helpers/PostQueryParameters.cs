using Newtonsoft.Json;

namespace AnimalsFriends.Helpers
{
    public class PostQueryParameters : QueryParameters
    {   
        [JsonProperty("category")]
        public string Category { get; set; }
    }
}
