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
    public interface IBookMasterViewModel
    {
        static IBookMasterViewModel CreateViewModel(IBookModelOperation operation)
        {
            return new BookMasterViewModel(operation);
        }

        ICommand CreateBook { get; set; }

        ICommand RemoveBook { get; set; }

        ObservableCollection<IBookDetailViewModel> Books { get; set; }

        string Author { get; set; }

        string Name { get; set; }

        bool IsBookSelected { get; set; }

        Visibility IsBookDetailVisible { get; set; }

        IBookDetailViewModel SelectedDetailViewModel { get; set; }
    }
}
