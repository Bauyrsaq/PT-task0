using LibraryPresentation.Model.API;
using LibraryPresentation.ViewModel.API;
using LibraryPresentation.ViewModel.Command;
using LibraryPresentation.ViewModel.State.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryPresentation.ViewModel.State
{
    internal class StateDetailViewModel : IViewModel, IStateDetailViewModel
    {
        public ICommand UpdateState { get; set; }

        private readonly IStateModelOperation _modelOperation;

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

        private int _bookId;

        public int bookId
        {
            get => _bookId;
            set
            {
                _bookId = value;
                OnPropertyChanged(nameof(bookId));
            }
        }

        private int _bookQuantity;

        public int bookQuantity
        {
            get => _bookQuantity;
            set
            {
                _bookQuantity = value;
                OnPropertyChanged(nameof(bookQuantity));
            }
        }

        public StateDetailViewModel(IStateModelOperation? model = null, IErrorInformer? informer = null)
        {
            this.UpdateState = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

            this._modelOperation = model ?? IStateModelOperation.CreateModelOperation();
            this._informer = informer ?? new PopupErrorInformer();
        }

        public StateDetailViewModel(int id, int bookId, int bookQuantity, IStateModelOperation? model = null, IErrorInformer? informer = null)
        {
            this.Id = id;
            this.bookId = bookId;
            this.bookQuantity = bookQuantity;

            this.UpdateState = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

            this._modelOperation = model ?? IStateModelOperation.CreateModelOperation();
            this._informer = informer ?? new PopupErrorInformer();
        }

        private void Update()
        {
            this._modelOperation.UpdateState(this.Id, this.bookId, this.bookQuantity);

            this._informer.InformSuccess("State successfully updated!");
        }

        private bool CanUpdate()
        {
            return !(
                string.IsNullOrWhiteSpace(this.bookQuantity.ToString()) ||
            this.bookQuantity < 0
            );
        }
    }
}
