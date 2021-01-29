using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorEmployeeEFCore.Services
{
    public class PlaceModelService : IPlaceModelService
    {
        private readonly HttpClient _httpClient;

        public PlaceModelService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<PlaceModelService>> GetPlaceModels()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<PlaceModelService>>
                    (await _httpClient.GetStreamAsync("http://localhost:5000/api/PlaceModels"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
