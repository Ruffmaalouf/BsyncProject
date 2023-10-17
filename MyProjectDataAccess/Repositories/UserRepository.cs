using MyProjectDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ProjectModels;

namespace MyProjectDataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public UserModel GetUserById(int userId)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                return dbConnection.QueryFirstOrDefault<UserModel>("SELECT * FROM Users WHERE UserId = @UserId", new { UserId = userId });
            }
        }

        public List<UserModel> GetAllUsers()
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                return dbConnection.Query<UserModel>("SELECT * FROM Users").AsList();
            }
        }

        public int CreateUser(UserModel user)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                const string query = "INSERT INTO Users (FirstName, LastName) VALUES (@FirstName, @LastName); SELECT CAST(SCOPE_IDENTITY() as int)";
                return dbConnection.QuerySingle<int>(query, user);
            }
        }
    }
}
