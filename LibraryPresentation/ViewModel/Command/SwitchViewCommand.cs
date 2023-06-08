using LibraryPresentation.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using LibraryPresentation.ViewModel.Book;
using LibraryPresentation.ViewModel.State;
using LibraryPresentation.ViewModel.Borrowing;

namespace LibraryPresentation.ViewModel.Command
{
    internal class SwitchViewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private string _switchToViewModel;

        public SwitchViewCommand(string viewModel)
        {
            this._switchToViewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        
        public void Execute(object parameter)
        {
            UserControl userControl = parameter as UserControl;

            Window parentWindow = Window.GetWindow(userControl);

            if (parentWindow != null)
            {
                if (parentWindow.DataContext is MainWindowViewModel mainViewModel)
                {
                    switch (this._switchToViewModel)
                    {
                        case "ProductMasterView":
                            mainViewModel.SelectedViewModel = new BookMasterViewModel(); break;
                        case "UserMasterView":
                            mainViewModel.SelectedViewModel = new UserMasterViewModel(); break;
                        case "StateMasterView":
                            mainViewModel.SelectedViewModel = new StateMasterViewModel(); break;
                        case "EventMasterView":
                            mainViewModel.SelectedViewModel = new BorrowingMasterViewModel(); break;
                    }
                }
            }
        }
    }
}
