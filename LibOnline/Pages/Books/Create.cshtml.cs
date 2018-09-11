using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LibOnline.Models;

namespace LibOnline.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly LibOnline.Models.LibOnlineContext _context;

        public CreateModel(LibOnline.Models.LibOnlineContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var book = new Book();

            // Prevent Overposting
            if (await TryUpdateModelAsync<Book>(book, "book",
                b => b.Title, b => b.Author, b => b.ReturnDate))
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return null;
        }
    }
}