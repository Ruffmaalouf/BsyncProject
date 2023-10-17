using Microsoft.AspNetCore.Mvc;
using MyProjectAPI.DTOs;
using MyProjectBusinessRules.Interfaces;
using ProjectModels;
using System.Security.Principal;

namespace MyProjectAPI.Controllers
{
    
        [ApiController]
        [Route("api/accounts")]
        public class AccountController : ControllerBase
        {
            private readonly IAccountService _accountService; // You'll inject your application service here

            public AccountController(IAccountService accountService)
            {
                _accountService = accountService;
            }

            [HttpGet]
            public IActionResult GetAccounts()
            {
                // Retrieve a list of accounts from the service
                var accounts = _accountService.GetAccounts();

                // Map the domain objects to DTOs for presentation
                var accountDTOs = accounts.Select(account => new AccountDTO
                {
                    Id = account.Id,
                    AccountNumber = account.AccountNumber,
                    Balance = account.Balance
                });

                return Ok(accountDTOs);
            }

            [HttpPost]
            public IActionResult CreateAccount([FromBody] AccountDTO accountDTO)
            {
                // Map the DTO back to a domain model
                var account = new AccountModel
                {
                    AccountNumber = accountDTO.AccountNumber,
                    Balance = accountDTO.Balance
                };

                // Create the account using the service
                _accountService.OpenAccount(accountDTO.UserID, accountDTO.InitialCredit);

                // Return the created account
                var createdAccountDTO = new AccountDTO
                {
                    Id = account.AccountId,
                    AccountNumber = account.AccountNumber,
                    Balance = account.Balance
                };

                return CreatedAtAction(nameof(GetAccount), new { id = createdAccountDTO.Id }, createdAccountDTO);
            }

            [HttpGet("{id}", Name = "GetAccount")]
            public IActionResult GetAccount(int id)
            {
                // Retrieve the account by ID from the service
                var account = _accountService.GetAccount(id);

                if (account == null)
                {
                    return NotFound();
                }

                // Map the domain object to a DTO for presentation
                var accountDTO = new AccountDTO
                {
                    Id = account.Id,
                    AccountNumber = account.AccountNumber,
                    Balance = account.Balance
                };

                return Ok(accountDTO);
            }
        }
    
}
