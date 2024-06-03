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
        public List<User> Users = new List<User>();
        public Dictionary<int, Book> Catalog = new Dictionary<int, Book>();
        public List<State> States = new List<State>();
        public ObservableCollection<Borrowing> Borrowings = new ObservableCollection<Borrowing>();


        #region User

        public override void AddUser(User User) 
        {
            if (User != null)
                Users.Add(User);
            else
                throw new ArgumentNullException();
        }

        public override User? GetUser(int userId) 
        {
            try 
            {
                return Users.Find(x => x.Id == userId);
            }
            catch(KeyNotFoundException)
            {
                return null;
            }
        }

        public override List<User> GetUsers()
        {
            return Users;
        }

        public override void UpdateUser(int userId, User User)
        {
            if (User  == null)
                throw new ArgumentNullException();

            User tmp = Users.First(x => x.Id == userId);
            if (tmp != null)
            {
                tmp.Id = User.Id;
                tmp.Name = User.Name;
                tmp.Surname = User.Surname;
            }
        }

        public override void DeleteUser(User User)
        {
            Users.Remove(User);
        }

        #endregion


        #region Book

        public override void AddBook(Book Book)
        {
            if (Book != null)
                Catalog.Add(Book.Id, Book);
            else
                throw new ArgumentNullException();
        }

        public override Book? GetBook(int bookId)
        {
            try
            {
                return Catalog[bookId];
            }
            catch(KeyNotFoundException)
            {
                return null;
            }
        }

        public override Dictionary<int, Book> GetBooks()
        {
            return Catalog;
        }

        public override void UpdateBook(int bookId, Book Book)
        {
            if (Book != null)
                Catalog[bookId] = Book;
            else
                throw new ArgumentNullException();
        }

        public override void DeleteBook(int bookId)
        {
            Catalog.Remove(bookId);
        }

        #endregion


        #region State

        public override void AddState(State State)
        {
            if (State != null)
                States.Add(State);
            else
                throw new ArgumentNullException();
        }

        public override State? GetState(int stateId)
        {
            return States.Find(x => x.Id == stateId);
        }

        public override List<State> GetStates()
        {
            return States;
        }

        public override void UpdateState(int stateId, State State)
        {
            if (State != null)
                States[stateId] = State;
            else
                throw new ArgumentNullException();
        }

        public override void DeleteState(State State)
        {
            States.Remove(State);
        }

        #endregion


        #region Borrowing

        public override void AddBorrowing(Borrowing Borrowing)
        {
            if (Borrowing.bookQuantity < 1)
                throw new Exception("Empty");
            else
                Borrowing.bookQuantity -= 1;

            if (Borrowing != null)
                Borrowings.Add(Borrowing);
            else
                throw new ArgumentNullException();
        }

        public override Borrowing? GetBorrowing(int userId, int bookId)
        {
            try
            {
                return Borrowings.FirstOrDefault(b =>
                {
                    State? state = States.FirstOrDefault(s => s.Id == b.stateId);
                    return b.userId == userId && state != null && state.bookId == bookId;
                });
            }
            catch
            {
                return null;
            }
        }

        public override ObservableCollection<Borrowing> GetBorrowings()
        {
            return Borrowings;
        }

        public override void UpdateBorrowing(int id, int bookId, int userId, int stateId, DateTime Date, int bookQuantity)
        {
            Borrowing? tmp = this.GetBorrowing(userId, bookId);
            if (tmp != null)
            {
                tmp.Id = id;
                tmp.userId = userId;
                tmp.stateId = stateId;
                tmp.Date = Date;
                tmp.bookQuantity = bookQuantity;
            }
        }

        public override void DeleteBorrowing(Borrowing Borrowing)
        {
            Borrowings.Remove(Borrowing);
        }

        #endregion
    }
}
