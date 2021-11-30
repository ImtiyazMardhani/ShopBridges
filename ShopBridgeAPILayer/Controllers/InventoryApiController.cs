using Microsoft.AspNetCore.Mvc;
using ShopBridgeModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopBridgeAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryApiController : ControllerBase
    {

        public List<Inventory> emps=new List<Inventory>();
        //new Inventory{ id=Guid.NewGuid(),name="Pencil",description="You can Erase it back whenever needed",price=2},
        //new Inventory{ id=Guid.NewGuid(),name="Pen",description="Looks beautiful",price=5}
        //};


        public InventoryApiController()
        {
            //emps = new List<Inventory>();
            //emps.Add(new Inventory { id = Guid.NewGuid(), name = "Pencil", description = "You can Erase it back whenever needed", price = 2 });
            //emps.Add(new Inventory { id = Guid.NewGuid(), name = "Pen", description = "Looks beautiful", price = 5 });
        }

        // GET: api/<InventoryApiController>
        [HttpGet]
        public List<Inventory> Get()
        {
            //return new string[] { "value1", "value2" };
            return emps;
        }

        // GET api/<InventoryApiController>/5
        [HttpGet("{id}")]
        public Inventory Get(Guid id)
        {
            //return "value";
            var employs = emps.Where(x => x.id == id).FirstOrDefault();
            return employs;
            //return emps.FirstOrDefault<Inventory>(x => x.id.Equals(id));
        }

        // POST api/<InventoryApiController>
        [HttpPost]
        public void Post([FromBody] Inventory employee)
        {
           Inventory employs = new Inventory();
            employs.id = Guid.NewGuid();
            employs.name = employee.name;
            employs.description = employee.description;
            employs.price = Convert.ToInt32(employee.price.ToString());
            emps.Add(employs);
        }

        // PUT api/<InventoryApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Inventory employee)
        {
              Inventory employs = Get(employee.id);
            employs.name = employee.name;
            employs.description = employee.description;
            employs.price = employee.price;
        }

        // DELETE api/<InventoryApiController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            Inventory employs = Get(id);
            emps.Remove(employs);
        }
    }
}
