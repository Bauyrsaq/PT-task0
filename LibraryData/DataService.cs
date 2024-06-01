﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData
{
    public class DataService
    {
        private DataRepository _dataRepository = null;

        public DataService(DataRepository dataRepository)
        {
            if (dataRepository == null)
                throw new ArgumentNullException(); 
            this._dataRepository = dataRepository ;
        }

        #region User

        public void AddUser(User User)
        {
            _dataRepository.AddUser(User);
        }

        public User GetUser(int UserID)
        {
            return _dataRepository.GetUser(UserID);
        }

        public List<User> GetUsers()
        {
            return _dataRepository.GetUsers();
        }

        public void UpdateUser(int UserID, User User)
        {
            _dataRepository.UpdateUser(UserID, User);
        }

        public void DeleteUser(User User)
        {
            _dataRepository.DeleteUser(User);
        }

        #endregion


        #region Book

        public void AddBook(Book Book)
        {
            _dataRepository.AddBook(Book);
        }

        public Book GetBook(int BookID)
        {
            return _dataRepository.GetBook(BookID);
        }

        public Dictionary<int, Book> GetBooks()
        {
            return _dataRepository.GetBooks();
        }

        public void UpdateBook(int BookID, Book Book)
        {
            _dataRepository.UpdateBook(BookID, Book);
        }

        public void DeleteBook(int BookID)
        {
            _dataRepository.DeleteBook(BookID);
        }

        #endregion


        #region State

        public void AddState(State State)
        {
            _dataRepository.AddState(State);
        }

        public State GetState(int BookID)
        {
            return _dataRepository.GetState(BookID);
        }

        public List<State> GetStates()
        {
            return _dataRepository.GetStates();
        }

        public void UpdateState(int BookID, State State)
        {
            _dataRepository.UpdateState(BookID, State);
        }

        public void DeleteState(State State)
        {
            _dataRepository.DeleteState(State);
        }

        #endregion


        #region Borrowing

        public void AddBorrowing(User User, State State)
        {
            if (User == null || State == null)
                throw new ArgumentNullException();

            Borrowing tmp = new Borrowing(User, DateTime.Now.Date, State);
            _dataRepository.GetBorrowings().CollectionChanged += OnAddCollectionChanged;
            _dataRepository.AddBorrowing(tmp);
        }

        public Borrowing GetBorrowing(int UserID, int BookID)
        {
            return _dataRepository.GetBorrowing(UserID, BookID);
        }

        public ObservableCollection<Borrowing> GetBorrowings()
        {
            return _dataRepository.GetBorrowings();
        }

        public void UpdateBorrowing(int UserID, int BookID, Borrowing Borrowing)
        {
            _dataRepository.UpdateBorrowing(UserID, BookID, Borrowing);
        }

        public void DeleteBorrowing(Borrowing Borrowing)
        {
            _dataRepository.GetBorrowings().CollectionChanged += OnDeleteCollectionChanged;
            _dataRepository.DeleteBorrowing(Borrowing);
        }

        #endregion

        #region Additional functions

        public void OnAddCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Borrowing element in e.NewItems)
                {
                    _dataRepository.UpdateState(element.State.Book.BookID, new State(element.State.Book, element.State.Quantity - 1));
                }
            }
        }

        public void OnDeleteCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (Borrowing element in e.OldItems)
                {
                    _dataRepository.UpdateState(element.State.Book.BookID, new State(element.State.Book, element.State.Quantity + 1));
                }
            }
        }

        #endregion
    }
}
