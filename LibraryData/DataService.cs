using LibraryData.API;
using LibraryData.Database;
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

        public void AddBook(int bookId, string author, string name)
        {
            _dataRepository.AddBook(bookId, author, name);
        }

        public IBook? GetBook(int bookId)
        {
            return _dataRepository.GetBook(bookId);
        }

        public Dictionary<int, IBook> GetBooks()
        {
            return _dataRepository.GetBooks();
        }

        public void UpdateBook(int bookId, string author, string name)
        {
            _dataRepository.UpdateBook(bookId, author, name);
        }

        public void DeleteBook(int bookId)
        {
            _dataRepository.DeleteBook(bookId);
        }

        #endregion


        #region State

        public void AddState(int stateId, int bookId, int bookQuantity)
        {
            _dataRepository.AddState(stateId, bookId, bookQuantity);
        }

        public IState? GetState(int stateId)
        {
            return _dataRepository.GetState(stateId);
        }

        public Dictionary<int, IState> GetStates()
        {
            return _dataRepository.GetStates();
        }

        public void UpdateState(int stateId, int bookId, int bookQuantity)
        {
            _dataRepository.UpdateState(stateId, bookId, bookQuantity);
        }

        public void DeleteState(int stateId)
        {
            _dataRepository.DeleteState(stateId);
        }

        #endregion


        #region Borrowing

        public void AddBorrowing(int borrowingId, int userId, int stateId, int bookQuantity = 0)
        {
            _dataRepository.AddBorrowing(borrowingId, userId, stateId, bookQuantity);
        }

        public IBorrowing? GetBorrowing(int borrowingId)
        {
            return _dataRepository.GetBorrowing(borrowingId);
        }

        public Dictionary<int, IBorrowing> GetBorrowings()
        {
            return _dataRepository.GetBorrowings();
        }

        public void UpdateBorrowing(int borrowingId, int userId, int stateId, int bookQuantity)
        {
            _dataRepository.UpdateBorrowing(borrowingId, userId, stateId, DateTime.Now, bookQuantity);
        }

        public void DeleteBorrowing(int borrowingId)
        {
            _dataRepository.DeleteBorrowing(borrowingId);
        }

        #endregion
    }
}
