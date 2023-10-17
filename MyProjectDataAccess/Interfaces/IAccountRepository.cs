using ProjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectDataAccess.Interfaces
{
    public interface IAccountRepository
    {
        int AddAccount(Account account);
        Account GetAccount(int accountId);
        Account GetAccountByUserID(int userId); 
    }
}
