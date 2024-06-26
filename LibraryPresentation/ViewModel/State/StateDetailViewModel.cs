﻿using LibraryPresentation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryPresentation.ViewModel
{
    internal class StateDetailViewModel : IViewModel, IStateDetailViewModel
    {
        public ICommand UpdateState { get; set; }

        private readonly IStateModelOperation _modelOperation;

        

        private int _id;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private int _bookId;

        public int bookId
        {
            get => _bookId;
            set
            {
                _bookId = value;
                OnPropertyChanged(nameof(bookId));
            }
        }

        private int _bookQuantity;

        public int bookQuantity
        {
            get => _bookQuantity;
            set
            {
                _bookQuantity = value;
                OnPropertyChanged(nameof(bookQuantity));
            }
        }

        public StateDetailViewModel(IStateModelOperation? model = null)
        {
            this.UpdateState = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

            this._modelOperation = model ?? IStateModelOperation.CreateModelOperation();
            
        }

        public StateDetailViewModel(int id, int bookId, int bookQuantity, IStateModelOperation? model = null)
        {
            this.Id = id;
            this.bookId = bookId;
            this.bookQuantity = bookQuantity;

            this.UpdateState = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

            this._modelOperation = model ?? IStateModelOperation.CreateModelOperation();
            
        }

        private void Update()
        {
            this._modelOperation.UpdateState(this.Id, this.bookId, this.bookQuantity);

        }

        private bool CanUpdate()
        {
            return !(
                string.IsNullOrWhiteSpace(this.bookQuantity.ToString()) ||
            this.bookQuantity < 0
            );
        }
    }
}
