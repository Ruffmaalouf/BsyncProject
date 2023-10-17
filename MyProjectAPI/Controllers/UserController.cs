using Microsoft.AspNetCore.Mvc;
using MyProjectAPI.DTOs;
using MyProjectBusinessRules.Interfaces;
using ProjectModels;

namespace MyProjectAPI.Controllers
{

    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITransactionService _transactionservice;
        private readonly IAccountService _accountService;
        public UserController(IUserService userService, ITransactionService transactionserv,
                IAccountService accountService)
        {
            _userService = userService;
            _transactionservice = transactionserv;
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userService.GetAllUsers();
            var userDTOs = users.Select(user => new UserDTO
            {
                Id = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                // Other user properties
            });
            return Ok(userDTOs);
        }

        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetUser(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            var userDTO = new UserDTO
            {
                Id = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                // Other user properties
            };
            return Ok(userDTO);
        }

        [HttpGet("api/user/{userId}")]
        public IActionResult GetUserInformation(int userId)
        {
            // Fetch user information, balance, and transactions
            var user = _userService.GetUserById(userId);
            var balance = _accountService.GetAccountByUer(userId);
            var transactions = _transactionservice.GetTransactionsForAccount(balance.Id);

            // Construct a response object
            var userInformation = new UserInformation
            {
                Name = user.FirstName,
                Surname = user.LastName,
                Accounts = new AccountInfo
                {
                    Balance = balance.Balance,
                    Transactions = transactions
                }
            };

            return Ok(userInformation);
        }

    }

}
