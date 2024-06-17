using LibraryLogic.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPresentation.Model
{
    public interface IBorrowingModelOperation
    {
        static IBorrowingModelOperation CreateModelOperation(IBorrowingCRUD? borrowingCrud = null)
        {
            return new BorrowingModelOperation(borrowingCrud ?? IBorrowingCRUD.CreateBorrowingCRUD());
        }

        void AddBorrowing(int borrowingId, int userId, int stateId, int bookQuantity = 0);
        IBorrowingModel GetBorrowing(int borrowingId);
        Dictionary<int, IBorrowingModel> GetBorrowings();
        void UpdateBorrowing(int borrowingId, int userId, int stateId, DateTime Date, int? bookQuantity);
        void DeleteBorrowing(int borrowingId);
        int GetBorrowingsCount();
    }
}
