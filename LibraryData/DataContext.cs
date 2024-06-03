using LibraryData.API;
using LibraryData.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData
{
    public class DataContext : IDataContext
    {
        private readonly string ConnectionString;

        public DataContext(string? connectionString = null)
        {
            if (connectionString is null)
            {
                string _projectRootDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                string _DBRelativePath = @"Database\LibraryDB.mdf";
                string _DBPath = Path.Combine(_projectRootDir, _DBRelativePath);
                this.ConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={_DBPath};Integrated Security = True; Connect Timeout = 30;";
            }
            else
            {
                this.ConnectionString = connectionString;
            }
        }

        #region User

        public void AddUser(IUser user)
        {
            using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
            {
                Database.User entity = new Database.User()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                };

                context.Users.InsertOnSubmit(entity);
                context.SubmitChanges();
            }
        }

        public User? GetUser(int userId)
        {
            using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
            {
                IQueryable<Database.User> query =
                    from u in context.Users
                    where u.Id == userId
                    select u;

                Database.User? user = query.FirstOrDefault();

                return user is not null ? new User(user.Id, user.Name, user.Surname) : null;
            }
        }

        public Dictionary<int, IUser> GetUsers()
        {
            using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
            {
                IQueryable<IUser> query =
                    from u in context.Users
                    select new User(u.Id, u.Name, u.Surname) as IUser;

                return query.ToDictionary(k => k.Id);
            }
        }

        public void UpdateUser(IUser user)
        {
            using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
            {
                Database.User toUpdate = (from u in context.Users where u.Id == user.Id select u).FirstOrDefault()!;

                toUpdate.Name = user.Name;
                toUpdate.Surname = user.Surname;

                context.SubmitChanges();
            }
        }

        public void DeleteUser(int userId)
        {
            using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
            {
                Database.User toDelete = (from u in context.Users where u.Id == userId select u).FirstOrDefault()!;

                context.Users.DeleteOnSubmit(toDelete);

                context.SubmitChanges();
            }
        }

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
        List<State> GetStates();
        void UpdateState(IState state);
        void DeleteState(int stateId);

        #endregion


        #region Borrowing

        void AddBorrowing(IBorrowing borrowing);
        Borrowing? GetBorrowing(int borrowingId);
        ObservableCollection<Borrowing> GetBorrowings();
        void UpdateBorrowing(IBorrowing borrowing);
        void DeleteBorrowing(int borrowingId);

        #endregion
    }
}
