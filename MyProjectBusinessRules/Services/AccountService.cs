using MyProjectBusinessRules.Interfaces;
using MyProjectBusinessRules.Services;
using MyProjectDataAccess.Interfaces;
using ProjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectBusinessRules
{
     

    // AccountService.cs
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionService _transactionService;

        public AccountService(IAccountRepository accountRepository, ITransactionService transactionService)
        {
            _accountRepository = accountRepository;
            _transactionService = transactionService;
        }

        public Account OpenAccount(int UserId, decimal initialCredit)
        {
            // Implement account opening logic
            var account = new Account { UserId = UserId };
            if (initialCredit > 0)
            {
                // Create a transaction for the initial credit
                var transaction = new Transaction { AccountId = account.Id, Amount = initialCredit };
                _transactionService.AddTransaction(transaction);
            }
            _accountRepository.AddAccount(account);
            return account;
        }

        public Account GetAccount(int accountId)
        {
            // Implement get account logic
            return _accountRepository.GetAccount(accountId);
        }

        public IEnumerable<Transaction> GetAccountTransactions(int accountId)
        {
            // Implement get account transactions logic
            return _transactionService.GetTransactionsForAccount(accountId);
        }

        public Account GetAccountByUserID(int userid)
        {
            return _accountRepository.GetAccountByUserID(userid);
        }

        public Account GetAccountByUer(int userID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> GetAccounts()
        {
            throw new NotImplementedException();
        }
    }
 



}
