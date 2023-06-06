using LibraryData.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLogicTest.Mock
{
    internal class StateMock : IState
    {
        public int Id { get; set; }
        public int bookId { get; set; }
        public int bookQuantity { get; set; }

        public StateMock(int id, int bookId, int bookQuantity = 0)
        {
            this.Id = id;
            this.bookId = bookId;
            this.bookQuantity = bookQuantity;
        }
    }
}
