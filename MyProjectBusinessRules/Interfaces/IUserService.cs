using ProjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectBusinessRules.Interfaces
{
    public interface IUserService
    {
        UserModel GetUserById(int userId);
        IEnumerable<UserModel> GetAllUsers();
        // Add other user-related methods as needed
    }
}
