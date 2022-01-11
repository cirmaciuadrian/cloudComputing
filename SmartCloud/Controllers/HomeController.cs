using LibraryData.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmartCloud.Models;
using SmartCloud.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartCloud.Controllers
{
    public class HomeController : Controller
    {

   

        public async Task<IActionResult> Index()
        {
            var url = "http://MicroserviceClass/class/get";
            var data = new
            {
                orice = "orice"
            };
            HttpClient httpClient = new HttpClient();
            var httpResponse = await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, url)
            {
                Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json")
            });
            if (httpResponse.IsSuccessStatusCode)
            {
                var response = await httpResponse.Content.ReadAsStringAsync();

                var classes = JsonConvert.DeserializeObject<List<Class>>(response);
                var model = new ClassViewModel();
                model.ClassesList = classes;
                httpClient.Dispose();
                return View(model);
            }
            else
            {
                throw new Exception("Erore la call api pentru getClasses");
            }


        }

        [HttpPost]
        public async Task<IActionResult> AddClass(string name, int capacity)
        {
            HttpClient httpClient = new HttpClient();
            Class newClass = new Class { ClassName = name, MaxClassSize = capacity };
          
            var uri = new Uri("http://MicroserviceClass/class/AddClass");

            var httpResponse = await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = new StringContent(JsonConvert.SerializeObject(newClass), Encoding.UTF8, "application/json")
            });

            var response = await httpResponse.Content.ReadAsStringAsync();

 
            httpClient.Dispose();
            return Json(new
            {
                msg = response
            });

        }

        
    }
}
