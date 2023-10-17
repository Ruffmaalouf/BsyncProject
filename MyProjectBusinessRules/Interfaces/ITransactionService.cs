using ProjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectBusinessRules.Interfaces
{
    public interface ITransactionService
    {
        void AddTransaction(Transaction transaction);
        IEnumerable<Transaction> GetTransactionsForAccount(int accountId);
        IEnumerable<Transaction> GetTransactions();
        Transaction GetTransaction(int id);
    }
}
