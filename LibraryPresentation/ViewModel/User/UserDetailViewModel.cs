using LibraryPresentation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryPresentation.ViewModel
{
    internal class UserDetailViewModel : IViewModel, IUserDetailViewModel
    {
        public ICommand UpdateUser { get; set; }

        private readonly IUserModelOperation _modelOperation;

        

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

        public UserDetailViewModel(IUserModelOperation? model = null)
        {
            this.UpdateUser = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

            this._modelOperation = model ?? IUserModelOperation.CreateModelOperation();
            
        }

        public UserDetailViewModel(int id, string name, string surname, IUserModelOperation? model = null)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;

            this.UpdateUser = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

            this._modelOperation = model ?? IUserModelOperation.CreateModelOperation();
            
        }

        private void Update()
        {
            this._modelOperation.UpdateUser(this.Id, this.Name, this.Surname);

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
