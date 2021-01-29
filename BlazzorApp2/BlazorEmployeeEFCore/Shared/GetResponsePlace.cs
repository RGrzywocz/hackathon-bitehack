using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace BlazorEmployeeEFCore.Shared
{
    public class GetResponse
    {
        const string url = "https://api.scaleserp.com/search?api_key=6D8EA8E14B5043359D3E3C1F480A60CD&q=lekarz";


        public T _download_serialized_json_data<T>( ) where T : new()
        {
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
