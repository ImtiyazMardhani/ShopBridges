using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBridgeModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Formatting;


namespace ShopBridgePresentationLayer.Controllers
{
    public class InventoryControllers : Controller
    {
        // GET: InventoryControllers
        readonly string apiBaseAddress = "https://localhost:44384/";
        public async Task<ActionResult> Index()
        {
            IEnumerable<Inventory> employees = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);

                var result = await client.GetAsync("api/InventoryApiControllers");

                if (result.IsSuccessStatusCode)
                {
                    employees = await result.Content.ReadAsAsync<IList<Inventory>>();
                }
                else
                {
                    employees = Enumerable.Empty<Inventory>();
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            return View(employees);
        }

        // GET: InventoryControllers/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}
        public async Task<ActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            Inventory employee = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);

                var result = await client.GetAsync($"api/InventoryApiControllers/{id}");

                if (result.IsSuccessStatusCode)
                {
                    employee = await result.Content.ReadAsAsync<Inventory>();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }

            if (employee == null)
            {
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        // GET: InventoryControllers/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: InventoryControllers/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Inventory employee)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiBaseAddress);

                    var response = await client.PostAsJsonAsync("api/InventoryApiControllers", employee);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server error try after some time.");
                    }
                }
            }
            return View(employee);
        }
        // GET: InventoryControllers/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: InventoryControllers/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}




        public async Task<ActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Inventory employee = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);

                var result = await client.GetAsync($"api/InventoryApiControllers/{id}");

                if (result.IsSuccessStatusCode)
                {
                    employee = await result.Content.ReadAsAsync<Inventory>();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            if (employee == null)
            {
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit( Inventory employee)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiBaseAddress);
                    var response = await client.PutAsJsonAsync("api/InventoryApiControllers", employee);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server error try after some time.");
                    }
                }
                return RedirectToAction("Index");
            }
            return View(employee);
        }


        //public ActionResult Edit(Guid id)
        //{
        //    Inventory student = null;

        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:44384/api/");
        //        //HTTP GET
        //        var responseTask = client.GetAsync("InventoryApiControllers?id=" + id.ToString());
        //        //responseTask.Wait();

        //        var result = responseTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readTask = result.Content.ReadAsAsync<Inventory>();
        //            //readTask.Wait();

        //            student = readTask.Result;
        //        }
        //    }
        //    return View(student);
        //}

        //[HttpPost]
        //public ActionResult Edit(Inventory student)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:44384/api/InventoryApiControllers");

        //        //HTTP POST
        //        var putTask = client.PutAsJsonAsync<Inventory>("InventoryApiControllers", student);
        //        //putTask.Wait();

        //        var result = putTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {

        //            return RedirectToAction("Index");
        //        }
        //    }
        //    return View(student);
        //}



        // GET: InventoryControllers/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: InventoryControllers/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}



        public async Task<ActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Inventory employee = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);

                var result = await client.GetAsync($"api/InventoryApiControllers/{id}");

                if (result.IsSuccessStatusCode)
                {
                    employee = await result.Content.ReadAsAsync<Inventory>();

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }

            if (employee == null)
            {
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete( Inventory emp)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);

                var response = await client.DeleteAsync($"api/InventoryApiControllers/{emp.id}");
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return View();
        }


    }
}
