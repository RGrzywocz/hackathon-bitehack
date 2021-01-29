using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEmployeeEFCore.Services
{
    public interface IPlaceModelService
    {
       Task<IEnumerable<PlaceModelService>> GetPlaceModels();
    }
}
