using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E_Book_Trading_Platform.Models;

namespace E_Book_Trading_Platform.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly Models.PlatformContext _context;

        public BookController(Models.PlatformContext context)
        {
            _context = context;
        }

        // GET:
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Books.ToList());
        }
        //GET: 
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var _book = _context.Books.FirstOrDefault(r => r.Id == id);
            if (_book == null)
                return NotFound();
            return Ok(_book);
        }
        // POST api/<OrderController>
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            _context.Add(book);
            _context.SaveChanges();
            return Created($"api/Order/{book.Id}", book);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book book)
        {
            var _book = _context.Books.FirstOrDefault(r => r.Id == id);
            if (_book == null)
                return NotFound();
            _book.Author = book.Author;
            _book.Price = book.Price;
            _book.Name = book.Name;
            _book.Image = book.Image;
            _book.Description = book.Description;

            _context.Update(_book);
            _context.SaveChanges();
            return Created($"api/order/{_book.Id}", _book);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var _book = _context.Books.FirstOrDefault(r => r.Id == id);
            if (_book == null)
                return NotFound();
            _context.Remove(_book);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
