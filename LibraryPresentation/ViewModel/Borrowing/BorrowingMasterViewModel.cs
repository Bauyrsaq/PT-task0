using LibraryPresentation.Model.API;
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
    internal class BorrowingMasterViewModel : IViewModel, IBorrowingMasterViewModel
    {
        public ICommand SwitchToUserMasterPage { get; set; }

        public ICommand SwitchToBookMasterPage { get; set; }

        public ICommand SwitchToStateMasterPage { get; set; }

        public ICommand PurchaseBorrowing { get; set; }

        public ICommand ReturnBorrowing { get; set; }

        public ICommand SupplyBorrowing { get; set; }

        public ICommand RemoveBorrowing { get; set; }

        private readonly IBorrowingModelOperation _modelOperation;

        private readonly IErrorInformer _informer;

        private ObservableCollection<IBorrowingDetailViewModel> _borrowings;

        public ObservableCollection<IBorrowingDetailViewModel> Borrowings
        {
            get => _borrowings;
            set
            {
                _borrowings = value;
                OnPropertyChanged(nameof(Borrowings));
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

        private bool _isBorrowingSelected;

        public bool IsBorrowingSelected
        {
            get => _isBorrowingSelected;
            set
            {
                this.IsBorrowingDetailVisible = value ? Visibility.Visible : Visibility.Hidden;

                _isBorrowingSelected = value;
                OnPropertyChanged(nameof(IsBorrowingSelected));
            }
        }

        private Visibility _isBorrowingDetailVisible;

        public Visibility IsBorrowingDetailVisible
        {
            get => _isBorrowingDetailVisible;
            set
            {
                _isBorrowingDetailVisible = value;
                OnPropertyChanged(nameof(IsBorrowingDetailVisible));
            }
        }

        private IBorrowingDetailViewModel _selectedDetailViewModel;

        public IBorrowingDetailViewModel SelectedDetailViewModel
        {
            get => _selectedDetailViewModel;
            set
            {
                _selectedDetailViewModel = value;
                this.IsBorrowingSelected = true;

                OnPropertyChanged(nameof(SelectedDetailViewModel));
            }
        }

        public BorrowingMasterViewModel(IBorrowingModelOperation? model = null, IErrorInformer? informer = null)
        {
            this.SwitchToUserMasterPage = new SwitchViewCommand("UserMasterView");
            this.SwitchToBookMasterPage = new SwitchViewCommand("BookMasterView");
            this.SwitchToStateMasterPage = new SwitchViewCommand("StateMasterView");

            this.PurchaseBorrowing = new OnClickCommand(e => this.StorePurchaseBorrowing(), c => this.CanPurchaseBorrowing());
            this.ReturnBorrowing = new OnClickCommand(e => this.StoreReturnBorrowing(), c => this.CanReturnBorrowing());
            this.SupplyBorrowing = new OnClickCommand(e => this.StoreSupplyBorrowing(), c => this.CanSupplyBorrowing());
            this.RemoveBorrowing = new OnClickCommand(e => this.DeleteBorrowing());

            this.Borrowings = new ObservableCollection<IBorrowingDetailViewModel>();

            this._modelOperation = model ?? IBorrowingModelOperation.CreateModelOperation();
            this._informer = informer ?? new PopupErrorInformer();

            this.IsBorrowingSelected = false;

            this.LoadBorrowings();
        }

        private bool CanPurchaseBorrowing()
        {
            return !(
                string.IsNullOrWhiteSpace(this.userId.ToString()) ||
                string.IsNullOrWhiteSpace(this.stateId.ToString())
            );
        }

        private bool CanReturnBorrowing()
        {
            return !(
                string.IsNullOrWhiteSpace(this.userId.ToString()) ||
                string.IsNullOrWhiteSpace(this.stateId.ToString())
            );
        }

        private bool CanSupplyBorrowing()
        {
            return !(
                string.IsNullOrWhiteSpace(this.userId.ToString()) ||
                string.IsNullOrWhiteSpace(this.stateId.ToString()) ||
                string.IsNullOrEmpty(this.bookQuantity.ToString()) ||
                this.bookQuantity < 1
            );
        }

        private void StorePurchaseBorrowing()
        {
            int lastId = this._modelOperation.GetBorrowingsCount() + 1;

            this._modelOperation.AddBorrowing(lastId, this.userId, this.stateId);

            this._informer.InformSuccess("Borrowing successfully created!");

            this.LoadBorrowings();
        }

        private void StoreReturnBorrowing()
        {
            int lastId = this._modelOperation.GetBorrowingsCount() + 1;

            this._modelOperation.AddBorrowing(lastId, this.userId, this.stateId);

            this.LoadBorrowings();

            this._informer.InformSuccess("Borrowing successfully created!");
        }

        private void StoreSupplyBorrowing()
        {
            int lastId = this._modelOperation.GetBorrowingsCount() + 1;

            this._modelOperation.AddBorrowing(lastId, this.userId, this.stateId, this.bookQuantity);

            this.LoadBorrowings();

            this._informer.InformSuccess("Borrowing successfully created!");
        }

        private void DeleteBorrowing()
        {
            try
            {
                this._modelOperation.DeleteBorrowing(this.SelectedDetailViewModel.Id);

                this._informer.InformSuccess("Borrowing successfully deleted!");

                this.LoadBorrowings();
            }
            catch (Exception e)
            {
                this._informer.InformError("Error while deleting user! Remember to remove all associated events!");
            }
        }

        private void LoadBorrowings()
        {
            Dictionary<int, IBorrowingModel> Borrowings = this._modelOperation.GetBorrowings();

            this._borrowings.Clear();

            foreach (IBorrowingModel b in Borrowings.Values)
            {
                this._borrowings.Add(new BorrowingDetailViewModel(b.Id, b.userId, b.stateId, b.Date, b.bookQuantity));
            }
            /*
            Application.Current.Dispatcher.Invoke(() =>
            {
                this._borrowings.Clear();

                foreach (IBorrowingModel b in Borrowings.Values)
                {
                    this._borrowings.Add(new BorrowingDetailViewModel(b.Id, b.userId, b.stateId, b.Date, b.bookQuantity));
                }
            });
            */

            OnPropertyChanged(nameof(Borrowings));
        }
    }
}
