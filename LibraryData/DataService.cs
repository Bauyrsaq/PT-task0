using LibraryData.API;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibraryData
{
    public class DataService
    {
        private DataRepository _dataRepository;

        public DataService(DataRepository dataRepository)
        {
            if (dataRepository == null)
                throw new ArgumentNullException(); 
            this._dataRepository = dataRepository ?? throw new ArgumentNullException(nameof(dataRepository));
        }

        #region User

        public void AddUser(User User)
        {
            _dataRepository.AddUser(User);
        }

        public User? GetUser(int userId)
        {
            return _dataRepository.GetUser(userId);
        }

        public List<User> GetUsers()
        {
            return _dataRepository.GetUsers();
        }

        public void UpdateUser(int userId, User User)
        {
            _dataRepository.UpdateUser(userId, User);
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

        public Book? GetBook(int bookId)
        {
            return _dataRepository.GetBook(bookId);
        }

        public Dictionary<int, Book> GetBooks()
        {
            return _dataRepository.GetBooks();
        }

        public void UpdateBook(int bookId, Book Book)
        {
            _dataRepository.UpdateBook(bookId, Book);
        }

        public void DeleteBook(int bookId)
        {
            _dataRepository.DeleteBook(bookId);
        }

        #endregion


        #region State

        public void AddState(State State)
        {
            _dataRepository.AddState(State);
        }

        public State? GetState(int stateId)
        {
            return _dataRepository.GetState(stateId);
        }

        public List<State> GetStates()
        {
            return _dataRepository.GetStates();
        }

        public void UpdateState(int stateId, State State)
        {
            _dataRepository.UpdateState(stateId, State);
        }

        public void DeleteState(State State)
        {
            _dataRepository.DeleteState(State);
        }

        #endregion


        #region Borrowing

        public void AddBorrowing(int id, int userId, int stateId, int bookQuantity = 0)
        {
            User? user = GetUser(userId);
            State? state = GetState(bookQuantity);
            if (user == null || state == null)
                throw new ArgumentNullException();

            Borrowing tmp = new Borrowing(id, userId, stateId, DateTime.Now.Date, bookQuantity);
            _dataRepository.GetBorrowings().CollectionChanged += OnAddCollectionChanged;
            _dataRepository.AddBorrowing(tmp);
        }

        public Borrowing? GetBorrowing(int userId, int bookId)
        {
            return _dataRepository.GetBorrowing(userId, bookId);
        }

        public ObservableCollection<Borrowing> GetBorrowings()
        {
            return _dataRepository.GetBorrowings();
        }

        public void UpdateBorrowing(int stateId, int userId, int bookId, Borrowing Borrowing)
        {
            _dataRepository.UpdateBorrowing(stateId, bookId, userId, stateId, DateTime.Now.Date, Borrowing.bookQuantity);
        }

        public void DeleteBorrowing(Borrowing Borrowing)
        {
            _dataRepository.GetBorrowings().CollectionChanged += OnDeleteCollectionChanged;
            _dataRepository.DeleteBorrowing(Borrowing);
        }

        public IEnumerable<Borrowing> BorrowingsForBook(Book Book, State State)
        {
            if (Book == null)
                throw new ArgumentNullException();

            State? state = _dataRepository.States.FirstOrDefault(s => s.Id == State.Id);
            if (state == null) throw new ArgumentNullException(); 
            return from events in _dataRepository.GetBorrowings()
                   where state.bookId == Book.Id
                   select events;
        }

        public IEnumerable<Borrowing> BorrowingsBetweenDates(DateTime StartDate, DateTime EndDate)
        {
            return from events in _dataRepository.GetBorrowings()
                   where events.Date.Date >= StartDate.Date && events.Date.Date <= EndDate
                   select events;
        }

        #endregion

        #region Additional functions

        public void OnAddCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Borrowing element in e.NewItems)
                {
                    State? state = _dataRepository.States.FirstOrDefault(s => s.Id == element.stateId);
                    if (state == null) throw new ArgumentNullException();
                    _dataRepository.UpdateState(element.stateId, new State(element.stateId, state.bookId, element.bookQuantity + 1));
                }
            }
        }

        public void OnDeleteCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (Borrowing element in e.OldItems)
                {
                    State? state = _dataRepository.States.FirstOrDefault(s => s.Id == element.stateId);
                    if (state == null) throw new ArgumentNullException();
                    _dataRepository.UpdateState(element.stateId, new State(element.stateId, state.bookId, element.bookQuantity - 1));
                }
            }
        }

        public void PrintRelatedData(IEnumerable<Borrowing> borrowings)
        {
            if (borrowings == null)
                throw new ArgumentNullException();

            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (Borrowing b in borrowings)
            {
                sb.Append("Borrowing " + i + ":");
                sb.Append(b.ToString());
                sb.Append(Environment.NewLine);
                i++;
            }
            Console.WriteLine(sb.ToString(0, sb.Length - 1));
        }

        public void PrintCatalog(IDictionary<int, Book> positions)
        {
            if (positions == null)
                throw new ArgumentNullException();

            StringBuilder sb = new StringBuilder();
            foreach(KeyValuePair<int, Book> p in positions)
            {
                sb.Append(p.Key);
                sb.Append(":");
                sb.Append(p.Value.Id);
                sb.Append(",");
                sb.Append(p.Value.Name);
                sb.Append(Environment.NewLine);
            }
            Console.WriteLine(sb.ToString(0, sb.Length - 1));

        }

        #endregion
    }
}
