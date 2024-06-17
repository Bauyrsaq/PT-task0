using LibraryLogic.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPresentation.Model
{
    public interface IStateModelOperation
    {
        static IStateModelOperation CreateModelOperation(IStateCRUD? stateCrud = null)
        {
            return new StateModelOperation(stateCrud ?? IStateCRUD.CreateStateCRUD());
        }

        void AddState(int stateId, int bookId, int bookQuantity);
        IStateModel GetState(int stateId);
        Dictionary<int, IStateModel> GetStates();
        void UpdateState(int stateId, int bookId, int bookQuantity);
        void DeleteState(int stateId);
        int GetStatesCount();
    }
}
