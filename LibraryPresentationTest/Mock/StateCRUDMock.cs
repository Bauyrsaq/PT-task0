using LibraryData.API;
using LibraryLogic.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPresentationTest.Mock
{
    internal class StateCRUDMock : IStateCRUD
    {
        private readonly DataRepositoryMock _dataRepository = new DataRepositoryMock();

        public StateCRUDMock()
        {
            
        }

        public void AddState(int stateId, int bookId, int bookQuantity)
        {
            this._dataRepository.AddState(stateId, bookId, bookQuantity);
        }

        public IStateDTO GetState(int stateId)
        {
            return this._dataRepository.GetState(stateId);
        }

        public Dictionary<int, IStateDTO> GetStates()
        {
            Dictionary<int, IStateDTO> states = new Dictionary<int, IStateDTO>();

            foreach (IStateDTO state in (this._dataRepository.GetStates()).Values)
            {
                states.Add(state.Id, state);
            }

            return states;
        }

        public void UpdateState(int stateId, int bookId, int bookQuantity)
        {
            this._dataRepository.UpdateState(stateId, bookId, bookQuantity);
        }

        public void DeleteState(int stateId)
        {
            this._dataRepository.DeleteState(stateId);
        }

        public int GetStatesCount()
        {
            return this._dataRepository.GetStatesCount();
        }
    }
}
