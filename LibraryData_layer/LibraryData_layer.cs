using Data_layer_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData
{
    public class LibraryData_layer : LibraryData_layer_API
    {
        // Collection of users
        public List<User> Users { get; } = new List<User>();

        // Dictionary of books (catalog)
        public Dictionary<int, Book> Catalog { get; } = new Dictionary<int, Book>();

        // Process state
        public string? ProcessState { get; set; }

        // Collection of events
        public List<LibraryEvent> Events { get; } = new List<LibraryEvent>();

        // Method to add a user to the collection
        public override void AddUser(User user)
        {
            Users.Add(user);
        }

        // Method to remove a user from the collection
        public void RemoveUser(User user)
        {
            Users.Remove(user);
        }

        // Method to add a book to the catalog
        public override void AddBook(int id, Book book)
        {
            Catalog[id] = book;
        }

        // Method to remove a book from the catalog
        public void RemoveBook(int id)
        {
            Catalog.Remove(id);
        }

        // Method to add an event to the collection
        public void AddEvent(LibraryEvent libraryEvent)
        {
            Events.Add(libraryEvent);
        }

        // Method to remove an event from the collection
        public void RemoveEvent(LibraryEvent libraryEvent)
        {
            Events.Remove(libraryEvent);
        }

        public override void MarkBookAsBorrowed(int userId, int bookId)
        {
            Book book = GetBookById(bookId);
            if (book != null)
            {
                // Update the book status to borrowed
                book.IsBorrowed = true;
                // You might want to implement additional logic here, such as tracking who borrowed the book
            }
            else
            {
                // Handle the case where the book with the provided ID doesn't exist
                throw new ArgumentException("Book not found in the catalog.");
            }
        }

        public override void MarkBookAsReturned(int userId, int bookId)
        {
            // Get the book from the catalog based on its ID
            Book book = GetBookById(bookId);
            if (book != null)
            {
                // Update the book status to returned
                book.IsBorrowed = false;
                // You might want to implement additional logic here, such as updating the borrower information
            }
            else
            {
                // Handle the case where the book with the provided ID doesn't exist
                throw new ArgumentException("Book not found in the catalog.");
            }
        }
    }
}
