using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibOnline.Models;

namespace LibOnline.Pages.Books
{
    public class DelayedModel : PageModel
    {
        private readonly LibOnline.Models.LibOnlineContext _context;

        public DelayedModel(LibOnline.Models.LibOnlineContext context)
        {
            _context = context;
        }

        public IList<Book> Books { get;set; }

        public async Task OnGetAsync()
        {
            var query = from book in _context.Book
                        where book.ReturnDate != null && book.ReturnDate < DateTime.Now
                        select book;
            Books = await query
                        .OrderBy(b => b.ReturnDate)
                        .Include(b => b.Borrower)
                        .ToListAsync();
        }
    }
}
