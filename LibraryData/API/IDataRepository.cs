using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData.API
{
    public interface IDataRepository
    {
        static IDataRepository CreateDatabase(IDataContext? dataContext = null)
        {
            return new DataRepository(dataContext ?? new DataContext());
        }

        #region User

        void AddUser(int userId, string name, string surname);
        IUser GetUser(int userId);
        Dictionary<int, IUser> GetUsers();
        void UpdateUser(int userId, string name, string surname);
        void DeleteUser(int userId);
        int GetUsersCount();

        #endregion


        #region Book

        void AddBook(int bookId, string author, string name);
        IBook GetBook(int bookId);
        Dictionary<int, IBook> GetBooks();
        void UpdateBook(int bookId, string author, string name);
        void DeleteBook(int bookId);
        int GetBooksCount();

        #endregion


        #region State

        void AddState(int stateId, int bookId, int bookQuantity);
        IState GetState(int stateId);
        Dictionary<int, IState> GetStates();
        void UpdateState(int stateId, int bookId, int bookQuantity);
        void DeleteState(int stateId);
        int GetStatesCount();

        #endregion


        #region Borrowing

        void AddBorrowing(int borrowingId, int userId, int stateId, int bookQuantity = 0);
        IBorrowing GetBorrowing(int borrowingId);
        Dictionary<int, IBorrowing> GetBorrowings();
        void UpdateBorrowing(int borrowingId, int userId, int stateId, DateTime Date, int? bookQuantity);
        void DeleteBorrowing(int borrowingId);
        int GetBorrowingsCount();

        #endregion
    }
}
