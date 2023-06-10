using LibraryPresentation.Model.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryPresentation.ViewModel
{
    internal class BookDetailViewModel : IViewModel, IBookDetailViewModel
    {
        public ICommand UpdateBook { get; set; }

        private readonly IBookModelOperation _modelOperation;

        private readonly IErrorInformer _informer;

        private int _id;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
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

        public BookDetailViewModel(IBookModelOperation? model = null, IErrorInformer? informer = null)
        {
            this.UpdateBook = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

            this._modelOperation = model ?? IBookModelOperation.CreateModelOperation();
            this._informer = informer ?? new PopupErrorInformer();
        }

        public BookDetailViewModel(int id, string author, string name, IBookModelOperation? model = null, IErrorInformer? informer = null)
        {
            this.Id = id;
            this.Author = author;
            this.Name = name;

            this.UpdateBook = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

            this._modelOperation = model ?? IBookModelOperation.CreateModelOperation();
            this._informer = informer ?? new PopupErrorInformer();
        }

        private void Update()
        {
            this._modelOperation.UpdateBook(this.Id, this.Author, this.Name);

            this._informer.InformSuccess("Book successfully updated!");
        }

        private bool CanUpdate()
        {
            return !(
                string.IsNullOrWhiteSpace(this.Author) ||
                string.IsNullOrWhiteSpace(this.Name)
            );
        }
    }
}
