using BlazorEmployeeEFCore.Shared;
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
        const string accessKey = "24be67ba0a70475c94894a8789420362";

        
        public  SearchResult GetResultsAsync(String search)
        {
            string baseUrl = "https://api.bing.microsoft.com/v7.0/search?q={0}";
            string searchQuery = "Klaudia Janecka";
            // string searchName = search; 
            var uriQuery = baseUrl + "?q=" + Uri.EscapeDataString(searchQuery);

            WebRequest request = HttpWebRequest.Create(uriQuery);
            request.Headers["Ocp-Apim-Subscription-Key"] = accessKey;
            HttpWebResponse response = (HttpWebResponse)request.GetResponseAsync().Result;
            string json = new StreamReader(response.GetResponseStream()).ReadToEnd();

            var searchResult = new SearchResult()
            {
                jsonResult = json,
                relevantHeaders = new Dictionary<String, String>()
            };
            foreach (String header in response.Headers)
            {
                if (header.StartsWith("BingAPIs-") || header.StartsWith("X-MSEdge-"))
                    searchResult.relevantHeaders[header] = response.Headers[header];
            }
            return searchResult;
        }
    }
}
