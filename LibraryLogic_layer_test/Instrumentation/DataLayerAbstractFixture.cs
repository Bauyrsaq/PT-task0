using Data_layer_API;
using LibraryData;
using System.Collections.Generic;
using static Data_layer_API.LibraryData_layer_API;

namespace LibraryLogic_layer_test.Instrumentation
{
    public class LibraryDataAbstractFixture : LibraryData_layer_API
    {
        internal int ConnectedCallCount = 0;

        // Collection of users (for testing purposes)
        public List<User> Users { get; } = new List<User>();

        // Dictionary representing the catalog of books (for testing purposes)
        public Dictionary<int, Book> Catalog { get; } = new Dictionary<int, Book>();

        private Dictionary<int, Book> _books = new Dictionary<int, Book>();

        // Method to simulate marking a book as borrowed (for testing purposes)
        public override void MarkBookAsBorrowed(int userId, int bookId)
        {
            // Simulate marking the book as borrowed in the stub implementation
            // For testing purposes, we won't implement the details of this method
        }

        // Method to simulate marking a book as returned (for testing purposes)
        public override void MarkBookAsReturned(int userId, int bookId)
        {
            // Simulate marking the book as returned in the stub implementation
            // For testing purposes, we won't implement the details of this method
        }

        // Method to simulate adding a book to the catalog (for testing purposes)
        public override void AddBook(int id, Book book)
        {
            _books[id] = book;
        }

        // Method to simulate adding a user to the collection (for testing purposes)
        public override void AddUser(User user)
        {
            Users.Add(user); // Add the user to the Users collection
        }

        public Book GetBookById(int id)
        {
            return _books.ContainsKey(id) ? _books[id] : null;
        }
    }
}
