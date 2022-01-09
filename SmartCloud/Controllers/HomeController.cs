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
        private readonly ILogger<HomeController> _logger;
        private static HttpClient httpClient = new HttpClient();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var url = "https://localhost:49167/weatherforecast";
            var data = new
            {
                orice = "orice"
            };
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
                return View(model);
            }
            else
            {
                throw new Exception("Erore la call api pentru getClasses");
            }
        }
        [HttpPost]
        public  async Task<IActionResult> AddClass(Class newClass)
        {
            
            return null;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
