using LibraryData.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLogic.API
{
    public interface IBorrowingCRUD
    {
        static IBorrowingCRUD CreateBorrowingCRUD(IDataRepository? dataRepository = null)
        {
            return new BorrowingCRUD(dataRepository ?? IDataRepository.CreateDatabase());
        }

        void AddBorrowing(int borrowingId, int userId, int stateId, int bookQuantity = 0);
        IBorrowingDTO GetBorrowing(int borrowingId);
        Dictionary<int, IBorrowingDTO> GetBorrowings();
        void UpdateBorrowing(int borrowingId, int userId, int stateId, DateTime Date, int? bookQuantity);
        void DeleteBorrowing(int borrowingId);
    }
}
