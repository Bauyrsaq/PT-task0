using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryData;

using System.Collections.ObjectModel;

namespace LibraryData.API
{
    public interface IDataContext
    { 
        static IDataContext CreateContext(string? connectionString = null)
        {
            return new DataContext(connectionString);
        }

        #region User

        void AddUser(IUser user);
        User? GetUser(int userId);
        Dictionary<int, IUser> GetUsers();
        void UpdateUser(IUser user);
        void DeleteUser(int userId);

        #endregion


        #region Book

        void AddBook(IBook book);
        Book? GetBook(int bookId);
        Dictionary<int, Book> GetBooks();
        void UpdateBook(IBook book);
        void DeleteBook(int bookId);

        #endregion


        #region State

        void AddState(IState state);
        State? GetState(int stateId);
        Dictionary<int, IState> GetStates();
        void UpdateState(IState state);
        void DeleteState(int stateId);

        #endregion


        #region Borrowing

        void AddBorrowing(IBorrowing borrowing);
        Borrowing? GetBorrowing(int borrowingId);
        Dictionary<int, IBorrowing> GetBorrowings();
        void UpdateBorrowing(IBorrowing borrowing);
        void DeleteBorrowing(int borrowingId);

        #endregion
    }
}
