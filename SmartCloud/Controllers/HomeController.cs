using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmartCloud.Models;
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
            var url = "https://localhost:49163/weatherforecast";
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
                JObject json = JObject.Parse(response);
                var jModel_Offers = json.Value<JObject>("Result");
                var result = jModel_Offers.ToString();
            }
            //    datalist = Newtonsoft.Json.JsonConvert.DeserializeObject<TapWaterGetOfferWrapper>(result);



            //    if (datalist.offer.Count > 0)
            //    {
            //        foreach (var item in datalist.offer)
            //        {
            //            listaFacturiCuOferte = listaFacturiCuOferte + "," + item.product.invoiceDiscounting.invoiceReferenceId;
            //        }
            //        listaFacturiCuOferte = listaFacturiCuOferte.Substring(1);
            //    }
            //}
            return View();
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
