using LibraryData.API;
using LibraryLogic.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLogic
{
    internal class StateCRUD : IStateCRUD
    {
        private IDataRepository _dataRepository;

        public StateCRUD(IDataRepository dataRepository)
        {
            this._dataRepository = dataRepository;
        }

        private IStateDTO Map(IState state)
        {
            return new StateDTO(state.Id, state.bookId, state.bookQuantity);
        }

        public void AddState(int stateId, int bookId, int bookQuantity)
        {
            this._dataRepository.AddState(stateId, bookId, bookQuantity);
        }

        public IStateDTO GetState(int stateId)
        {
            return this.Map(this._dataRepository.GetState(stateId));
        }

        public Dictionary<int, IStateDTO> GetStates()
        {
            Dictionary<int, IStateDTO> states = new Dictionary<int, IStateDTO>();

            foreach (IState state in (this._dataRepository.GetStates()).Values)
            {
                states.Add(state.Id, this.Map(state));
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
    }
}
