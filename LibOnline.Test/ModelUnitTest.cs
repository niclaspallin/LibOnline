using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibOnline.Models;
using System;

namespace LibOnline.Test
{
    [TestClass]
    public class ModelUnitTest
    {
        [TestMethod]
        public void TestBorrowerIsNotBorrowed()
        {
            var book = new Book
            {
                Title = "Title 1",
                Author = "Author 1"
            };

            Assert.IsFalse(book.IsBorrowed, "'IsBorrowed' should be false when theres no 'BorrowerID'");
        }

        [TestMethod]
        public void TestBorrowerIsBorrowed()
        {
            var book = new Book
            {
                Title = "Title 1",
                Author = "Author 1",
                BorrowerID = 1
            };

            Assert.IsTrue(book.IsBorrowed, "IsBorrowed should be true");
        }
    }
}
