using LibraryData.API;
using LibraryLogic.API;
using LibraryPresentation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPresentation.Model
{
    internal class StateModelOperation : IStateModelOperation
    {
        private IStateCRUD _stateCrud;

        public StateModelOperation(IStateCRUD stateCrud)
        {
            this._stateCrud = stateCrud;
        }

        private IStateModel Map(IStateDTO state)
        {
            return new StateModel(state.Id, state.bookId, state.bookQuantity);
        }

        public void AddState(int stateId, int bookId, int bookQuantity)
        {
            this._stateCrud.AddState(stateId, bookId, bookQuantity);
        }

        public IStateModel GetState(int stateId)
        {
            return this.Map(this._stateCrud.GetState(stateId));
        }

        public Dictionary<int, IStateModel> GetStates()
        {
            Dictionary<int, IStateModel> states = new Dictionary<int, IStateModel>();

            foreach (IStateDTO state in (this._stateCrud.GetStates()).Values)
            {
                states.Add(state.Id, this.Map(state));
            }

            return states;
        }

        public void UpdateState(int stateId, int bookId, int bookQuantity)
        {
            this._stateCrud.UpdateState(stateId, bookId, bookQuantity);
        }

        public void DeleteState(int stateId)
        {
            this._stateCrud.DeleteState(stateId);
        }

        public int GetStatesCount()
        {
            return this._stateCrud.GetStatesCount();
        }
    }
}
