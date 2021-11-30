using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopBridgeModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ShopBridgePresentationLayer.Controllers
{
    public class abc : Controller
    {
        // GET: InventoryController
        public string Baseurl = "https://localhost:44384/";
        public List<Inventory> EmpInfo = new List<Inventory>();
        public Inventory EmpInfos = new Inventory();
        public async Task<ActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/InventoryApiControllers");

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

        //GET: EmployeeController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            //var data = employees.GetEmployee(id);
            //return View(data);
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/InventoryApiControllers/" + id);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    EmpInfos = JsonConvert.DeserializeObject<Inventory>(EmpResponse);

                }
                //returning the employee list to view  
                return View(EmpInfo);
            }
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            Inventory empss = new Inventory();
            empss.id = Guid.NewGuid();
            return View(empss);
        }

        // POST: EmployeeController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Inventory model)
        //{
        //    try
        //    {
        //        employees.AddEmployee(model);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: EmployeeController/Edit/5
        //public ActionResult Edit(Guid id)
        //{
        //    var data = employees.GetEmployee(id);
        //    return View(data);
        //}

        //// POST: EmployeeController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Inventory model)
        //{
        //    try
        //    {
        //        var data = employees.GetEmployee(model.id);
        //        data.name = model.name;
        //        employees.UpdateEmployee(data);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: EmployeeController/Delete/5
        //public ActionResult Delete(Guid id)
        //{
        //    var data = employees.GetEmployee(id);
        //    return View(data);
        //}

        //// POST: EmployeeController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(Inventory model)
        //{
        //    try
        //    {
        //        var data = employees.GetEmployee(model.id);

        //        employees.DeleteEmployee(data.id);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
