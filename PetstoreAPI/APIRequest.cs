using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace PetStoreAPI
{



    public sealed class APIRequest : IAPIRequest
    {
        /// <summary>
        /// using HTTP Web request makes a request. Returns a list of PetName Objects.
        /// </summary>
        /// <param name="url">The input URL for the program, Passed as a string because converting it to a URL is not needed. There's no editing taking place.</param>
        /// <returns>
        /// Deserialized list of PetName objects, Currently just the pet names.
        /// </returns>
        public List<PetName> APIRequester(string url) 
        {
            string html;
            var request = (HttpWebRequest)WebRequest.Create(url);

            using (var response = (HttpWebResponse)request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream)) {html = reader.ReadToEnd(); }

            return JsonConvert.DeserializeObject<List<PetName>>(html);
        }
    }
}
