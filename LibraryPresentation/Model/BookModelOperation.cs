using LibraryData.API;
using LibraryLogic.API;
using LibraryPresentation.Model.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPresentation.Model
{
    internal class BookModelOperation : IBookModelOperation
    {
        private IBookCRUD _bookCrud;

        public BookModelOperation(IBookCRUD bookCrud)
        {
            this._bookCrud = bookCrud;
        }

        private IBookModel Map(IBookDTO book)
        {
            return new BookModel(book.Id, book.Author, book.Name);
        }

        public void AddBook(int bookId, string author, string name)
        {
            this._bookCrud.AddBook(bookId, author, name);
        }

        public IBookModel GetBook(int bookId)
        {
            return this.Map(this._bookCrud.GetBook(bookId));
        }

        public Dictionary<int, IBookModel> GetBooks()
        {
            Dictionary<int, IBookModel> books = new Dictionary<int, IBookModel>();

            foreach (IBookDTO book in (this._bookCrud.GetBooks()).Values)
            {
                books.Add(book.Id, this.Map(book));
            }

            return books;
        }

        public void UpdateBook(int bookId, string author, string name)
        {
            this._bookCrud.UpdateBook(bookId, author, name);
        }

        public void DeleteBook(int bookId)
        {
            this._bookCrud.DeleteBook(bookId);
        }
    }
}
