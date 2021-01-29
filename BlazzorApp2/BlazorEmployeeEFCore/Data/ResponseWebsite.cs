using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEmployeeEFCore.Shared
{
    public class WebsiteClass
    {
        public List<WebsiteModel> CreateList(ResponseWebsite response)
        {
            List<WebsiteModel> list = new List<WebsiteModel>();
            foreach (var item in response.organic_results)
            {
                list.Add(new WebsiteModel(
                    item.position,
                    item.title,
                    item.link,
                    item.snippet
                    ));
            };
            return list;
        }
        
    }
    public class WebsiteModel
    {
        public WebsiteModel(int id, String Title, String Link, String Snippet) 
        {
            this.id = id;
            this.Title = Title;
            this.Link = Link;
            this.Snippet = Snippet;
        }
        public int id { get; set; }
        public String Title { get; set; }
        public String Link { get; set; }
        public String Snippet { get; set; }
    }
    public class ResponseWebsite
    {
        public Request_Info_Website request_info { get; set; }
        public Search_Metadata_Website search_metadata { get; set; }
        public Search_Parameters_Website search_parameters { get; set; }
        public Search_Information_Website search_information { get; set; }
        public Answer_Box answer_box { get; set; }
        public Inline_Videos[] inline_videos { get; set; }
        public Top_Stories[] top_stories { get; set; }
        public Top_Stories_Extra top_stories_extra { get; set; }
        public Knowledge_Graph knowledge_graph { get; set; }
        public Related_Searches[] related_searches { get; set; }
        public Pagination_Website pagination { get; set; }
        public Organic_Results[] organic_results { get; set; }
        public string html { get; set; }
    }

    public class Request_Info_Website
    {
        public bool success { get; set; }
        public int credits_used { get; set; }
        public int credits_used_this_request { get; set; }
        public int credits_remaining { get; set; }
        public DateTime credits_reset_at { get; set; }
    }

    public class Search_Metadata_Website
    {
        public DateTime created_at { get; set; }
        public DateTime processed_at { get; set; }
        public float total_time_taken { get; set; }
        public string engine_url { get; set; }
        public string html_url { get; set; }
        public string json_url { get; set; }
        public string location_auto_message { get; set; }
        public string[] timing { get; set; }
    }

    public class Search_Parameters_Website
    {
        public string q { get; set; }
        public string include_html { get; set; }
        public string google_domain { get; set; }
        public string location { get; set; }
        public string gl { get; set; }
        public string hl { get; set; }
    }

    public class Search_Information_Website
    {
        public bool original_query_yields_zero_results { get; set; }
        public int total_results { get; set; }
        public float time_taken_displayed { get; set; }
        public string query_displayed { get; set; }
        public string detected_location { get; set; }
    }

    public class Answer_Box
    {
        public int answer_box_type { get; set; }
        public Answer[] answers { get; set; }
        public int block_position { get; set; }
    }

    public class Answer
    {
        public string conversion_type { get; set; }
        public Original original { get; set; }
        public Converted converted { get; set; }
    }

    public class Original
    {
        public int value { get; set; }
        public string unit { get; set; }
    }

    public class Converted
    {
        public float value { get; set; }
        public string unit { get; set; }
    }

    public class Top_Stories_Extra
    {
        public string more_news_link { get; set; }
    }

    public class Knowledge_Graph
    {
        public string title { get; set; }
        public string type { get; set; }
        public Source source { get; set; }
        public string description { get; set; }
        public Known_Attributes[] known_attributes { get; set; }
        public Podobne_Wyszukiwania[] podobne_wyszukiwania { get; set; }
        public int block_position { get; set; }
    }

    public class Source
    {
        public string name { get; set; }
        public string link { get; set; }
    }

    public class Known_Attributes
    {
        public string attribute { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public string link { get; set; }
    }

    public class Podobne_Wyszukiwania
    {
        public string name { get; set; }
        public string link { get; set; }
    }

    public class Pagination_Website
    {
        public string next { get; set; }
        public Other_Pages_Website other_pages { get; set; }
        public Api_Pagination_Website api_pagination { get; set; }
    }

    public class Other_Pages_Website
    {
        public string _2 { get; set; }
        public string _3 { get; set; }
        public string _4 { get; set; }
        public string _5 { get; set; }
        public string _6 { get; set; }
        public string _7 { get; set; }
        public string _8 { get; set; }
        public string _9 { get; set; }
        public string _10 { get; set; }
    }

    public class Api_Pagination_Website
    {
        public string next { get; set; }
        public Other_Pages1_Website other_pages { get; set; }
    }

    public class Other_Pages1_Website
    {
        public string _2 { get; set; }
        public string _3 { get; set; }
        public string _4 { get; set; }
        public string _5 { get; set; }
        public string _6 { get; set; }
        public string _7 { get; set; }
        public string _8 { get; set; }
        public string _9 { get; set; }
        public string _10 { get; set; }
    }

    public class Inline_Videos
    {
        public string title { get; set; }
        public string link { get; set; }
        public string length { get; set; }
        public string source { get; set; }
        public string date { get; set; }
        public int block_position { get; set; }
    }

    public class Top_Stories
    {
        public string link { get; set; }
        public string title { get; set; }
        public bool visible_initially { get; set; }
        public string source { get; set; }
        public string date { get; set; }
        public int block_position { get; set; }
    }

    public class Related_Searches
    {
        public string query { get; set; }
        public string link { get; set; }
    }

    public class Organic_Results
    {
        public int position { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public string domain { get; set; }
        public string displayed_link { get; set; }
        public string snippet { get; set; }
        public bool prerender { get; set; }
        public string[] snippet_matched { get; set; }
        public string cached_page_link { get; set; }
        public int block_position { get; set; }
        public string related_page_link { get; set; }
        public Rich_Snippet rich_snippet { get; set; }
    }

    public class Rich_Snippet
    {
        public Top top { get; set; }
    }

    public class Top
    {
        public Detected_Extensions detected_extensions { get; set; }
        public string[] extensions { get; set; }
    }

    public class Detected_Extensions
    {
    }

}
