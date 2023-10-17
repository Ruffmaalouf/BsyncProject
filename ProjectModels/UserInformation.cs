using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModels
{
    public class UserInformation
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public AccountInfo Accounts { get; set; }
    }

    public class AccountInfo
    {
        public decimal Balance { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
    }

}
