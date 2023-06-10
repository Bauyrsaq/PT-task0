using LibraryData.API;
using LibraryData.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData
{
    internal class DataContext : IDataContext
    {
        private readonly string ConnectionString;

        public DataContext(string? connectionString = null)
        {
            if (connectionString is null)
            {
                string _projectRootDir = Environment.CurrentDirectory;
                string _DBRelativePath = @"Database\LibraryDB.mdf";
                string _DBPath = Path.Combine(_projectRootDir, _DBRelativePath);
                //string _DBPath = @"E:\Library\PT_Task1\LibraryDataTest\LibraryDBTest.mdf";
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

        public IUser? GetUser(int userId)
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

        public int GetUsersCount()
        {
            using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
            {
                return context.Users.Count();
            }
        }

        #endregion


        #region Book

        public void AddBook(IBook book)
        {
            using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
            {
                Database.Book entity = new Database.Book()
                {
                    Id = book.Id,
                    Author = book.Author,
                    Name = book.Name,
                };

                context.Books.InsertOnSubmit(entity);
                context.SubmitChanges();
            }
        }

        public IBook? GetBook(int bookId)
        {
            using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
            {
                IQueryable<Database.Book> query =
                    from b in context.Books
                    where b.Id == bookId
                    select b;

                Database.Book? book = query.FirstOrDefault();

                return book is not null ? new Book(book.Id, book.Author, book.Name) : null;
            }
        }

        public Dictionary<int, IBook> GetBooks()
        {
            using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
            {
                IQueryable<IBook> query =
                    from b in context.Books
                    select new Book(b.Id, b.Author, b.Name) as IBook;

                return query.ToDictionary(k => k.Id);
            }
        }

        public void UpdateBook(IBook book)
        {
            using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
            {
                Database.Book toUpdate = (from b in context.Books where b.Id == book.Id select b).FirstOrDefault()!;

                toUpdate.Author = book.Author;
                toUpdate.Name = book.Name;

                context.SubmitChanges();
            }
        }

        public void DeleteBook(int bookId)
        {
            using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
            {
                Database.Book toDelete = (from b in context.Books where b.Id == bookId select b).FirstOrDefault()!;

                context.Books.DeleteOnSubmit(toDelete);

                context.SubmitChanges();
            }
        }

        public int GetBooksCount()
        {
            using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
            {
                return context.Books.Count();
            }
        }

        #endregion


        #region State

        public void AddState(IState state)
        {
            using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
            {
                Database.State entity = new Database.State()
                {
                    Id = state.Id,
                    bookId = state.bookId,
                    bookQuantity = state.bookQuantity,
                };

                context.States.InsertOnSubmit(entity);
                context.SubmitChanges();
            }
        }

        public IState? GetState(int stateId)
        {
            using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
            {
                IQueryable<Database.State> query =
                    from s in context.States
                    where s.Id == stateId
                    select s;

                Database.State? state = query.FirstOrDefault();

                return state is not null ? new State(state.Id, state.bookId, state.bookQuantity) : null;
            }
        }

        public Dictionary<int, IState> GetStates()
        {
            using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
            {
                IQueryable<IState> query =
                    from s in context.States
                    select new State(s.Id, s.bookId, s.bookQuantity) as IState;

                return query.ToDictionary(k => k.Id);
            }
        }

        public void UpdateState(IState state)
        {
            using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
            {
                Database.State toUpdate = (from s in context.States where s.Id == state.Id select s).FirstOrDefault()!;

                toUpdate.bookId = state.bookId;
                toUpdate.bookQuantity = state.bookQuantity;

                context.SubmitChanges();
            }
        }

        public void DeleteState(int stateId)
        {
            using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
            {
                Database.State toDelete = (from s in context.States where s.Id == stateId select s).FirstOrDefault()!;

                context.States.DeleteOnSubmit(toDelete);

                context.SubmitChanges();
            }
        }

        public int GetStatesCount()
        {
            using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
            {
                return context.States.Count();
            }
        }

        #endregion


        #region Borrowing

        public void AddBorrowing(IBorrowing borrowing)
        {
            using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
            {
                Database.Borrowing entity = new Database.Borrowing()
                {
                    Id = borrowing.Id,
                    userId = borrowing.userId,
                    stateId = borrowing.stateId,
                    Date = borrowing.Date,
                    bookQuantity = borrowing.bookQuantity,
                };

                context.Borrowings.InsertOnSubmit(entity);
                context.SubmitChanges();
            }
        }

        public IBorrowing? GetBorrowing(int borrowingId)
        {
            using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
            {
                IQueryable<Database.Borrowing> query =
                    from b in context.Borrowings
                    where b.Id == borrowingId
                    select b;

                Database.Borrowing? borrowing = query.FirstOrDefault();

                return borrowing is not null ? new Borrowing(borrowing.Id, borrowing.userId, borrowing.stateId, borrowing.Date, borrowing.bookQuantity) : null;
            }
        }

        public Dictionary<int, IBorrowing> GetBorrowings()
        {
            using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
            {
                IQueryable<IBorrowing> query =
                    from b in context.Borrowings
                    select new Borrowing(b.Id, b.userId, b.stateId, b.Date, b.bookQuantity) as IBorrowing;

                return query.ToDictionary(k => k.Id);
            }
        }

        public void UpdateBorrowing(IBorrowing borrowing)
        {
            using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
            {
                Database.Borrowing toUpdate = (from b in context.Borrowings where b.Id == borrowing.Id select b).FirstOrDefault()!;

                toUpdate.userId = borrowing.userId;
                toUpdate.stateId = borrowing.stateId;
                toUpdate.Date = borrowing.Date;
                toUpdate.bookQuantity = borrowing.bookQuantity;

                context.SubmitChanges();
            }
        }

        public void DeleteBorrowing(int borrowingId)
        {
            using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
            {
                Database.Borrowing toDelete = (from b in context.Borrowings where b.Id == borrowingId select b).FirstOrDefault()!;

                context.Borrowings.DeleteOnSubmit(toDelete);

                context.SubmitChanges();
            }
        }

        public int GetBorrowingsCount()
        {
            using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
            {
                return context.Borrowings.Count();
            }
        }

        #endregion
    }
}
