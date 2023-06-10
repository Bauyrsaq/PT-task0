using LibraryLogic.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPresentationTest.Mock
{
    internal class StateDTOMock : IStateDTO
    {
        public int Id { get; set; }
        public int bookId { get; set; }
        public int bookQuantity { get; set; }

        public StateDTOMock(int id, int bookId, int bookQuantity)
        {
            this.Id = id;
            this.bookId = bookId;
            this.bookQuantity = bookQuantity;
        }
    }
}
