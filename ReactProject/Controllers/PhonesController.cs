using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReactProject.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReactProject.Controllers
{
    [Route("api/[controller]")]
    public class PhonesController : Controller
    {
        static readonly List<Phone> data;
        static PhonesController()
        {
            data = new List<Phone>
            {
                new Phone { Id = Guid.NewGuid().ToString(), Name = "Xiaomi mi 9t", Price = 20000},
                new Phone { Id = Guid.NewGuid().ToString(), Name = "Iphone 11", Price = 70000},
                new Phone { Id = Guid.NewGuid().ToString(), Name = "Iphone 11 max", Price = 90000},
                new Phone { Id = Guid.NewGuid().ToString(), Name = "Iphone 10 max", Price = 80000},
                new Phone { Id = Guid.NewGuid().ToString(), Name = "Iphone 8", Price = 40000}
            };
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Phone> Get()
        {
            return data;
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post(Phone phone)
        {
            phone.Id = Guid.NewGuid().ToString();
            data.Add(phone);
            return Ok(phone);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Phone phone = data.FirstOrDefault(f => f.Id == id);
            if (phone == null)
            {
                return NotFound();
            }
            data.Remove(phone);
            return Ok(phone);
        }
    }
}
