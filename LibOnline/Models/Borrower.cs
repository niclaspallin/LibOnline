using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibOnline.Models
{
    public class Borrower
    {
        public int ID { get; set; }

        [Display(Name ="Förnamn"), StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Display(Name ="Efternamn"), StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name="Telefonnummer"), DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Display(Name ="Gatuaddress")]
        public string StreetAdress { get; set; }

        [Display(Name ="Postort")]
        public string City { get; set; }

        [Display(Name ="Postnummer")]
        public string PostalCode { get; set; }

        [Display(Name ="Namn")]
        public string FullName {
            get {
                return FirstName + " " + LastName;
            }
        }

        // Navigtation Properties
        [Display(Name="Böcker")]
        public ICollection<Book> Books { get; set; }
    }
}
