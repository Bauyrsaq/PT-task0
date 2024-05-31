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
        public List<User> Users = new List<User>();
        public Dictionary<int, Book> Catalog = new Dictionary<int, Book>();
        public List<State> States = new List<State>();
        public ObservableCollection<Borrowing> Borrowings = new ObservableCollection<Borrowing>();

        #region User

        public abstract void AddUser(User User);
        public abstract User GetUser(int UserID);
        public abstract List<User> GetUsers();
        public abstract void UpdateUser(int UserID, User User);
        public abstract void DeleteUser(User User);

        #endregion


        #region Book

        public abstract void AddBook(Book Catalog);
        public abstract Book GetBook(int BookID);
        public abstract Dictionary<int, Book> GetBooks();
        public abstract void UpdateBook(int BookID, Book Catalog);
        public abstract void DeleteBook(int BookID);

        #endregion


        #region State

        public abstract void AddState(State State);
        public abstract State GetState(int BookID);
        public abstract List<State> GetStates();
        public abstract void UpdateState(int BookID, State State);
        public abstract void DeleteState(State State);

        #endregion


        #region Borrowing

        public abstract void AddBorrowing(Borrowing Borrowing);
        public abstract Borrowing GetBorrowing(int UserID, int BookID);
        public abstract ObservableCollection<Borrowing> GetBorrowings();
        public abstract void UpdateBorrowing(int UserID, int BookID, Borrowing Borrowing);
        public abstract void DeleteBorrowing(int UserID);

        #endregion
    }
}
