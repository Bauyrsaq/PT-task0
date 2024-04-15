using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_layer_API
{
    public abstract class LibraryData_layer_API
    {
        public IEnumerable Users { get; set; }

        public abstract void AddBook(int v, Book book);
        public abstract void AddUser(User user);
        public abstract void MarkBookAsBorrowed(int userId, int bookId);
        public abstract void MarkBookAsReturned(int userId, int bookId);

        // Represents a user in the library system
        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        // Represents a book in the library catalog
        public class Book
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
        }

        // Represents an event in the library (e.g., borrowing, returning)
        public class LibraryEvent
        {
            public int Id { get; set; }
            public string Description { get; set; }
        }
    }
}
