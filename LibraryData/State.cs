using LibraryData.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData
{
    public class State : IState
    {
        public int Id { get; set; }
        public int bookId { get; set; }
        public int bookQuantity { get; set; }

        public State() { }

        public State(int id, int bookId, int bookQuantity)
        {
            this.Id = id;
            this.bookId = bookId;
            this.bookQuantity = bookQuantity;
        }

        public override string ToString()
        {
            return Id + " " + bookId + " Quantity: " + bookQuantity;
        }

        public override int GetHashCode()
        {
            int hadhId = Id.GetHashCode();
            int hashbookId = bookId.GetHashCode();
            int hashbookQuantity = bookQuantity.GetHashCode();
            return hadhId ^ hashbookId ^ hashbookQuantity;
        }
    }
}
