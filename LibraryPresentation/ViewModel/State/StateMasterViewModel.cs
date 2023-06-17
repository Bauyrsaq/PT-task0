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
    internal class StateMasterViewModel : IViewModel, IStateMasterViewModel
    {
        public ICommand SwitchToUserMasterPage { get; set; }

        public ICommand SwitchToBookMasterPage { get; set; }

        public ICommand SwitchToBorrowingMasterPage { get; set; }

        public ICommand CreateState { get; set; }

        public ICommand RemoveState { get; set; }

        private readonly IStateModelOperation _modelOperation;

        

        private ObservableCollection<IStateDetailViewModel> _states;

        public ObservableCollection<IStateDetailViewModel> States
        {
            get => _states;
            set
            {
                _states = value;
                OnPropertyChanged(nameof(States));
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

        private bool _isStateSelected;

        public bool IsStateSelected
        {
            get => _isStateSelected;
            set
            {
                this.IsStateDetailVisible = value ? Visibility.Visible : Visibility.Hidden;

                _isStateSelected = value;
                OnPropertyChanged(nameof(IsStateSelected));
            }
        }

        private Visibility _isStateDetailVisible;

        public Visibility IsStateDetailVisible
        {
            get => _isStateDetailVisible;
            set
            {
                _isStateDetailVisible = value;
                OnPropertyChanged(nameof(IsStateDetailVisible));
            }
        }

        private IStateDetailViewModel _selectedDetailViewModel;

        public IStateDetailViewModel SelectedDetailViewModel
        {
            get => _selectedDetailViewModel;
            set
            {
                _selectedDetailViewModel = value;
                this.IsStateSelected = true;

                OnPropertyChanged(nameof(SelectedDetailViewModel));
            }
        }

        public StateMasterViewModel(IStateModelOperation? model = null)
        {
            this.SwitchToUserMasterPage = new SwitchViewCommand("UserMasterView");
            this.SwitchToBookMasterPage = new SwitchViewCommand("BookMasterView");
            this.SwitchToBorrowingMasterPage = new SwitchViewCommand("BorrowingMasterView");

            this.CreateState = new OnClickCommand(e => this.StoreState(), c => this.CanStoreState());
            this.RemoveState = new OnClickCommand(e => this.DeleteState());

            this.States = new ObservableCollection<IStateDetailViewModel>();

            this._modelOperation = model ?? IStateModelOperation.CreateModelOperation();
            

            this.IsStateSelected = false;

            this.LoadStates();
        }

        private bool CanStoreState()
        {
            return !(
                string.IsNullOrWhiteSpace(this.bookId.ToString()) ||
                string.IsNullOrWhiteSpace(this.bookQuantity.ToString()) ||
                this.bookQuantity < 0
            );
        }

        private void StoreState()
        {
            int lastId = this._modelOperation.GetStatesCount() + 1;

            this._modelOperation.AddState(lastId, this.bookId, this.bookQuantity);


            this.LoadStates();
        }

        private void DeleteState()
        {
            try
            {
                this._modelOperation.DeleteState(this.SelectedDetailViewModel.Id);


                this.LoadStates();
            }
            catch (Exception e)
            {
            }
        }

        private void LoadStates()
        {
            Dictionary<int, IStateModel> States = this._modelOperation.GetStates();

            this._states.Clear();

            foreach (IStateModel u in States.Values)
            {
                this._states.Add(new StateDetailViewModel(u.Id, u.bookId, u.bookQuantity));
            }
            /*
            Application.Current.Dispatcher.Invoke(() =>
            {
                this._states.Clear();

                foreach (IStateModel u in States.Values)
                {
                    this._states.Add(new StateDetailViewModel(u.Id, u.bookId, u.bookQuantity));
                }
            });
            */

            OnPropertyChanged(nameof(States));
        }
    }
}
