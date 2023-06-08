using LibraryLogic.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPresentation.Model.API
{
    public interface IBookModelOperation
    {
        static IBookModelOperation CreateModelOperation(IBookCRUD? bookCrud = null)
        {
            return new BookModelOperation(bookCrud ?? IBookCRUD.CreateBookCRUD());
        }

        void AddBook(int bookId, string author, string name);
        IBookModel GetBook(int bookId);
        Dictionary<int, IBookModel> GetBooks();
        void UpdateBook(int bookId, string author, string name);
        void DeleteBook(int bookId);
        int GetBooksCount();
    }
}
