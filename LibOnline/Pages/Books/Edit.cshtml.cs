using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibOnline.Models;

namespace LibOnline.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly LibOnline.Models.LibOnlineContext _context;

        public EditModel(LibOnline.Models.LibOnlineContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; }
        public SelectList BorrowerList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var query = from b in _context.Book
                        where b.ID == id
                        select b;

            Book = await query
                .Include(b => b.Borrower)
                .FirstOrDefaultAsync();

            var borrowerQuery = from b in _context.Borrower
                                select b;

            BorrowerList = new SelectList(await borrowerQuery.ToListAsync(), "ID", "FullName");

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var book = await _context.Book.FindAsync(id);
           
            if(await TryUpdateModelAsync<Book>(book, "book",
                b => b.Title, b => b.ReturnDate, b => b.Author, b => b.BorrowerID))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
