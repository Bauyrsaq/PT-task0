﻿using LibraryPresentation.Model.API;
using LibraryPresentation.ViewModel.API;
using LibraryPresentation.ViewModel.State.API;
using LibraryPresentation.ViewModel.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryPresentation.ViewModel.State.API
{
    public interface IStateDetailViewModel
    {
        static IStateDetailViewModel CreateViewModel(int id, int bookId, int bookQuantity,
            IStateModelOperation model, IErrorInformer informer)
        {
            return new StateDetailViewModel(id, bookId, bookQuantity, model, informer);
        }

        ICommand UpdateState { get; set; }
        int Id { get; set; }
        int bookId { get; set; }
        int bookQuantity { get; set; }
    }
}
