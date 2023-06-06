using LibraryLogic.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLogic
{
    internal class BorrowingDTO : IBorrowingDTO
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public int stateId { get; set; }
        public DateTime Date { get; set; }
        public int? bookQuantity { get; set; }

        public BorrowingDTO(int id, int userId, int stateId, DateTime date, int? bookQuantity)
        {
            this.Id = id;
            this.userId = userId;
            this.stateId = stateId;
            this.Date = date;
            this.bookQuantity = bookQuantity;
        }
    }
}
