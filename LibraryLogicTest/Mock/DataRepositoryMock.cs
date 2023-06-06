using LibraryData.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLogicTest.Mock
{
    internal class DataRepositoryMock : IDataRepository
    {
        public Dictionary<int, IUser> Users = new Dictionary<int, IUser>();

        public Dictionary<int, IBook> Books = new Dictionary<int, IBook>();

        public Dictionary<int, IBorrowing> Borrowings = new Dictionary<int, IBorrowing>();

        public Dictionary<int, IState> States = new Dictionary<int, IState>();

        #region User CRUD

        public void AddUser(int userId, string name, string surname)
        {
            this.Users.Add(userId, new UserMock(userId, name, surname));
        }

        public IUser GetUser(int userId)
        {
            return this.Users[userId];
        }

        public Dictionary<int, IUser> GetUsers()
        {
            return this.Users;
        }

        public void UpdateUser(int userId, string name, string surname)
        {
            this.Users[userId].Name = name;
            this.Users[userId].Surname = surname;
        }

        public void DeleteUser(int userId)
        {
            this.Users.Remove(userId);
        }

        #endregion


        #region Book CRUD

        public void AddBook(int bookId, string author, string name)
        {
            this.Books.Add(bookId, new BookMock(bookId, author, name));
        }

        public IBook GetBook(int bookId)
        {
            return this.Books[bookId];
        }

        public Dictionary<int, IBook> GetBooks()
        {
            return this.Books;
        }

        public void UpdateBook(int bookId, string author, string name)
        {
            this.Books[bookId].Author = author;
            this.Books[bookId].Name = name;
        }

        public void DeleteBook(int bookId)
        {
            this.Books.Remove(bookId);
        }

        #endregion


        #region State CRUD

        public void AddState(int stateId, int bookId, int bookQuantity)
        {
            this.States.Add(stateId, new StateMock(stateId, bookId, bookQuantity));
        }

        public IState GetState(int stateId)
        {
            return this.States[stateId];
        }

        public Dictionary<int, IState> GetStates()
        {
            return this.States;
        }

        public void UpdateState(int stateId, int bookId, int bookQuantity)
        {
            this.States[stateId].bookId = bookId;
            this.States[stateId].bookQuantity = bookQuantity;
        }

        public void DeleteState(int stateId)
        {
            this.States.Remove(stateId);
        }


        #endregion


        #region Borrowing CRUD

        public void AddBorrowing(int borrowingId, int userId, int stateId, int bookQuantity = 0)
        {
            IUser user = this.GetUser(userId);
            IState state = this.GetState(stateId);
            IBook book = this.GetBook(state.bookId);

            this.Borrowings.Add(borrowingId, new BorrowingMock(borrowingId, userId, stateId, DateTime.Now, bookQuantity));
        }

        public IBorrowing GetBorrowing(int borrowingId)
        {
            return this.Borrowings[borrowingId];
        }

        public Dictionary<int, IBorrowing> GetBorrowings()
        {
            return this.Borrowings;
        }

        public void UpdateBorrowing(int borrowingId, int userId, int stateId, DateTime Date, int? bookQuantity)
        {
            ((BorrowingMock)this.Borrowings[borrowingId]).userId = userId;
            ((BorrowingMock)this.Borrowings[borrowingId]).stateId = stateId;
            ((BorrowingMock)this.Borrowings[borrowingId]).Date = Date;
            ((BorrowingMock)this.Borrowings[borrowingId]).bookQuantity = bookQuantity ?? ((BorrowingMock)this.Borrowings[borrowingId]).bookQuantity;
        }

        public void DeleteBorrowing(int borrowingId)
        {
            this.Borrowings.Remove(borrowingId);
        }

        #endregion
    }
}
