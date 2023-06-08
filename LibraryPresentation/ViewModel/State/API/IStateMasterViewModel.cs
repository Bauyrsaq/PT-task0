using LibraryPresentation.Model.API;
using LibraryPresentation.ViewModel.API;
using LibraryPresentation.ViewModel.State.API;
using LibraryPresentation.ViewModel.State;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace LibraryPresentation.ViewModel.State.API
{
    public interface IStateMasterViewModel
    {
        static IStateMasterViewModel CreateViewModel(IStateModelOperation operation, IErrorInformer informer)
        {
            return new StateMasterViewModel(operation, informer);
        }

        ICommand CreateState { get; set; }

        ICommand RemoveState { get; set; }

        ObservableCollection<IStateDetailViewModel> States { get; set; }

        int bookId { get; set; }

        int bookQuantity { get; set; }

        bool IsStateSelected { get; set; }

        Visibility IsStateDetailVisible { get; set; }

        IStateDetailViewModel SelectedDetailViewModel { get; set; }
    }
}
