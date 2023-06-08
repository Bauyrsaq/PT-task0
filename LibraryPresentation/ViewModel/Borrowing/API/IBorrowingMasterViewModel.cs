using LibraryPresentation.Model.API;
using LibraryPresentation.ViewModel.API;
using LibraryPresentation.ViewModel.Borrowing.API;
using LibraryPresentation.ViewModel.Borrowing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace LibraryPresentation.ViewModel.Borrowing.API
{
    public interface IBorrowingMasterViewModel
    {
        static IBorrowingMasterViewModel CreateViewModel(IBorrowingModelOperation operation, IErrorInformer informer)
        {
            return new BorrowingMasterViewModel(operation, informer);
        }

        ICommand PurchaseBorrowing { get; set; }

        ICommand ReturnBorrowing { get; set; }

        ICommand SupplyBorrowing { get; set; }

        ICommand RemoveBorrowing { get; set; }

        ObservableCollection<IBorrowingDetailViewModel> Borrowings { get; set; }

        int userId { get; set; }

        int stateId { get; set; }

        int bookQuantity { get; set; }

        bool IsBorrowingSelected { get; set; }

        Visibility IsBorrowingDetailVisible { get; set; }

        IBorrowingDetailViewModel SelectedDetailViewModel { get; set; }
    }
}
