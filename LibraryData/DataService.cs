using LibraryData.API;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibraryData
{
    public class DataService : IDataService
    {
        private readonly IDataRepository _dataRepository;

        public DataService(IDataRepository dataRepository)
        {
            if (dataRepository == null)
                throw new ArgumentNullException(); 
            _dataRepository = dataRepository;
        }

        #region User

        public void AddUser(int userId, string name, string surname)
        {
            _dataRepository.AddUser(userId, name, surname);
        }

        public IUser? GetUser(int userId)
        {
            return _dataRepository.GetUser(userId);
        }

        public Dictionary<int, IUser> GetUsers()
        {
            return _dataRepository.GetUsers();
        }

        public void UpdateUser(int userId, string name, string surname)
        {
            _dataRepository.UpdateUser(userId, name, surname);
        }

        public void DeleteUser(int userId)
        {
            _dataRepository.DeleteUser(userId);
        }

        #endregion


        #region Book

        public void AddBook(string name)
        {
            var book = new Book
            {
                Name = name
            };
            _dataRepository.AddBook(book);
        }

        public Book? GetBook(int bookId)
        {
            return _dataRepository.GetBook(bookId);
        }

        public Dictionary<int, Book> GetBooks()
        {
            return _dataRepository.GetBooks();
        }

        public void UpdateBook(int bookId, string name)
        {
            var book = _dataRepository.GetBook(bookId);
            if (book != null)
            {
                book.Name = name;
                _dataRepository.UpdateBook(bookId, book);
            }
        }

        public void DeleteBook(int bookId)
        {
            _dataRepository.DeleteBook(bookId);
        }

        #endregion


        #region State

        public void AddState(int bookId, int bookQuantity)
        {
            var state = new State
            {
                bookId = bookId,
                bookQuantity = bookQuantity
            };
            _dataRepository.AddState(state);
        }

        public State? GetState(int stateId)
        {
            return _dataRepository.GetState(stateId);
        }

        public List<State> GetStates()
        {
            return _dataRepository.GetStates();
        }

        public void UpdateState(int stateId, int bookId, int bookQuantity)
        {
            var state = _dataRepository.GetState(stateId);
            if (state != null)
            {
                state.bookId = bookId;
                state.bookQuantity = bookQuantity;
                _dataRepository.UpdateState(stateId, state);
            }
        }

        public void DeleteState(int stateId)
        {
            var state = _dataRepository.GetState(stateId);
            if (state != null)
            {
                _dataRepository.DeleteState(state);
            }
        }

        #endregion


        #region Borrowing

        public void AddBorrowing(int userId, int stateId, DateTime date, int bookQuantity = 0)
        {
            var borrowing = new Borrowing
            {
                userId = userId,
                stateId = stateId,
                Date = date,
                bookQuantity = bookQuantity
            };
            _dataRepository.AddBorrowing(borrowing);
        }

        public Borrowing? GetBorrowing(int userId, int bookId)
        {
            return _dataRepository.GetBorrowing(userId, bookId);
        }

        public ObservableCollection<Borrowing> GetBorrowings()
        {
            return _dataRepository.GetBorrowings();
        }

        public void UpdateBorrowing(int id, int bookId, int userId, int stateId, DateTime date, int bookQuantity)
        {
            _dataRepository.UpdateBorrowing(id, bookId, userId, stateId, DateTime.Now.Date, bookQuantity);
        }

        public void DeleteBorrowing(int userId, int bookId)
        {
            var borrowing = _dataRepository.GetBorrowing(userId, bookId);
            if (borrowing != null)
            {
                _dataRepository.DeleteBorrowing(borrowing);
            }
        }

        #endregion
    }
}
