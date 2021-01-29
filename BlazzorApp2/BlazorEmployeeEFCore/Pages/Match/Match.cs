using BlazorEmployeeEFCore.Services;
using BlazorEmployeeEFCore.Shared;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace BlazorEmployeeEFCore.Pages.Match
{
    public partial class Match
    {
        [Parameter]
        public string searchPattern { get; set; }
        [Inject]
        public SearchEngine SearchEngineService { get; set; }
        [Inject]
        public IPlaceModelService placeModelService { get; set; }
        private static readonly HttpClient client = new HttpClient();
        public List<PlaceModel> ResponsePlaces = new List<PlaceModel>();
        public int counter = 0;
        public string Link;
        public string Adres { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
        string content = "Lorem Ipsum is simply dummy text of the printing " +
                "an typesetting industry. Lorem Ipsum has been the industry's " +
                "standard dummy text ever since t Lorem Ipsum is simply dummy text o";
        PlaceModel AccualPlace;
        protected override async Task OnInitializedAsync()
        {
            ResponsePlace obj = SearchEngineService._download_serialized_json_data<ResponsePlace>(searchPattern, true);

            PlaceClass placeClass = new PlaceClass();
            ResponsePlaces = placeClass.CreateList(obj);
            //obj.'
            if (ResponsePlaces.Count != 0)
                ChangePlace(0);
            var response= placeModelService.GetPlaceModels();
        }
        void OnBackAction()
        {
            if (counter != 0)
                counter--;
            ChangePlace(counter);
        }
        void OnNoAction()
        {
            if (counter < ResponsePlaces.Count)
                counter++;
            ChangePlace(counter);
        }
        async Task OnYesAction()
        {
            AccualPlace = ResponsePlaces[counter];
            var json = JsonConvert.SerializeObject(AccualPlace);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var response = await client.PostAsJsonAsync("api/PlaceModels", stringContent);
        }
        void ChangePlace(int number)
        {
            Description = ResponsePlaces[number].description;
            Link = ResponsePlaces[number].link;
            Adres= ResponsePlaces[number].adres;
            Title = ResponsePlaces[number].title;
            Rating = ResponsePlaces[number].rating;
        }
    }
}
