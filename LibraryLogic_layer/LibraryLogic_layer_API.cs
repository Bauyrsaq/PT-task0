using Data_layer_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_layer_API
{
    public abstract class LibraryLogic_layer_API
    {
        protected LibraryData_layer_API _library;

        protected LibraryLogic_layer_API(LibraryData_layer_API library)
        {
            _library = library;
        }

        public abstract void BorrowBook(int userId, int bookId);
        public abstract void ReturnBook(int userId, int bookId);
    }
}
