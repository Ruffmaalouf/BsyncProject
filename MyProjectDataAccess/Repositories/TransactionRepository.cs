using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectDataAccess.Repositories
{
    using Dapper;
    using MyProjectDataAccess.Interfaces;
    using ProjectModels;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class TransactionRepository : ITransactionRepository
    {
        private readonly IDbConnection _connectionString;

        public TransactionRepository(string connectionString)
        {
            _connectionString = new SqlConnection(connectionString);
        }

        public IEnumerable<Transaction> GetTransactionsByUserId(int userId)
        {
            _connectionString.Open();
            string query = "SELECT * FROM Transactions WHERE UserId = @UserId";
            var transactions = _connectionString.Query<Transaction>(query, new { UserId = userId });
            _connectionString.Close();
            return transactions;
        }
        public Transaction GetTransactionById(int transactionId)
        {
            _connectionString.Open();
            string query = "SELECT * FROM Transactions WHERE TransactionId = @TransactionId";
            var transaction = _connectionString.QueryFirstOrDefault<Transaction>(query, new { TransactionId = transactionId });
            _connectionString.Close();
            return transaction;
        }
        public int AddTransaction(Transaction transaction)
        {
            _connectionString.Open();
            string insertQuery = "INSERT INTO Transactions (UserId, Amount, Description, TransactionDate) " +
                "VALUES (@UserId, @Amount, @Description, @TransactionDate); SELECT CAST(SCOPE_IDENTITY() as int)";
            var res = _connectionString.QuerySingle<int>(insertQuery, transaction);
            _connectionString.Close();
            return res;
        }
        public bool UpdateTransaction(Transaction transaction)
        {
            _connectionString.Open();
            string updateQuery = "UPDATE Transactions SET Amount = @Amount, Description = @Description, " +
                "TransactionDate = @TransactionDate WHERE TransactionId = @TransactionId";
            var update = _connectionString.Execute(updateQuery, transaction) > 0;
            _connectionString.Close();
            return update;
        }
        public bool DeleteTransaction(int transactionId)
        {
            _connectionString.Open();
            string deleteQuery = "DELETE FROM Transactions WHERE TransactionId = @TransactionId";
            var delete = _connectionString.Execute(deleteQuery, new { TransactionId = transactionId }) > 0;
            _connectionString.Close();
            return delete;
        }
        public IEnumerable<Transaction> GetTransactionsByAccountID(int accountId)
        {
            _connectionString.Open();
            string query = "SELECT * FROM Transactions WHERE AccountId = @AccountId";
            var transactions = _connectionString.Query<Transaction>(query, new { AccountId = accountId });
            _connectionString.Close();
            return transactions;
        }
        public IEnumerable<Transaction> GetTransactions()
        {
            _connectionString.Open();
            string query = "SELECT * FROM Transactions ";
            var transactions = _connectionString.Query<Transaction>(query);
            _connectionString.Close();
            return transactions;
        }
    }

}
