using LibraryData.API;
using LibraryLogic.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPresentationTest.Mock
{
    internal class UserCRUDMock : IUserCRUD
    {
        private readonly DataRepositoryMock _dataRepository = new DataRepositoryMock();

        public UserCRUDMock()
        {
            
        }

        public void AddUser(int userId, string name, string surname)
        {
            this._dataRepository.AddUser(userId, name, surname);
        }

        public IUserDTO GetUser(int userId)
        {
            return this._dataRepository.GetUser(userId);
        }

        public Dictionary<int, IUserDTO> GetUsers()
        {
            Dictionary<int, IUserDTO> users = new Dictionary<int, IUserDTO>();

            foreach (IUserDTO user in (this._dataRepository.GetUsers()).Values)
            {
                users.Add(user.Id, user);
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

        public int GetUsersCount()
        {
            return this._dataRepository.GetUsersCount();
        }
    }
}
