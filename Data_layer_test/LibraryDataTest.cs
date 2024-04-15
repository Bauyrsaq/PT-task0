using NUnit.Framework;
using Data_layer;
using LibraryData_layer;
using static Data_layer.LibraryData_layer_API;

namespace LibraryData_layer_test
{
    [TestFixture]
    public class LibraryDataTests
    {
        private LibraryData_layer_API _library;

        [SetUp]
        public void Initialize()
        {
            _library = new LibraryData_layer.LibraryData_layer();
            _library.AddUser(new User { Id = 1, Name = "John" });
            _library.AddBook(1, new Book { Id = 1, Title = "Book A", Author = "Author A" });
            // Add more initialization if needed
        }

        [Test]
        public void TestAddUser()
        {
            _library.AddUser(new User { Id = 2, Name = "Alice" });

            CollectionAssert.Contains(_library.Users, new User { Id = 2, Name = "Alice" });
        }

        // Similar tests for AddBook, AddEvent, etc.
    }
}
