using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryData.API;

namespace LibraryData
{
    public class DataRepository : IDataRepository
    {
        

        #region User

        public override void AddUser(User User) 
        {
            if (User != null)
                Users.Add(User);
            else
                throw new ArgumentNullException();
        }

        public override User GetUser(int UserID) 
        {
            try 
            {
                return Users.Find(x => x.UserID == UserID);
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

        public override void UpdateUser(int UserID, User User)
        {
            if (User  == null)
                throw new ArgumentNullException();

            User tmp = Users.First(x => x.UserID == UserID);
            if (tmp != null)
            {
                tmp.UserID = User.UserID;
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

        public override void AddBook(Book Book) { return; }

        public override Book GetBook(int BookID) { return null; }

        public override Dictionary<int, Book> GetBooks() { return null; }

        public override void UpdateBook(int BookID, Book Catalog) { return; }

        public override void DeleteBook(int BookID) { return; }

        #endregion


        #region State

        public override void AddState(State State) { return; }

        public override State GetState(int BookID) { return null; }

        public override List<State> GetStates() { return null; }

        public override void UpdateState(int BookID, State State) { return; }

        public override void DeleteState(State State) { return; }

        #endregion


        #region Borrowing

        public override void AddBorrowing(Borrowing Borrowing) { return; }

        public override Borrowing GetBorrowing(int UserID, int BookID) { return null; }

        public override ObservableCollection<Borrowing> GetBorrowings() { return null; }

        public override void UpdateBorrowing(int UserID, int BookID, Borrowing Borrowing) { return; }

        public override void DeleteBorrowing(int UserID) { return; }

        #endregion
    }
}
