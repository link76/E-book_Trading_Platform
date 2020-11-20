using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Book_Trading_Platform.Models
{
    public class Admin
    {
        public int Id { get; set; }

        public string Password { get; set; }

        public string Mail { get; set; }

        public string Username { get; set; }

        public DateTime RegisterTime { get; set; }
    }
}
