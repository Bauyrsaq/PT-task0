using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryData;

namespace LibraryDataTest
{
    [TestClass]
    public class BookTest
    {
        [TestMethod]
        public void BookConstructor()
        {
            Book book = new Book(1, "Fairy Tail");
            Assert.AreEqual(1, book.BookID);
            Assert.AreEqual("Fairy Tail", book.Name);
        }

        [TestMethod]
        public void GetBookTest()
        {

        }
    }
}
