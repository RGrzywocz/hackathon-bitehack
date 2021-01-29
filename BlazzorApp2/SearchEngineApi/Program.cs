using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngineApi
{
    public class Program
    {
        const string baseUrl = "https://api.scaleserp.com/search?api_key=C0C2142933804A7DA09CD98B853CD14A&q=";

        public String getUserWebSearch(String search)
        {
            string googleDoamain = "&google_domain=google.pl&location=Poland&gl=pl&hl=pl";
            var uriQuery = baseUrl + "?q=" + Uri.EscapeDataString(search) + googleDoamain;


            return uriQuery;

        }
        public String getUserLocationSearch(String search)
        {
            string googleDoamain = "&google_domain=google.pl&location=Poland&gl=pl&hl=pl&places_include_images=true&search_type=places";          

            var uriQuery = baseUrl + "?q=" + Uri.EscapeDataString(search) + googleDoamain;


            return uriQuery;

        }

        public T _download_serialized_json_data<T>(string searchString, bool location) where T : new()
        {
            string url = "";
            if (location)
            {
                 url = getUserWebSearch(searchString);
            }
            else
            {
                url = getUserLocationSearch(searchString);
            }

            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }
    }
}
