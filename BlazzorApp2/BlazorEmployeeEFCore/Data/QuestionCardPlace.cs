using BlazorEmployeeEFCore.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEmployeeEFCore.Data
{
    public class QuestionCardPlace
    {
        public string Title { get; set; }       
        public PlaceModel PlaceModel { get; set; }
        public int PlaceModelId { get; set; }
    }
}
