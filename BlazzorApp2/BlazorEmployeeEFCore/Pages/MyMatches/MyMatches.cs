using BlazorEmployeeEFCore.Shared;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorEmployeeEFCore.Pages.MyMatches
{
    public partial class MyMatches
    {
        public List<PlaceModel> Places { get; set; }
        public List<PlaceModel> FilteredPlaces { get; set; }

        protected override async Task OnInitializedAsync()
        {
            GenerateData();
        }
        private void Filter(ChangeEventArgs e)
        {
            if (e == null)
                return;
            if (e.Value.ToString() == "")
                GenerateData();
            FilteredPlaces.Clear();
            foreach (var cell in Places)
            {
                if (cell.title.ToLower().Contains(e.Value.ToString().ToLower()))
                    FilteredPlaces.Add(cell);
            }
        }
        private void GenerateData()
        {
            var json = "{\"id\":1,\"title\":\"Pierogi\",\"description\":null,\"link\":\"https://www.facebook.com/pierogikrakowpl\",\"adres\":\"Kraków\",\"rating\":4.6,\"image\":\"https://lh5.googleusercontent.com/p/AF1QipP7idaSvJwDHlt_tUN6ph96XhJidB7EUrGJIlag\"}";
            var json2 = "{\"id\":2,\"title\":\"Czekolady E.Wedel\",\"description\":null,\"link\":\"http://www.wedelpijalnie.pl/\",\"adres\":\"Poznań\",\"rating\":4.1,\"image\":\"https://lh5.googleusercontent.com/p/AF1QipPD9i7BAsa1J5Vtn8j80Jla0fugcmA0xv7RVfmX\"}";
            var json3 = "{\"id\":3,\"title\":\"Obiad\",\"description\":\"„SmaQ Brasserie to nowoczesna restauracja w Q Hotel Kraków. W naszej karcie, tworzonej w oparciu o przepisy kuchni polskiej, proponujemy między innymi pysznego schabowego, żurek czy polskie pierogi z farszem do wyboru. U nas poczujesz się jak w domu!”\",\"link\":\"https://www.qhotels.pl/hotel-krakow-bronowice/restauracja/smaq-brasserie\",\"adres\":\"Zamknięte ⋅ Otwarcie: 15:00\",\"rating\":5.0,\"image\":\"https://lh5.googleusercontent.com/p/AF1QipP15Nr4ho1QZrTptNsOCsz8Wcqit2mS2U4jgYC-\"}";

            var result = JsonConvert.DeserializeObject<PlaceModel>(json);
            var result2 = JsonConvert.DeserializeObject<PlaceModel>(json2);
            var result3 = JsonConvert.DeserializeObject<PlaceModel>(json3);
            Places = new List<PlaceModel>();
            Places.Add(result);
            Places.Add(result2);
            Places.Add(result3);
            FilteredPlaces = new List<PlaceModel>(Places);
        }
        void ClickHandler(int index)
        {
            FilteredPlaces.Remove(FilteredPlaces.Find(e => e.id == index));
        }
    }

}
