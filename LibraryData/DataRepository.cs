using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LibraryData.API;
using LibraryData.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibraryData
{
    public class DataRepository : IDataRepository
    {
        private IDataContext _context;

        public DataRepository(IDataContext context)
        {
            this._context = context;
        }

        #region User

        public override void AddUser(int userId, string name, string surname) 
        {
            IUser user = new User(userId, name, surname);
            _context.AddUser(user);
        }

        public override IUser? GetUser(int userId) 
        {
            IUser? user = this._context.GetUser(userId);

            if (user is null)
                throw new Exception("User doesn't exist");

            return user;
        }

        public override Dictionary<int, IUser> GetUsers()
        {
            return _context.GetUsers();
        }

        public override void UpdateUser(int userId, string name, string surname)
        {

            IUser user = new User(userId, name, surname);

            if (this.GetUser(userId) == null)
                throw new ArgumentNullException("User doesn't exist");

            this._context.UpdateUser(user);
        }

        public override void DeleteUser(int userId)
        {
            if (this.GetUser(userId) == null)
                throw new ArgumentNullException(nameof(User));

            this._context.DeleteUser(userId);
        }

        #endregion


        #region Book

        public override void AddBook(int bookId, string name)
        {
            IBook book = new Book(bookId, name);
            _context.AddBook(book);
        }

        public override IBook? GetBook(int bookId)
        {
            IBook? book = this._context.GetBook(bookId);

            if (book is null)
                throw new Exception("Book doesn't exist");

            return book;
        }

        public override Dictionary<int, IBook> GetBooks()
        {
            return _context.GetBooks();
        }

        public override void UpdateBook(int bookId, string name)
        {
            IBook book = new Book(bookId, name);

            if (this.GetBook(bookId) == null)
                throw new ArgumentNullException("Book doesn't exist");

            this._context.UpdateBook(book);
        }

        public override void DeleteBook(int bookId)
        {
            if (this.GetBook(bookId) == null)
                throw new ArgumentNullException(nameof(Book));

            this._context.DeleteBook(bookId);
        }

        #endregion


        #region State

        public override void AddState(int stateId, int bookId, int bookQuantity)
        {
            if (this.GetState(stateId) == null)
                throw new Exception("State doesn't exist");

            if (bookQuantity <= 0)
                throw new Exception("Books quantity must be graete than 0");

            IState state = new State(stateId, bookId, bookQuantity);
            _context.AddState(state);
        }

        public override IState? GetState(int stateId)
        {
            IState? state = this._context.GetState(stateId);

            if (state is null)
                throw new Exception("State doesn't exist");

            return state;
        }

        public override Dictionary<int, IState> GetStates()
        {
            return _context.GetStates();
        }

        public override void UpdateState(int stateId, int bookId, int bookQuantity)
        {
            if (this.GetState(stateId) == null)
                throw new Exception("State doesn't exist");

            if (bookQuantity <= 0)
                throw new Exception("Books quantity must be graete than 0");

            IState state = new State(stateId, bookId, bookQuantity);

            if (this.GetState(stateId) == null)
                throw new ArgumentNullException("State doesn't exist");

            this._context.UpdateState(state);
        }

        public override void DeleteState(int stateId)
        {
            if (this.GetState(stateId) == null)
                throw new ArgumentNullException("State doesn't exist");

            this._context.DeleteState(stateId);
        }

        #endregion


        #region Borrowing

        public override void AddBorrowing(int borrowingId, int userId, int stateId, DateTime Date, int bookQuantity)
        {
            IBorrowing borrowing = new Borrowing(borrowingId, userId, stateId, Date, bookQuantity);
            _context.AddBorrowing(borrowing);
        }

        public override IBorrowing? GetBorrowing(int borrowingId)
        {
            IBorrowing? borrowing = this._context.GetBorrowing(borrowingId);

            if (borrowing is null)
                throw new Exception("Borrowing doesn't exist");

            return borrowing;
        }

        public override Dictionary<int, IBorrowing> GetBorrowings()
        {
            return _context.GetBorrowings();
        }

        public override void UpdateBorrowing(int borrowingId, int userId, int stateId, DateTime Date, int bookQuantity)
        {
            IBorrowing borrowing = new Borrowing(borrowingId, userId, stateId, Date, bookQuantity);

            if (this.GetBorrowing(borrowingId) == null)
                throw new ArgumentNullException("Borrowing doesn't exist");

            this._context.UpdateBorrowing(borrowing);
        }

        public override void DeleteBorrowing(int borrowingId)
        {
            if (this.GetBorrowing(borrowingId) == null)
                throw new ArgumentNullException("Borrowing doesn't exist");

            this._context.DeleteState(borrowingId);
        }

        #endregion
    }
}
