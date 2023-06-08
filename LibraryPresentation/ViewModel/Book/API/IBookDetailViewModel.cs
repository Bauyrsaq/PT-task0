using LibraryPresentation.Model.API;
using LibraryPresentation.ViewModel.API;
using LibraryPresentation.ViewModel.Book.API;
using LibraryPresentation.ViewModel.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryPresentation.ViewModel.Book.API
{
    public interface IBookDetailViewModel
    {
        static IBookDetailViewModel CreateViewModel(int id, string author, string name,
            IBookModelOperation model, IErrorInformer informer)
        {
            return new BookDetailViewModel(id, author, name, model, informer);
        }

        ICommand UpdateBook { get; set; }
        int Id { get; set; }
        string Author { get; set; }
        string Name { get; set; }
    }
}
