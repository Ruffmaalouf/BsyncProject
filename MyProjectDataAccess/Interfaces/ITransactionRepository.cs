using ProjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectDataAccess.Interfaces
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> GetTransactionsByUserId(int userId);
        IEnumerable<Transaction> GetTransactions();
        IEnumerable<Transaction> GetTransactionsByAccountID(int accountId);
        Transaction GetTransactionById(int transactionId);
        int AddTransaction(Transaction transaction);
        bool UpdateTransaction(Transaction transaction);
        bool DeleteTransaction(int transactionId);

        // Add other transaction-related method signatures here
    }

}
