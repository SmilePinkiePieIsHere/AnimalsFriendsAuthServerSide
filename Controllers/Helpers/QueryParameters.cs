using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AnimalsFriends.Helpers.Classes;

namespace AnimalsFriends.Helpers
{
    public class QueryParameters
    {
        const int _maxSize = 100;
        private int _size = 50;

        [JsonProperty("search")]
        public string Search { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; } = 1;

        [JsonProperty("size")]
        public int Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = Math.Min(_maxSize, value);
            }
        }        
    }
}
