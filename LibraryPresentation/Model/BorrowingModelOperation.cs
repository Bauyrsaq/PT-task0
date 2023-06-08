using LibraryData.API;
using LibraryLogic.API;
using LibraryPresentation.Model.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPresentation.Model
{
    internal class BorrowingModelOperation : IBorrowingModelOperation
    {
        private IBorrowingCRUD _borrowingCrud;

        public BorrowingModelOperation(IBorrowingCRUD borrowingCrud)
        {
            this._borrowingCrud = borrowingCrud;
        }

        private IBorrowingModel Map(IBorrowingDTO borrowing)
        {
            return new BorrowingModel(borrowing.Id, borrowing.userId, borrowing.stateId, borrowing.Date, borrowing.bookQuantity);
        }

        public void AddBorrowing(int borrowingId, int userId, int stateId, int bookQuantity = 0)
        {
            this._borrowingCrud.AddBorrowing(borrowingId, userId, stateId, bookQuantity);
        }

        public IBorrowingModel GetBorrowing(int borrowingId)
        {
            return this.Map(this._borrowingCrud.GetBorrowing(borrowingId));
        }

        public Dictionary<int, IBorrowingModel> GetBorrowings()
        {
            Dictionary<int, IBorrowingModel> borrowings = new Dictionary<int, IBorrowingModel>();

            foreach (IBorrowingDTO borrowing in (this._borrowingCrud.GetBorrowings()).Values)
            {
                borrowings.Add(borrowing.Id, this.Map(borrowing));
            }

            return borrowings;
        }

        public void UpdateBorrowing(int borrowingId, int userId, int stateId, DateTime Date, int? bookQuantity)
        {
            this._borrowingCrud.UpdateBorrowing(borrowingId, userId, stateId, Date, bookQuantity);
        }

        public void DeleteBorrowing(int borrowingId)
        {
            this._borrowingCrud.DeleteBorrowing(borrowingId);
        }
    }
}
