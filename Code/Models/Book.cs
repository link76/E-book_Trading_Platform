using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Book_Trading_Platform.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}
