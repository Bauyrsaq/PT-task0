using LibraryPresentation.Model;
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

        public BookDetailViewModel(IBookModelOperation? model = null)
        {
            this.UpdateBook = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

            this._modelOperation = model ?? IBookModelOperation.CreateModelOperation();
            
        }

        public BookDetailViewModel(int id, string author, string name, IBookModelOperation? model = null)
        {
            this.Id = id;
            this.Author = author;
            this.Name = name;

            this.UpdateBook = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

            this._modelOperation = model ?? IBookModelOperation.CreateModelOperation();
            
        }

        private void Update()
        {
            this._modelOperation.UpdateBook(this.Id, this.Author, this.Name);

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
