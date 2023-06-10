
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPresentationTest.Mock
{
    internal class DataRepositoryMock
    {/*
        public Dictionary<int, IUserDTO> Users = new Dictionary<int, IUserDTO>();

        public Dictionary<int, IBookDTO> Books = new Dictionary<int, IBookDTO>();

        public Dictionary<int, IBorrowingDTO> Borrowings = new Dictionary<int, IBorrowingDTO>();

        public Dictionary<int, IStateDTO> States = new Dictionary<int, IStateDTO>();

        #region User CRUD

        public void AddUser(int userId, string name, string surname)
        {
            this.Users.Add(userId, new UserMock(userId, name, surname));
        }

        public IUserDTO GetUser(int userId)
        {
            return this.Users[userId];
        }

        public Dictionary<int, IUserDTO> GetUsers()
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

        public int GetUsersCount()
        {
            return this.Users.Count;
        }

        #endregion


        #region Book CRUD

        public void AddBook(int bookId, string author, string name)
        {
            this.Books.Add(bookId, new BookMock(bookId, author, name));
        }

        public IBookDTO GetBook(int bookId)
        {
            return this.Books[bookId];
        }

        public Dictionary<int, IBookDTO> GetBooks()
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

        public int GetBooksCount()
        {
            return this.Books.Count;
        }

        #endregion


        #region State CRUD

        public void AddState(int stateId, int bookId, int bookQuantity)
        {
            this.States.Add(stateId, new StateMock(stateId, bookId, bookQuantity));
        }

        public IStateDTO GetState(int stateId)
        {
            return this.States[stateId];
        }

        public Dictionary<int, IStateDTO> GetStates()
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

        public int GetStatesCount()
        {
            return this.States.Count;
        }


        #endregion


        #region Borrowing CRUD

        public void AddBorrowing(int borrowingId, int userId, int stateId, int bookQuantity = 0)
        {
            IUserDTO user = this.GetUser(userId);
            IStateDTO state = this.GetState(stateId);
            IBookDTO book = this.GetBook(state.bookId);

            this.Borrowings.Add(borrowingId, new BorrowingMock(borrowingId, userId, stateId, DateTime.Now, bookQuantity));
        }

        public IBorrowingDTO GetBorrowing(int borrowingId)
        {
            return this.Borrowings[borrowingId];
        }

        public Dictionary<int, IBorrowingDTO> GetBorrowings()
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

        public int GetBorrowingsCount()
        {
            return this.Borrowings.Count;
        }

        #endregion*/
    }
}
