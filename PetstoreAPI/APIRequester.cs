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
