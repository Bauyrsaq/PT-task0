using LibraryLogic.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPresentationTest.Mock
{
    internal class BookCRUDMock : IBookCRUD
    {
        private readonly DataRepositoryMock _dataRepository = new DataRepositoryMock();

        public BookCRUDMock()
        {
            
        }

        public void AddBook(int bookId, string author, string name)
        {
            this._dataRepository.AddBook(bookId, author, name);
        }

        public IBookDTO GetBook(int bookId)
        {
            return this._dataRepository.GetBook(bookId);
        }

        public Dictionary<int, IBookDTO> GetBooks()
        {
            Dictionary<int, IBookDTO> books = new Dictionary<int, IBookDTO>();

            foreach (IBookDTO book in (this._dataRepository.GetBooks()).Values)
            {
                books.Add(book.Id, book);
            }

            return books;
        }

        public void UpdateBook(int bookId, string author, string name)
        {
            this._dataRepository.UpdateBook(bookId, author, name);
        }

        public void DeleteBook(int bookId)
        {
            this._dataRepository.DeleteBook(bookId);
        }

        public int GetBooksCount()
        {
            return this._dataRepository.GetBooksCount();
        }
    }
}
