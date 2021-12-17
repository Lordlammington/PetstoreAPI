using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PetStoreAPI
{
    class APIRequest : IAPIRequest
    {
        /// <summary>
        /// using HTTP Web request makes a request. Returns a list of PetName Objects.
        /// </summary>
        /// <param name="url"></param>
        /// The input URL for the program, Passed as a string because converting it to a URL is not needed. There's no editing taking place.
        /// <returns>
        /// A list of Pet Names that currently contains just the name.
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
