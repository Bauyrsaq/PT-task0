using LibraryData.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLogic.API
{
    public interface IStateCRUD
    {
        static IStateCRUD CreateStateCRUD(IDataRepository? dataRepository = null)
        {
            return new StateCRUD(dataRepository ?? IDataRepository.CreateDatabase());
        }

        void AddState(int stateId, int bookId, int bookQuantity);
        IStateDTO GetState(int stateId);
        Dictionary<int, IStateDTO> GetStates();
        void UpdateState(int stateId, int bookId, int bookQuantity);
        void DeleteState(int stateId);
    }
}
