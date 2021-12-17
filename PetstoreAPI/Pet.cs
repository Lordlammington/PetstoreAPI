using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PetStoreAPI
{
    public class PetName
    {
        [JsonProperty("name")]
        public string Name { set; get; }
    }
}
