using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibOnline.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            ViewData["SearchplaceHolderText"] = "Sök på bok";
            ViewData["TargetPage"] = "/Books/Index";
        }
    }
}
