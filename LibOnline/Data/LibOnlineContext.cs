using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LibOnline.Models;

namespace LibOnline.Models
{
    public class LibOnlineContext : DbContext
    {
        public LibOnlineContext (DbContextOptions<LibOnlineContext> options)
            : base(options)
        {
        }

        public DbSet<LibOnline.Models.Book> Book { get; set; }

        public DbSet<LibOnline.Models.Borrower> Borrower { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(book => book.Borrower)
                .WithMany(borrower => borrower.Books)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
