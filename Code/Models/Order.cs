using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Book_Trading_Platform.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookImage { get; set; }
        public double BookPrice { get; set; }
        public int Count { get; set; }
    }
}
