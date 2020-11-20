using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Book_Trading_Platform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace E_Book_Trading_Platform.Pages
{
    public class CartModel : PageModel
    {
        private readonly E_Book_Trading_Platform.Models.PlatformContext _context;

        public CartModel(E_Book_Trading_Platform.Models.PlatformContext context)
        {
            _context = context;
        }

        public IList<Models.Order> Order { get; set; }

     

        public async Task OnGetAsync()
        {
            if(ViewData["UserId"] != null)
            {
                ViewData["UserId"] = Request.Cookies["UserId"];

                var or = from m in _context.Orders
                         select m;
                    or = or.Where(s => s.AccountId.Equals(ViewData["UserId"]));
                Order = await or.ToListAsync();


            }
            else
            {
                Response.Redirect("/Login/Userlogin");
            }
            
        }

    }
}
