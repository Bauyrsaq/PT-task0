using LibraryData.API;
using LibraryLogic.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLogic
{
    internal class BorrowingCRUD : IBorrowingCRUD
    {
        private IDataRepository _dataRepository;

        public BorrowingCRUD(IDataRepository dataRepository)
        {
            this._dataRepository = dataRepository;
        }

        private IBorrowingDTO Map(IBorrowing borrowing)
        {
            return new BorrowingDTO(borrowing.Id, borrowing.userId, borrowing.stateId, borrowing.Date, borrowing.bookQuantity);
        }

        public void AddBorrowing(int borrowingId, int userId, int stateId, int bookQuantity = 0)
        {
            this._dataRepository.AddBorrowing(borrowingId, userId, stateId, bookQuantity);
        }

        public IBorrowingDTO GetBorrowing(int borrowingId)
        {
            return this.Map(this._dataRepository.GetBorrowing(borrowingId));
        }

        public Dictionary<int, IBorrowingDTO> GetBorrowings()
        {
            Dictionary<int, IBorrowingDTO> borrowings = new Dictionary<int, IBorrowingDTO>();

            foreach (IBorrowing borrowing in (this._dataRepository.GetBorrowings()).Values)
            {
                borrowings.Add(borrowing.Id, this.Map(borrowing));
            }

            return borrowings;
        }

        public void UpdateBorrowing(int borrowingId, int userId, int stateId, DateTime Date, int? bookQuantity)
        {
            this._dataRepository.UpdateBorrowing(borrowingId, userId, stateId, Date, bookQuantity);
        }

        public void DeleteBorrowing(int borrowingId)
        {
            this._dataRepository.DeleteBorrowing(borrowingId);
        }
    }
}
