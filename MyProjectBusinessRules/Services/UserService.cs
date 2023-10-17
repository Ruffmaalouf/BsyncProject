using MyProjectBusinessRules.Interfaces;
using MyProjectDataAccess.Interfaces;
using ProjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectBusinessRules.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository; // You'll need to inject the repository

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserModel GetUserById(int userId)
        {
            // Implement the logic to fetch a user by ID from the repository
            UserModel user = _userRepository.GetUserById(userId);

            if (user == null)
            {
                return null; // Handle the case when the user is not found
            }
             
            return user;
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            // Implement the logic to fetch all users from the repository
            IEnumerable<UserModel> users = _userRepository.GetAllUsers();
             
            return users;
        }


         
    }

}
