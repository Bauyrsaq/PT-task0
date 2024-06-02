using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData
{
    public class State
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }

        public State(Book book, int quantity)
        {
            this.Book = book;
            this.Quantity = quantity;
        }

        public override string ToString()
        {
            return Book.ToString() + " Quantity: " + Quantity;
        }

        public override int GetHashCode()
        {
            int hashBook = Book.GetHashCode();
            int hashQuantity = Quantity.GetHashCode();
            return hashBook ^ hashQuantity;
        }
    }
}
