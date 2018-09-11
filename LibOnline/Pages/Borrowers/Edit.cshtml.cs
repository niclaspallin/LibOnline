using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibOnline.Models;

namespace LibOnline.Pages.Borrowers
{
    public class EditModel : PageModel
    {
        private readonly LibOnline.Models.LibOnlineContext _context;

        public EditModel(LibOnline.Models.LibOnlineContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Borrower Borrower { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Borrower = await _context.Borrower.FirstOrDefaultAsync(m => m.ID == id);

            if (Borrower == null)
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

            _context.Attach(Borrower).State = EntityState.Modified;

            var borrower = await _context.Borrower.FindAsync(id);

            if (await TryUpdateModelAsync<Borrower>(borrower, "borrower",
                b => b.FirstName, b => b.LastName))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
