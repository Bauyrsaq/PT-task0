using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData.API
{
    public interface IDataService
    {
        #region User

        public abstract void AddUser(int userId, string name, string surname);
        public abstract IUser? GetUser(int userId);
        public abstract Dictionary<int, IUser> GetUsers();
        public abstract void UpdateUser(int userId, string name, string surname);
        public abstract void DeleteUser(int userId);

        #endregion


        #region Book

        public abstract void AddBook(Book Book);
        public abstract Book? GetBook(int bookId);
        public abstract Dictionary<int, Book> GetBooks();
        public abstract void UpdateBook(int bookId, Book Book);
        public abstract void DeleteBook(int bookId);

        #endregion


        #region State

        public abstract void AddState(State State);
        public abstract State? GetState(int stateId);
        public abstract List<State> GetStates();
        public abstract void UpdateState(int stateId, State State);
        public abstract void DeleteState(State State);

        #endregion


        #region Borrowing

        public abstract void AddBorrowing(Borrowing Borrowing);
        public abstract Borrowing? GetBorrowing(int userId, int bookId);
        public abstract ObservableCollection<Borrowing> GetBorrowings();
        public abstract void UpdateBorrowing(int id, int bookId, int userId, int stateId, DateTime Date, int bookQuantity);
        public abstract void DeleteBorrowing(Borrowing Borrowing);

        #endregion
    }
}
