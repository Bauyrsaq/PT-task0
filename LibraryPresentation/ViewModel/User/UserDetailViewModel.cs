using LibraryPresentation.Model.API;
using LibraryPresentation.ViewModel.API;
using LibraryPresentation.ViewModel.User.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LibraryPresentation.ViewModel.Command;

namespace LibraryPresentation.ViewModel.User
{
    internal class UserDetailViewModel : IViewModel, IUserDetailViewModel
    {
        public ICommand UpdateUser { get; set; }

        private readonly IUserModelOperation _modelOperation;

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

        public UserDetailViewModel(IUserModelOperation? model = null, IErrorInformer? informer = null)
        {
            this.UpdateUser = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

            this._modelOperation = model ?? IUserModelOperation.CreateModelOperation();
            this._informer = informer ?? new PopupErrorInformer();
        }

        public UserDetailViewModel(int id, string name, string surname, IUserModelOperation? model = null, IErrorInformer? informer = null)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;

            this.UpdateUser = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

            this._modelOperation = model ?? IUserModelOperation.CreateModelOperation();
            this._informer = informer ?? new PopupErrorInformer();
        }

        private void Update()
        {
            Task.Run(() =>
            {
                this._modelOperation.UpdateUser(this.Id, this.Name, this.Surname);

                this._informer.InformSuccess("User successfully updated!");
            });
        }

        private bool CanUpdate()
        {
            return !(
                string.IsNullOrWhiteSpace(this.Name) ||
                string.IsNullOrWhiteSpace(this.Surname)
            );
        }
    }
}
