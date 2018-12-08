using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities.Accounts;

namespace BLL.Interface.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAllAccounts();
        string CreateAccount(AccountType accountType, string passportNumber, decimal initialBalance = 0M);
        string CreateAccount(AccountType accountType, string passportNumber, string firstName, string lastName, string email, decimal initialBalance = 0M);
        void CloseAccount(string accountNumber);
        void PutMoney(string accountNumber, decimal amount);
        void TakeMoney(string accountNumber, decimal amount);
        void TransferMoney(string fromAccountNumber, string toAccountNumber, decimal amount);

    }
}
