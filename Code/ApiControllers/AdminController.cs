using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using E_Book_Trading_Platform.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Book_Trading_Platform.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //public class OrderController : ControllerBase
    public class AdminController : ControllerBase
    {

        private readonly Models.PlatformContext _context;

        public AdminController(Models.PlatformContext context)
        {
            _context = context;
        }

        // GET:
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Admins.ToList());
        }
        //GET: 
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var _order = _context.Admins.FirstOrDefault(r => r.Id == id);
            if (_order == null)
                return NotFound();
            return Ok(_order);
        }
        // POST api/<OrderController>
        [HttpPost]
        public IActionResult Post([FromBody] Admin admin)
        {
            _context.Add(admin);
            _context.SaveChanges();
            return Created($"api/Order/{admin.Id}", admin);
        }

            // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Admin admin)
        {
            var _order = _context.Admins.FirstOrDefault(r => r.Id == id);
            if (_order == null)
                return NotFound();
            _order.Username = admin.Username;
            _order.Password = admin.Password;
            _order.Mail = admin.Mail;
            _order.RegisterTime = admin.RegisterTime;

            _context.Update(_order);
            _context.SaveChanges();
            return Created($"api/order/{_order.Id}", _order);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var _order = _context.Admins.FirstOrDefault(r => r.Id == id);
            if (_order == null)
                return NotFound();
            _context.Remove(_order);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
