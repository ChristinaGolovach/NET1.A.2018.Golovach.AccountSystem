using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities.Accounts;
using BLL.Interface.Entities.Owners;

namespace BLL.Interface.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAllAccounts();
        IEnumerable<Account> GetAllAccountsByOwnerPassport(string passportNumber);
        Account GetAccount(string accountNumber);
        
        //TODO By id
        //Account GetAccount(int id);

        //TODO ById Owner
        string OpenAccount(AccountType accountType, string passportNumber, decimal initialBalance = 0M);
        string OpenAccount(AccountType accountType, string passportNumber, string firstName, string lastName, string email, decimal initialBalance = 0M);

        void CloseAccount(string accountNumber);
        //TODO By id
        //void CloseAccount(int id);

        //TODO By id for All
        void Deposit(string accountNumber, decimal amount);
        void Withdraw(string accountNumber, decimal amount);
        void Transfer(string fromAccountNumber, string toAccountNumber, decimal amount);

        IEnumerable<Owner> GetAllOwners();
        Owner GetOwner(string passportNumber);
        //TODO by ID
        //Owner GetOwner(int id);

    }
}
