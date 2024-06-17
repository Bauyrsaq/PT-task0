using LibraryPresentation.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace LibraryPresentation.ViewModel
{
    internal class BookMasterViewModel : IViewModel, IBookMasterViewModel
    {
        public ICommand SwitchToUserMasterPage { get; set; }

        public ICommand SwitchToStateMasterPage { get; set; }

        public ICommand SwitchToBorrowingMasterPage { get; set; }

        public ICommand CreateBook { get; set; }

        public ICommand RemoveBook { get; set; }

        private readonly IBookModelOperation _modelOperation;

        

        private ObservableCollection<IBookDetailViewModel> _books;

        public ObservableCollection<IBookDetailViewModel> Books
        {
            get => _books;
            set
            {
                _books = value;
                OnPropertyChanged(nameof(Books));
            }
        }

        private string _author;

        public string Author
        {
            get => _author;
            set
            {
                _author = value;
                OnPropertyChanged(nameof(Author));
            }
        }

        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private bool _isBookSelected;

        public bool IsBookSelected
        {
            get => _isBookSelected;
            set
            {
                this.IsBookDetailVisible = value ? Visibility.Visible : Visibility.Hidden;

                _isBookSelected = value;
                OnPropertyChanged(nameof(IsBookSelected));
            }
        }

        private Visibility _isBookDetailVisible;

        public Visibility IsBookDetailVisible
        {
            get => _isBookDetailVisible;
            set
            {
                _isBookDetailVisible = value;
                OnPropertyChanged(nameof(IsBookDetailVisible));
            }
        }

        private IBookDetailViewModel _selectedDetailViewModel;

        public IBookDetailViewModel SelectedDetailViewModel
        {
            get => _selectedDetailViewModel;
            set
            {
                _selectedDetailViewModel = value;
                this.IsBookSelected = true;

                OnPropertyChanged(nameof(SelectedDetailViewModel));
            }
        }

        public BookMasterViewModel(IBookModelOperation? model = null)
        {
            this.SwitchToUserMasterPage = new SwitchViewCommand("UserMasterView");
            this.SwitchToStateMasterPage = new SwitchViewCommand("StateMasterView");
            this.SwitchToBorrowingMasterPage = new SwitchViewCommand("BorrowingMasterView");

            this.CreateBook = new OnClickCommand(e => this.StoreBook(), c => this.CanStoreBook());
            this.RemoveBook = new OnClickCommand(e => this.DeleteBook());

            this.Books = new ObservableCollection<IBookDetailViewModel>();

            this._modelOperation = model ?? IBookModelOperation.CreateModelOperation();
            

            this.IsBookSelected = false;

            this.LoadBooks();
        }

        private bool CanStoreBook()
        {
            return !(
                string.IsNullOrWhiteSpace(this.Author) ||
                string.IsNullOrWhiteSpace(this.Name)
            );
        }

        private void StoreBook()
        {
            int lastId = this._modelOperation.GetBooksCount() + 1;

            this._modelOperation.AddBook(lastId, this.Author, this.Name);


            this.LoadBooks();
        }

        private void DeleteBook()
        {
            try
            {
                this._modelOperation.DeleteBook(this.SelectedDetailViewModel.Id);


                this.LoadBooks();
            }
            catch (Exception e)
            {
            }
        }

        private void LoadBooks()
        {
            Dictionary<int, IBookModel> Books = this._modelOperation.GetBooks();

            this._books.Clear();

            foreach (IBookModel b in Books.Values)
            {
                this._books.Add(new BookDetailViewModel(b.Id, b.Author, b.Name));
            }
            /*
            Application.Current.Dispatcher.Invoke(() =>
            {
                this._books.Clear();

                foreach (IBookModel b in Books.Values)
                {
                    this._books.Add(new BookDetailViewModel(b.Id, b.Author, b.Name));
                }
            });
            */

            OnPropertyChanged(nameof(Books));
        }
    }
}
