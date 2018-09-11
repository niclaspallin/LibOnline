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
    public class IndexModel : PageModel
    {
        private readonly LibOnline.Models.LibOnlineContext _context;

        public IndexModel(LibOnline.Models.LibOnlineContext context)
        {
            _context = context;
        }

        public IList<Borrower> Borrower { get;set; }
        public string SearchText { get; set; }

        public async Task OnGetAsync(string searchText)
        {
            ViewData["SearchplaceHolderText"] = "Sök på namn";
            ViewData["TargetPage"] = "./Index";

            IQueryable<Borrower> borrowerQuery = from borrower in _context.Borrower select borrower;

            if(!String.IsNullOrEmpty(searchText))
            {
                SearchText = searchText;
                borrowerQuery = borrowerQuery.Where(borrower => borrower.FirstName.Contains(searchText) || borrower.LastName.Contains(searchText));
            }

            Borrower = await borrowerQuery.ToListAsync();
        }
    }
}
