using LibraryData.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLogic.API
{
    public interface IBookCRUD
    {
        static IBookCRUD CreateBookCRUD(IDataRepository? dataRepository = null)
        {
            return new BookCRUD(dataRepository ?? IDataRepository.CreateDatabase());
        }

        void AddBook(int bookId, string author, string name);
        IBookDTO GetBook(int bookId);
        Dictionary<int, IBookDTO> GetBooks();
        void UpdateBook(int bookId, string author, string name);
        void DeleteBook(int bookId);
    }
}
