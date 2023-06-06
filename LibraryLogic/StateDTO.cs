using LibraryLogic.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLogic
{
    internal class StateDTO : IStateDTO
    {
        public int Id { get; set; }
        public int bookId { get; set; }
        public int bookQuantity { get; set; }

        public StateDTO(int id, int bookId, int bookQuantity)
        {
            this.Id = id;
            this.bookId = bookId;
            this.bookQuantity = bookQuantity;
        }
    }
}
