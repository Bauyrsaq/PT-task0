using LibraryPresentation.Model.API;
using LibraryPresentation.ViewModel.API;
using LibraryPresentation.ViewModel.Borrowing.API;
using LibraryPresentation.ViewModel.Borrowing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryPresentation.ViewModel.Borrowing.API
{
    public interface IBorrowingDetailViewModel
    {
        static IBorrowingDetailViewModel CreateViewModel(int id, int userId, int stateId,
            DateTime Date, int? bookQuantity, IBorrowingModelOperation model, IErrorInformer informer)
        {
            return new BorrowingDetailViewModel(id, userId, stateId, Date, bookQuantity, model, informer);
        }

        ICommand UpdateBorrowing { get; set; }
        int Id { get; set; }
        int userId { get; set; }
        int stateId { get; set; }
        DateTime Date { get; set; }
        int? bookQuantity { get; set; }
    }
}
