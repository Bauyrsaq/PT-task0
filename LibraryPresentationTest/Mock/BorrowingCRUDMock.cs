using LibraryData.API;
using LibraryLogic.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPresentationTest.Mock
{
    internal class BorrowingCRUDMock : IBorrowingCRUD
    {
        private readonly DataRepositoryMock _dataRepository = new DataRepositoryMock();

        public BorrowingCRUDMock()
        {
            
        }

        public void AddBorrowing(int borrowingId, int userId, int stateId, int bookQuantity = 0)
        {
            this._dataRepository.AddBorrowing(borrowingId, userId, stateId, bookQuantity);
        }

        public IBorrowingDTO GetBorrowing(int borrowingId)
        {
            return this._dataRepository.GetBorrowing(borrowingId);
        }

        public Dictionary<int, IBorrowingDTO> GetBorrowings()
        {
            Dictionary<int, IBorrowingDTO> borrowings = new Dictionary<int, IBorrowingDTO>();

            foreach (IBorrowingDTO borrowing in (this._dataRepository.GetBorrowings()).Values)
            {
                borrowings.Add(borrowing.Id, borrowing);
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

        public int GetBorrowingsCount()
        {
            return this._dataRepository.GetBorrowingsCount();
        }
    }
}
