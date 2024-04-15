using Data_layer_API;
using Logic_layer_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLogic
{
    public class LibraryLogic_layer : LibraryLogic_layer_API
    {
        public LibraryLogic_layer(LibraryData_layer_API library) : base(library) { }

        public override void BorrowBook(int userId, int bookId)
        {
            _library.MarkBookAsBorrowed(userId, bookId);
        }

        public override void ReturnBook(int userId, int bookId)
        {
            _library.MarkBookAsReturned(userId, bookId);
        }
    }
}
