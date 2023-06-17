using LibraryPresentation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryPresentation.ViewModel
{
    public interface IStateDetailViewModel
    {
        static IStateDetailViewModel CreateViewModel(int id, int bookId, int bookQuantity,
            IStateModelOperation model)
        {
            return new StateDetailViewModel(id, bookId, bookQuantity, model);
        }

        ICommand UpdateState { get; set; }
        int Id { get; set; }
        int bookId { get; set; }
        int bookQuantity { get; set; }
    }
}
