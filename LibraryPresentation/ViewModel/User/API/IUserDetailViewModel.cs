using LibraryPresentation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryPresentation.ViewModel
{
    public interface IUserDetailViewModel
    {
        static IUserDetailViewModel CreateViewModel(int id, string name, string surname,
            IUserModelOperation model)
        {
            return new UserDetailViewModel(id, name, surname, model);
        }

        ICommand UpdateUser {  get; set; }
        int Id { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
    }
}
