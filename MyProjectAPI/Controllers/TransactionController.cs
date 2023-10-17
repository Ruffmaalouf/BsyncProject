using Microsoft.AspNetCore.Mvc;
using MyProjectAPI.DTOs;
using MyProjectBusinessRules.Interfaces;
using System.Transactions;
using ProjectModels;
namespace MyProjectAPI.Controllers
{
        [ApiController]
        [Route("api/transactions")]
        public class TransactionController : ControllerBase
        {
            private readonly ITransactionService _transactionService;

            public TransactionController(ITransactionService transactionService)
            {
                _transactionService = transactionService;
            }

            [HttpGet]
            public IActionResult GetTransactions()
            {
                var transactions = _transactionService.GetTransactions();
                var transactionDTOs = transactions.Select(transaction => new TransactionDTO
                {
                    Id = transaction.Id,
                    Amount = transaction.Amount,
                    // Other transaction properties
                });
                return Ok(transactionDTOs);
            }

            [HttpPost]
            public IActionResult CreateTransaction([FromBody] TransactionDTO transactionDTO)
            {
                var transaction = new ProjectModels.Transaction
                {
                    Amount = transactionDTO.Amount,
                    // Other transaction properties
                };
                _transactionService.AddTransaction(transaction);
                var createdTransactionDTO = new TransactionDTO
                {
                    Id = transaction.Id,
                    Amount = transaction.Amount,
                    // Other transaction properties
                };
                return CreatedAtAction(nameof(GetTransaction), new { id = createdTransactionDTO.Id }, createdTransactionDTO);
            }

            [HttpGet("{id}", Name = "GetTransaction")]
            public IActionResult GetTransaction(int id)
            {
                var transaction = _transactionService.GetTransaction(id);
                if (transaction == null)
                {
                    return NotFound();
                }
                var transactionDTO = new TransactionDTO
                {
                    Id = transaction.Id,
                    Amount = transaction.Amount,
                    // Other transaction properties
                };
                return Ok(transactionDTO);
            }
        }

    
}
