using ProjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectDataAccess.Interfaces
{
    public interface IUserRepository
    {
        UserModel GetUserById(int userId);
        List<UserModel> GetAllUsers();
        int CreateUser(UserModel user);
    }
}
