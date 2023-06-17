using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryLogic.API;

namespace LibraryPresentation.Model
{
    public interface IUserModelOperation
    {
        static IUserModelOperation CreateModelOperation(IUserCRUD? userCrud = null)
        {
            return new UserModelOperation(userCrud ?? IUserCRUD.CreateUserCRUD());
        }

        void AddUser(int userId, string name, string surname);
        IUserModel GetUser(int userId);
        Dictionary<int, IUserModel> GetUsers();
        void UpdateUser(int userId, string name, string surname);
        void DeleteUser(int userId);
        int GetUsersCount();
    }
}
