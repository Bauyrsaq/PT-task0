using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData.API
{
    public abstract class IDataRepository
    {
        static IDataRepository CreateDatabase(IDataContext? dataContext = null)
        {
            return new DataRepository(dataContext ?? new DataContext());
        }

        #region User

        public abstract void AddUser(int userId, string name, string surname);
        public abstract IUser? GetUser(int userId);
        public abstract Dictionary<int, IUser> GetUsers();
        public abstract void UpdateUser(int userId, string name, string surname);
        public abstract void DeleteUser(int userId);

        #endregion


        #region Book

        public abstract void AddBook(int bookId, string name);
        public abstract IBook? GetBook(int bookId);
        public abstract Dictionary<int, IBook> GetBooks();
        public abstract void UpdateBook(int bookId, string name);
        public abstract void DeleteBook(int bookId);

        #endregion


        #region State

        public abstract void AddState(int stateId, int bookId, int bookQuantity);
        public abstract IState? GetState(int stateId);
        public abstract Dictionary<int, IState> GetStates();
        public abstract void UpdateState(int stateId, int bookId, int bookQuantity);
        public abstract void DeleteState(int stateId);

        #endregion


        #region Borrowing

        public abstract void AddBorrowing(int borrowingId, int userId, int stateId, DateTime Date, int bookQuantity);
        public abstract IBorrowing? GetBorrowing(int borrowingId);
        public abstract Dictionary<int, IBorrowing> GetBorrowings();
        public abstract void UpdateBorrowing(int borrowingId, int userId, int stateId, DateTime Date, int bookQuantity);
        public abstract void DeleteBorrowing(int borrowingId);

        #endregion
    }
}
