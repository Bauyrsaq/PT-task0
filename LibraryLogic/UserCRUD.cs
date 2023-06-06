using LibraryData.API;
using LibraryLogic.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLogic
{
    internal class UserCRUD : IUserCRUD
    {
        private IDataRepository _dataRepository;

        public UserCRUD(IDataRepository dataRepository)
        {
            this._dataRepository = dataRepository;
        }

        private IUserDTO Map(IUser user)
        {
            return new UserDTO(user.Id, user.Name, user.Surname);
        }

        public void AddUser(int userId, string name, string surname)
        {
            this._dataRepository.AddUser(userId, name, surname);
        }

        public IUserDTO GetUser(int userId)
        {
            return this.Map(this._dataRepository.GetUser(userId));
        }

        public Dictionary<int, IUserDTO> GetUsers()
        {
            Dictionary<int, IUserDTO> users = new Dictionary<int, IUserDTO>();

            foreach (IUser user in (this._dataRepository.GetUsers()).Values)
            {
                users.Add(user.Id, this.Map(user));
            }

            return users;
        }

        public void UpdateUser(int userId, string name, string surname)
        {
            this._dataRepository.UpdateUser(userId, name, surname);
        }

        public void DeleteUser(int userId)
        {
            this._dataRepository.DeleteUser(userId);
        }
    }
}
