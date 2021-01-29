using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlazorEmployeeEFCore.Shared;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.CognitiveServices.Language.SpellCheck;
using Microsoft.Azure.CognitiveServices.Language.SpellCheck.Models;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.AspNetCore.Components;
using BlazorEmployeeEFCore.Services;

namespace BlazorEmployeeEFCore
{
    public class Program
    { 

        public static void Main(string[] args)
        {
            //string url = "https://api.scaleserp.com/search?api_key=6D8EA8E14B5043359D3E3C1F480A60CD&q=lekarz&google_domain=google.pl&location=Poland&gl=pl&hl=pl";
            //GetResponse newOne = new GetResponse();
            //Rootobject rootobject = newOne._download_serialized_json_data<Rootobject>(url);

            
            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

       

    }

}