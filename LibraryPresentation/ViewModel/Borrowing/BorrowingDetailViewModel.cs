using LibraryPresentation.Model.API;
using LibraryPresentation.ViewModel.API;
using LibraryPresentation.ViewModel.Borrowing.API;
using LibraryPresentation.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryPresentation.ViewModel.Borrowing
{
    internal class BorrowingDetailViewModel : IViewModel, IBorrowingDetailViewModel
    {
        public ICommand UpdateBorrowing { get; set; }

        private readonly IBorrowingModelOperation _modelOperation;

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

        public BorrowingDetailViewModel(IBorrowingModelOperation? model = null, IErrorInformer? informer = null)
        {
            this.UpdateBorrowing = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

            this._modelOperation = model ?? IBorrowingModelOperation.CreateModelOperation();
            this._informer = informer ?? new PopupErrorInformer();
        }

        public BorrowingDetailViewModel(int id, int userId, int stateId, DateTime Date, int? bookQuantity, IBorrowingModelOperation? model = null, IErrorInformer? informer = null)
        {
            this.Id = id;
            this.userId = userId;
            this.stateId = stateId;
            this.Date = Date;
            this.bookQuantity = bookQuantity;

            this.UpdateBorrowing = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

            this._modelOperation = model ?? IBorrowingModelOperation.CreateModelOperation();
            this._informer = informer ?? new PopupErrorInformer();
        }

        private void Update()
        {
            this._modelOperation.UpdateBorrowing(this.Id, this.userId, this.stateId, this.Date, this.bookQuantity);

            this._informer.InformSuccess("Borrowing successfully updated!");
        }

        private bool CanUpdate()
        {
            return !(
                string.IsNullOrWhiteSpace(this.Date.ToString())
            );
        }
    }
}
