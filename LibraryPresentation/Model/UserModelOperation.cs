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
    internal class UserModelOperation : IUserModelOperation
    {
        private IUserCRUD _userCrud;

        public UserModelOperation(IUserCRUD userCrud)
        {
            this._userCrud = userCrud;
        }

        private IUserModel Map(IUserDTO user)
        {
            return new UserModel(user.Id, user.Name, user.Surname);
        }

        public void AddUser(int userId, string name, string surname)
        {
            this._userCrud.AddUser(userId, name, surname);
        }

        public IUserModel GetUser(int userId)
        {
            return this.Map(this._userCrud.GetUser(userId));
        }

        public Dictionary<int, IUserModel> GetUsers()
        {
            Dictionary<int, IUserModel> users = new Dictionary<int, IUserModel>();

            foreach (IUserDTO user in (this._userCrud.GetUsers()).Values)
            {
                users.Add(user.Id, this.Map(user));
            }

            return users;
        }

        public void UpdateUser(int userId, string name, string surname)
        {
            this._userCrud.UpdateUser(userId, name, surname);
        }

        public void DeleteUser(int userId)
        {
            this._userCrud.DeleteUser(userId);
        }

        public int GetUsersCount()
        {
            return this._userCrud.GetUsersCount();
        }
    }
}
