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

        public State(int id, int bookId, int bookQuantity)
        {
            this.Id = id;
            this.bookId = bookId;
            this.bookQuantity = bookQuantity;
        }
    }
}
