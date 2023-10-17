using System; 
using System.Data.SqlClient;
using System.Data; 
using ProjectModels;
using MyProjectDataAccess.Interfaces;
using Dapper;

namespace MyProjectDataAccess.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDbConnection _dbConnection;

        public AccountRepository(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        public Account GetAccount(int accountId)
        {
            return _dbConnection.QueryFirstOrDefault<Account>(
                "SELECT * FROM Accounts WHERE Id = @Id",
                new { Id = accountId }
            );
        }
        public Account GetAccountByUserID(int userId)
        {
            return _dbConnection.QueryFirstOrDefault<Account>(
                "SELECT * FROM Accounts WHERE UserId = @Id",
                new { Id = userId }
            );
        }

        public int AddAccount(Account account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            var sql = "INSERT INTO Accounts (UserId, Balance) VALUES (@UserId, @Balance); SELECT CAST(SCOPE_IDENTITY() as int)";
            return _dbConnection.ExecuteScalar<int>(sql, account);
        }
         
    }
}
