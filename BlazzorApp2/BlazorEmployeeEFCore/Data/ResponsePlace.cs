using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEmployeeEFCore.Shared
{
    public class PlaceClass
    {
        public List<PlaceModel> CreateList(ResponsePlace response)
        {
            List<PlaceModel> list = new List<PlaceModel>();
            foreach (var item in response.places_results)
            {
                list.Add(new PlaceModel(
                    item.position,
                    item.title,
                    item.description,
                    item.link,
                    item.extensions[3],
                    item.rating,
                    item.images.images[1]?.image)
                    ); ;
            }
            return list;
        }
        
    }
    public class PlaceModel
    {
        public PlaceModel(int id , string title, string description, string link, string adres, float rating, string image)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.link = link;
            this.adres = adres;
            this.rating = rating;
            this.image = image;
        }
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string link { get; set; }
        public string adres { get; set; }
        public float rating { get; set; }
        public string image { get; set; }
    }

    public class ResponsePlace
    {
        public Request_Info request_info { get; set; }
        public Search_Metadata search_metadata { get; set; }
        public Search_Parameters search_parameters { get; set; }
        public Search_Information search_information { get; set; }
        public Local_Map local_map { get; set; }
        public Pagination pagination { get; set; }
        public Places_Results[] places_results { get; set; }
        public string html { get; set; }
    }

    public class Request_Info
    {
        public bool success { get; set; }
        public int credits_used { get; set; }
        public int credits_used_this_request { get; set; }
        public int credits_remaining { get; set; }
        public DateTime credits_reset_at { get; set; }
    }

    public class Search_Metadata
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

    public class Search_Parameters
    {
        public string q { get; set; }
        public string include_html { get; set; }
        public string google_domain { get; set; }
        public string location { get; set; }
        public string gl { get; set; }
        public string hl { get; set; }
        public string places_include_images { get; set; }
        public string search_type { get; set; }
    }

    public class Search_Information
    {
        public bool original_query_yields_zero_results { get; set; }
        public string query_displayed { get; set; }
        public string detected_location { get; set; }
    }

    public class Local_Map
    {
        public string image { get; set; }
    }

    public class Pagination
    {
        public int current { get; set; }
        public string next { get; set; }
        public Other_Pages other_pages { get; set; }
        public Api_Pagination api_pagination { get; set; }
    }

    public class Other_Pages
    {
        public string _2 { get; set; }
    }

    public class Api_Pagination
    {
        public string next { get; set; }
        public Other_Pages1 other_pages { get; set; }
    }

    public class Other_Pages1
    {
        public string _2 { get; set; }
    }

    public class Places_Results
    {
        public string title { get; set; }
        public string data_cid { get; set; }
        public string snippet { get; set; }
        public Gps_Coordinates gps_coordinates { get; set; }
        public bool sponsored { get; set; }
        public string[] extensions { get; set; }
        public float rating { get; set; }
        public int reviews { get; set; }
        public int position { get; set; }
        public string link { get; set; }
        public bool unclaimed { get; set; }
        public string place_id { get; set; }
        public Opening_Hours opening_hours { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string category { get; set; }
        public Images images { get; set; }
        public Order[] order { get; set; }
        public string description { get; set; }
        public Reservation[] reservations { get; set; }
        public Menu[] menu { get; set; }
    }

    public class Gps_Coordinates
    {
        public float latitude { get; set; }
        public float longitude { get; set; }
    }

    public class Opening_Hours
    {
        public Per_Day[] per_day { get; set; }
    }

    public class Per_Day
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class Images
    {
        public Image[] images { get; set; }
        public int total { get; set; }
    }

    public class Image
    {
        public int position { get; set; }
        public string image { get; set; }
    }

    public class Order
    {
        public string text { get; set; }
        public string link { get; set; }
    }

    public class Reservation
    {
        public string text { get; set; }
        public string link { get; set; }
    }

    public class Menu
    {
        public string text { get; set; }
        public string link { get; set; }
    }


}