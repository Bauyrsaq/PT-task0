using LibraryData.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLogic.API
{
    public interface IUserCRUD
    {
        static IUserCRUD CreateUserCRUD(IDataRepository? dataRepository = null)
        {
            return new UserCRUD(dataRepository ?? IDataRepository.CreateDatabase());
        }

        void AddUser(int userId, string name, string surname);
        IUserDTO GetUser(int userId);
        Dictionary<int, IUserDTO> GetUsers();
        void UpdateUser(int userId, string name, string surname);
        void DeleteUser(int userId);
    }
}
