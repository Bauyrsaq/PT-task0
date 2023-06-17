using LibraryPresentation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryPresentation.ViewModel
{
    public interface IBookDetailViewModel
    {
        static IBookDetailViewModel CreateViewModel(int id, string author, string name,
            IBookModelOperation model)
        {
            return new BookDetailViewModel(id, author, name, model);
        }

        ICommand UpdateBook { get; set; }
        int Id { get; set; }
        string Author { get; set; }
        string Name { get; set; }
    }
}
