using LibOnline.Models;
using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace LibOnline.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LibOnlineContext(
                    serviceProvider.GetRequiredService<DbContextOptions<LibOnlineContext>>()
                ))
            {
                if (context.Book.Any() || context.Borrower.Any())
                {
                    return;
                }

                context.Borrower.AddRange(
                    new Borrower
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        City = "Stortorg",
                        StreetAdress = "Storgatan 1",
                        PostalCode = "123 45",
                        Phone = "08-123 456 78",
                        Email = "john.doe@example.com"
                    },
                    new Borrower
                    {
                        FirstName = "Jane",
                        LastName = "Doe",
                        City = "Stortorg",
                        StreetAdress = "Storgatan 2",
                        PostalCode = "123 45",
                        Phone = "08-123 456 78",
                        Email = "jane.doe@example.com"
                    },
                    new Borrower
                    {
                        FirstName = "Erik",
                        LastName = "Eriksson",
                        City = "Stortorg",
                        StreetAdress = "Storgatan 3",
                        PostalCode = "123 45",
                        Phone = "08-123 456 78",
                        Email = "erik.eriksson@example.com"
                    },
                    new Borrower
                    {
                        FirstName = "Karl",
                        LastName = "Karlsson",
                        City = "Stortorg",
                        StreetAdress = "Storgatan 4",
                        PostalCode = "123 45",
                        Phone = "08-123 456 78",
                        Email = "karl.karlsson@example.com"
                    },
                    new Borrower
                    {
                        FirstName = "Sven",
                        LastName = "Svensson",
                        City = "Stortorg",
                        StreetAdress = "Storgatan 5",
                        PostalCode = "123 45",
                        Phone = "08-123 456 78",
                        Email = "sven.svensson@example.com"
                    }
                    );
                context.SaveChanges();

                context.Book.AddRange(
                    new Book
                    {
                        Title = "Liftarens Guide till Galaxen",
                        Author = "Adam Douglas",
                        Borrower = context.Borrower.Find(1),
                        ReturnDate = DateTime.Now.AddDays(-3)
                    },
                    new Book
                    {
                        Title = "Resturangen vid slutet av universum",
                        Author = "Adam Douglas",
                        Borrower = context.Borrower.Find(2),
                        ReturnDate = DateTime.Now.AddDays(30)
                    },
                    new Book
                    {
                        Title = "Livet, universum och allting",
                        Author = "Adam Douglas",
                        Borrower = context.Borrower.Find(3)
                    },
                    new Book
                    {
                        Title = "Flickan som lekte med elden",
                        Author = "Stieg Larsson",
                        Borrower = context.Borrower.Find(4),
                        ReturnDate = DateTime.Now.AddDays(-30)
                    },
                    new Book
                    {
                        Title = "C# 7.0 in a Nutshell",
                        Author = "Joseph Albahari, Ben Albahari",
                        Borrower = context.Borrower.Find(5),
                        ReturnDate = DateTime.Now.AddDays(-30)
                    },
                    new Book
                    {
                        Title = "Skarp programmering med C#",
                        Author = "Sven Svensson",
                        Borrower = context.Borrower.Find(5),
                        ReturnDate = DateTime.Now.AddDays(-5)
                    },
                    new Book
                    {
                        Title = "How to Solve It",
                        Author = "Georg Polya"
                    },
                    new Book
                    {
                        Title = "Grit : Konsten att inte ge upp",
                        Author = "Angela Duckworth"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
