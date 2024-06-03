using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LibraryData.API;

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
                throw new Exception("Doesn't exist");

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
                throw new ArgumentNullException("Doesn't exist");

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

        public override void AddBook(Book Book)
        {
            if (Book == null)
                throw new ArgumentNullException(nameof(Book));
            _context.Books.Add(Book);
            _context.SaveChanges();
        }

        public override Book? GetBook(int bookId)
        {
            try
            {
                return _context.Books.Find(bookId);
            }
            catch(KeyNotFoundException)
            {
                return null;
            }
        }

        public override Dictionary<int, Book> GetBooks()
        {
            return _context.Books.ToDictionary(b => b.Id);
        }

        public override void UpdateBook(int bookId, Book Book)
        {
            if (Book == null)
                throw new ArgumentNullException(nameof(Book));
            var tmp = _context.Books.Find(bookId);
            if (tmp != null)
            {
                tmp.Name = Book.Name;
                _context.SaveChanges();
            }
        }

        public override void DeleteBook(int bookId)
        {
            var book = _context.Books.Find(bookId);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        #endregion


        #region State

        public override void AddState(State State)
        {
            if (State == null)
                throw new ArgumentNullException(nameof(State));
            _context.States.Add(State);
            _context.SaveChanges();
        }

        public override State? GetState(int stateId)
        {
            return _context.States.Find(stateId);
        }

        public override List<State> GetStates()
        {
            return _context.States.ToList();
        }

        public override void UpdateState(int stateId, State State)
        {
            if (State == null)
                throw new ArgumentNullException(nameof(State));
            var tmp = _context.States.Find(stateId);
            if (tmp != null)
            {
                tmp.bookId = State.bookId;
                tmp.bookQuantity = State.bookQuantity;
                _context.SaveChanges();
            }
        }

        public override void DeleteState(State State)
        {
            if (State == null) throw new ArgumentNullException(nameof(State));
            _context.States.Remove(State);
            _context.SaveChanges();
        }

        #endregion


        #region Borrowing

        public override void AddBorrowing(Borrowing Borrowing)
        {
            if (Borrowing.bookQuantity < 1)
                throw new Exception("Empty");
            else
                Borrowing.bookQuantity -= 1;

            if (Borrowing == null)
                throw new ArgumentNullException(nameof(Borrowing));
            _context.Borrowings.Add(Borrowing);
            _context.SaveChanges();
        }

        public override Borrowing? GetBorrowing(int userId, int bookId)
        {
            try
            {
                var borrowing = _context.Borrowings
                    .Join(
                        _context.States,
                        borrowing => borrowing.stateId,
                        state => state.Id,
                        (borrowing, state) => new { Borrowing = borrowing, State = state }
                    )
                    .FirstOrDefault(joined => joined.Borrowing.userId == userId && joined.State.bookId == bookId)?.Borrowing;

                return borrowing;
            }
            catch
            {
                return null;
            }
        }

        public override ObservableCollection<Borrowing> GetBorrowings()
        {
            return new ObservableCollection<Borrowing>(_context.Borrowings.ToList());
        }

        public override void UpdateBorrowing(int id, int bookId, int userId, int stateId, DateTime Date, int bookQuantity)
        {
            var tmp = _context.Borrowings.Find(id);
            if (tmp != null)
            {
                tmp.userId = userId;
                tmp.stateId = stateId;
                tmp.Date = Date;
                tmp.bookQuantity = bookQuantity;
                _context.SaveChanges();
            }
        }

        public override void DeleteBorrowing(Borrowing Borrowing)
        {
            if (Borrowing == null)
                throw new ArgumentNullException(nameof(Borrowing));
            _context.Borrowings.Remove(Borrowing);
            _context.SaveChanges();
        }

        #endregion
    }
}
