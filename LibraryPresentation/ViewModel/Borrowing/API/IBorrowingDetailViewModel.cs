using LibraryPresentation.Model.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryPresentation.ViewModel
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
