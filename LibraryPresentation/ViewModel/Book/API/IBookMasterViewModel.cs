using LibraryPresentation.Model.API;
using LibraryPresentation.ViewModel.API;
using LibraryPresentation.ViewModel.Book.API;
using LibraryPresentation.ViewModel.Book;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace LibraryPresentation.ViewModel.Book.API
{
    public interface IBookMasterViewModel
    {
        static IBookMasterViewModel CreateViewModel(IBookModelOperation operation, IErrorInformer informer)
        {
            return new BookMasterViewModel(operation, informer);
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
