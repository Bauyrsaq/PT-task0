﻿using LibraryPresentation.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LibraryPresentation.ViewModel
{
    public interface IUserMasterViewModel
    {
        static IUserMasterViewModel CreateViewModel(IUserModelOperation operation)
        {
            return new UserMasterViewModel(operation);
        }

        ICommand CreateUser { get; set; }

        ICommand RemoveUser { get; set; }

        ObservableCollection<IUserDetailViewModel> Users { get; set; }

        string Name { get; set; }

        string Surname { get; set; }

        bool IsUserSelected { get; set; }

        Visibility IsUserDetailVisible { get; set; }

        IUserDetailViewModel SelectedDetailViewModel { get; set; }
    }
}