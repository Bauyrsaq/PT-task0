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
    internal class UserMasterViewModel : IViewModel, IUserMasterViewModel
    {
        public ICommand SwitchToBookMasterPage { get; set; }

        public ICommand SwitchToStateMasterPage { get; set; }

        public ICommand SwitchToBorrowingMasterPage { get; set; }

        public ICommand CreateUser { get; set; }

        public ICommand RemoveUser { get; set; }

        private readonly IUserModelOperation _modelOperation;

        

        private ObservableCollection<IUserDetailViewModel> _users;

        public ObservableCollection<IUserDetailViewModel> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
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

        private string _surname;

        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        private bool _isUserSelected;

        public bool IsUserSelected
        {
            get => _isUserSelected;
            set
            {
                this.IsUserDetailVisible = value ? Visibility.Visible : Visibility.Hidden;

                _isUserSelected = value;
                OnPropertyChanged(nameof(IsUserSelected));
            }
        }

        private Visibility _isUserDetailVisible;

        public Visibility IsUserDetailVisible
        {
            get => _isUserDetailVisible;
            set
            {
                _isUserDetailVisible = value;
                OnPropertyChanged(nameof(IsUserDetailVisible));
            }
        }

        private IUserDetailViewModel _selectedDetailViewModel;

        public IUserDetailViewModel SelectedDetailViewModel
        {
            get => _selectedDetailViewModel;
            set
            {
                _selectedDetailViewModel = value;
                this.IsUserSelected = true;

                OnPropertyChanged(nameof(SelectedDetailViewModel));
            }
        }

        public UserMasterViewModel(IUserModelOperation? model = null)
        {
            this.SwitchToBookMasterPage = new SwitchViewCommand("BookMasterView");
            this.SwitchToStateMasterPage = new SwitchViewCommand("StateMasterView");
            this.SwitchToBorrowingMasterPage = new SwitchViewCommand("BorrowingMasterView");

            this.CreateUser = new OnClickCommand(e => this.StoreUser(), c => this.CanStoreUser());
            this.RemoveUser = new OnClickCommand(e => this.DeleteUser());

            this.Users = new ObservableCollection<IUserDetailViewModel>();

            this._modelOperation = model ?? IUserModelOperation.CreateModelOperation();
            

            this.IsUserSelected = false;

            this.LoadUsers();
        }

        private bool CanStoreUser()
        {
            return !(
                string.IsNullOrWhiteSpace(this.Name) ||
                string.IsNullOrWhiteSpace(this.Surname)
            );
        }

        private void StoreUser()
        {
            int lastId = this._modelOperation.GetUsersCount() + 1;

            this._modelOperation.AddUser(lastId, this.Name, this.Surname);


            this.LoadUsers();
        }

        private void DeleteUser()
        {
            try
            {
                this._modelOperation.DeleteUser(this.SelectedDetailViewModel.Id);


                this.LoadUsers();
            }
            catch (Exception e)
            {
                
            }
        }

        private void LoadUsers()
        {
            Dictionary<int, IUserModel> Users = this._modelOperation.GetUsers();

            this._users.Clear();

            foreach (IUserModel u in Users.Values)
            {
                this._users.Add(new UserDetailViewModel(u.Id, u.Name, u.Surname));
            }
            /*Application.Current.Dispatcher.Invoke(() =>
            {
                this._users.Clear();

                foreach (IUserModel u in Users.Values)
                {
                    this._users.Add(new UserDetailViewModel(u.Id, u.Name, u.Surname));
                }
            });*/

            OnPropertyChanged(nameof(Users));
        }
    }
}
