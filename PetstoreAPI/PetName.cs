using Newtonsoft.Json;

namespace PetStoreAPI
{
    /// <summary>
    /// Used to store a list of pet names from the API call.
    /// </summary>
    public class PetName
    {
        [JsonProperty("name")]
        public string Name { set; get; }
    }
}
