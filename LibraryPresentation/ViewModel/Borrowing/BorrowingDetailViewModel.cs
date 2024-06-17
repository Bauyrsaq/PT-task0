using LibraryPresentation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryPresentation.ViewModel
{
    internal class BorrowingDetailViewModel : IViewModel, IBorrowingDetailViewModel
    {
        public ICommand UpdateBorrowing { get; set; }

        private readonly IBorrowingModelOperation _modelOperation;

        

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

        private int _userId;

        public int userId
        {
            get => _userId;
            set
            {
                _userId = value;
                OnPropertyChanged(nameof(userId));
            }
        }

        private int _stateId;

        public int stateId
        {
            get => _stateId;
            set
            {
                _stateId = value;
                OnPropertyChanged(nameof(stateId));
            }
        }

        private DateTime _date;

        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        private int? _bookQuantity;

        public int? bookQuantity
        {
            get => _bookQuantity;
            set
            {
                _bookQuantity = value;
                OnPropertyChanged(nameof(bookQuantity));
            }
        }

        public BorrowingDetailViewModel(IBorrowingModelOperation? model = null)
        {
            this.UpdateBorrowing = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

            this._modelOperation = model ?? IBorrowingModelOperation.CreateModelOperation();
            
        }

        public BorrowingDetailViewModel(int id, int userId, int stateId, DateTime Date, int? bookQuantity, IBorrowingModelOperation? model = null)
        {
            this.Id = id;
            this.userId = userId;
            this.stateId = stateId;
            this.Date = Date;
            this.bookQuantity = bookQuantity;

            this.UpdateBorrowing = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

            this._modelOperation = model ?? IBorrowingModelOperation.CreateModelOperation();
            
        }

        private void Update()
        {
            this._modelOperation.UpdateBorrowing(this.Id, this.userId, this.stateId, this.Date, this.bookQuantity);

        }

        private bool CanUpdate()
        {
            return !(
                string.IsNullOrWhiteSpace(this.Date.ToString())
            );
        }
    }
}
