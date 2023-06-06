using LibraryData.API;
using LibraryLogic.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLogic
{
    internal class BookCRUD : IBookCRUD
    {
        private IDataRepository _dataRepository;

        public BookCRUD(IDataRepository dataRepository)
        {
            this._dataRepository = dataRepository;
        }

        private IBookDTO Map(IBook book)
        {
            return new BookDTO(book.Id, book.Author, book.Name);
        }

        public void AddBook(int bookId, string author, string name)
        {
            this._dataRepository.AddBook(bookId, author, name);
        }

        public IBookDTO GetBook(int bookId)
        {
            return this.Map(this._dataRepository.GetBook(bookId));
        }

        public Dictionary<int, IBookDTO> GetBooks()
        {
            Dictionary<int, IBookDTO> books = new Dictionary<int, IBookDTO>();

            foreach (IBook book in (this._dataRepository.GetBooks()).Values)
            {
                books.Add(book.Id, this.Map(book));
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
    }
}
