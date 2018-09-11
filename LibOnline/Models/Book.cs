using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibOnline.Models
{
    public class Book
    {
        public int ID { get; set; }

        [Display(Name ="Titel"), StringLength(50, MinimumLength = 2)]
        public string Title { get; set; }

        [Display(Name ="Returneras"), DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; }

        [Display(Name ="Författare")]
        public string Author { get; set; }

        public int? BorrowerID { get; set; }

        // Navigation Properties
        [Display(Name ="Låntagare")]
        public Borrower Borrower { get; set; }

        [Display(Name ="Utlånad")]
        public bool IsBorrowed {
            get
            {
                return BorrowerID != null;
            }
        }
    }
}
