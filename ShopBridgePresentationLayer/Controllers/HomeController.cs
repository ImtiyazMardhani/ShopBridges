using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ShopBridgeModelLayer;
using ShopBridgePresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ShopBridgePresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //public ActionResult Index()
        //{
        //    IEnumerable<Inventory> employees = GetEmployee();
        //    return View(employees);


        //}
        //IEnumerable<Inventory> GetEmployee()
        //{
        //    IEnumerable<Inventory> employees = null;
        //    using (HttpClient client = new HttpClient())
        //    {
        //        string url = "http://localhost/44384/api/Inventory";
        //        Uri uri = new Uri(url);
        //        System.Threading.Tasks.Task<HttpResponseMessage> result = client.GetAsync(uri);
        //        if (result.Result.IsSuccessStatusCode)
        //        {
        //            System.Threading.Tasks.Task<string> respones = result.Result.Content.ReadAsStringAsync();
        //            employees = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Inventory>>(respones.Result);
        //            //var readTask = result.Result.Content.ReadAsAsync<IList<Inventory>>();
        //            //readTask.Wait();
        //        }

        //    }
        //    return employees;

        //}
        string Baseurl = "https://localhost:44384/";
        public async Task<ActionResult> Index()
        {
            List<Inventory> EmpInfo = new List<Inventory>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/InventoryApi");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    EmpInfo = JsonConvert.DeserializeObject<List<Inventory>>(EmpResponse);

                }
                //returning the employee list to view  
                return View(EmpInfo);
            }
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
