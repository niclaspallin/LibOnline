using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibOnline.Models;

namespace LibOnline.Pages.Borrowers
{
    public class DetailsModel : PageModel
    {
        private readonly LibOnline.Models.LibOnlineContext _context;

        public DetailsModel(LibOnline.Models.LibOnlineContext context)
        {
            _context = context;
        }

        public Borrower Borrower { get; set; }
        public ICollection<Book> Books { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Borrower = await _context.Borrower.FirstOrDefaultAsync(m => m.ID == id);

            var booksQuery = from book in _context.Book where book.Borrower.ID == id select book;
            Books = await booksQuery.ToListAsync();

            if (Borrower == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
