using MyProjectBusinessRules.Interfaces;
using MyProjectDataAccess.Interfaces;
using MyProjectDataAccess.Repositories;
using ProjectModels;
using System;
using System.Collections.Generic; 

namespace MyProjectBusinessRules.Services
{
     
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public void AddTransaction(Transaction transaction)
        { 
            _transactionRepository.AddTransaction(transaction);
        }

        public Transaction GetTransaction(int id)
        {
            _transactionRepository.GetTransactionById(id);
            Transaction Trans = _transactionRepository.GetTransactionById(id);

            return Trans;
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            IEnumerable<Transaction> Trans = _transactionRepository.GetTransactions();
            return Trans;
        }

        public IEnumerable<Transaction> GetTransactionsForAccount(int accountId)
        { 
            return _transactionRepository.GetTransactionsByAccountID(accountId);
        }
    }

}
