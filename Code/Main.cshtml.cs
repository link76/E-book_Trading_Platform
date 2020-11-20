using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using E_Book_Trading_Platform.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Book_Trading_Platform.Pages.Shared
{
    public class MainModel : PageModel
    {
        private readonly E_Book_Trading_Platform.Models.PlatformContext _context;

        public MainModel(E_Book_Trading_Platform.Models.PlatformContext context)
        {
            _context = context;
        }
        
        public IList<Book> Book { get; set; }

        public async Task OnGetAsync()
        {
            ViewData["UserId"] = Request.Cookies["UserId"];
            bool hasUserid = Request.Cookies.TryGetValue("User", out string userid);
            if (hasUserid)
            {
                ViewData["UserName"] = userid;
            }
            Book = await _context.Books.ToListAsync();
        }
    }
}
