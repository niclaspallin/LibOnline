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
    public class IndexModel : PageModel
    {
        private readonly LibOnline.Models.LibOnlineContext _context;

        public IndexModel(LibOnline.Models.LibOnlineContext context)
        {
            _context = context;
        }

        public IList<Book> Books { get;set; }
        public string SearchText { get; set; }

        public async Task OnGetAsync(string searchText)
        {
            ViewData["SearchplaceHolderText"] = "Sök på titel eller författare";
            ViewData["TargetPage"] = "./Index";

            IQueryable <Book> query = from book in _context.Book
                                      select book;
            SearchText = searchText;

            if(!String.IsNullOrEmpty(searchText))
            {
                query = query.Where(book => book.Title.Contains(searchText) || book.Author.Contains(searchText));
            }

            Books = await query.Include(b => b.Borrower).ToListAsync();
        }
    }
}
