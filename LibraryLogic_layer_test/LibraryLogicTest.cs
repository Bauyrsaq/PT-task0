using NUnit.Framework;
using Data_layer_API;
using LibraryData;
using LibraryLogic;
using static Data_layer_API.LibraryData_layer_API;
using Logic_layer_API;

namespace LibraryLogic_layer_test
{
    [TestFixture]
    internal class LibraryLogicTest
    {
        private LibraryData_layer_API _libraryData;
        private LibraryLogic_layer_API _libraryLogic;

        [SetUp]
        public void Initialize()
        {
            _libraryData = new LibraryData_layer();
            _libraryLogic = new LibraryLogic_layer(_libraryData);
            _libraryData.AddUser(new User { Id = 1, Name = "John" });
            _libraryData.AddBook(1, new Book { Id = 1, Title = "Book A", Author = "Author A" });
            // Add more initialization if needed
        }

        [Test]
        public void TestBorrowBook()
        {
            _libraryLogic.BorrowBook(1, 1);

            // Assert that the book is marked as borrowed
            // Get the book from the library data
            var borrowedBook = _libraryData.Catalog[1];
            // Assert that the book status is borrowed
            Assert.IsTrue(borrowedBook.IsBorrowed);
        }

        [Test]
        public void TestReturnBook()
        {
            // First, borrow a book
            _libraryLogic.BorrowBook(1, 1);

            // Now, return the book
            _libraryLogic.ReturnBook(1, 1);

            // Assert that the book is marked as returned
            // Get the book from the library data
            var returnedBook = _libraryData.Catalog[1];
            // Assert that the book status is not borrowed
            Assert.IsFalse(returnedBook.IsBorrowed);
        }
    }
}
