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
        public IEnumerable? Users { get; set; }

        public abstract void AddBook(int v, Book book);
        //public abstract void AddBook(Book book);
        public abstract void AddUser(User user);
        public abstract void MarkBookAsBorrowed(int userId, int bookId);
        public abstract void MarkBookAsReturned(int userId, int bookId);

        // Represents a user in the library system
        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                    return false;

                User other = (User)obj;
                return Id == other.Id && Name == other.Name;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Id, Name);
            }
        }

        // Represents a book in the library catalog
        public class Book
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public bool IsBorrowed { get; set; }

            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                    return false;

                Book other = (Book)obj;
                return Id == other.Id && Title == other.Title && Author == other.Author;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Id, Title, Author);
            }
        }

        // Represents an event in the library (e.g., borrowing, returning)
        public class LibraryEvent
        {
            public int Id { get; set; }
            public string? Description { get; set; }
        }
    }
}
