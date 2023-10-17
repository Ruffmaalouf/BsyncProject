using ProjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectBusinessRules.Interfaces
{
    public interface IAccountService
    {
        Account OpenAccount(int UserId, decimal initialCredit);
        Account GetAccount(int accountId);
        Account GetAccountByUer(int userID);
        IEnumerable<Account> GetAccounts();
        IEnumerable<Transaction> GetAccountTransactions(int accountId);
    }
}
