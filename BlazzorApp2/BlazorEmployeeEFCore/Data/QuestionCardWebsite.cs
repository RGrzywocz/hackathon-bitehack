using BlazorEmployeeEFCore.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEmployeeEFCore.Data
{
    public class QuestionCardWebsite
    {
        public string Title{ get; set; }
        public WebsiteModel WebsiteModel { get; set; }
        public int WebsiteModelId { get; set; }
    }
}
