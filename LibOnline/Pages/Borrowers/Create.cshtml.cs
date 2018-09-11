using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LibOnline.Models;

namespace LibOnline.Pages.Borrowers
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
        public Borrower Borrower { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var borrower = new Borrower();

            if (await TryUpdateModelAsync<Borrower>(borrower,
                "borrower",
                b => b.FirstName, b => b.LastName)){
                _context.Borrower.Add(borrower);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return null;
        }
    }
}