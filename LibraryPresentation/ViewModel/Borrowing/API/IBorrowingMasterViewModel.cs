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
    public interface IBorrowingMasterViewModel
    {
        static IBorrowingMasterViewModel CreateViewModel(IBorrowingModelOperation operation)
        {
            return new BorrowingMasterViewModel(operation);
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
