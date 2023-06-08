using LibraryPresentation.Model.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LibraryPresentation.ViewModel.API;

namespace LibraryPresentation.ViewModel.User.API
{
    public interface IUserDetailViewModel
    {
        static IUserDetailViewModel CreateViewModel(int id, string name, string surname,
            IUserModelOperation model, IErrorInformer informer)
        {
            return new UserDetailViewModel(id, name, surname, model, informer);
        }

        ICommand UpdateUser {  get; set; }
        int Id { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
    }
}
