using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<AccountEntity> GetAllAccounts();
        IEnumerable<AccountEntity> GetAllAccountsByOwnerPassport(string passportNumber);
        AccountEntity GetAccount(string accountNumber);
        
        //TODO By id
        //Account GetAccount(int id);

        //TODO ById Owner
        string OpenAccount(int idAccountType, string passportNumber, decimal initialBalance = 0M);
        string OpenAccount(int idAccountType, string passportNumber, string firstName, string lastName, string email, decimal initialBalance = 0M);

        void CloseAccount(string accountNumber);
        //TODO By id
        //void CloseAccount(int id);

        //TODO By id for All
        void Deposit(string accountNumber, decimal amount);
        void Withdraw(string accountNumber, decimal amount);
        void Transfer(string fromAccountNumber, string toAccountNumber, decimal amount);

        IEnumerable<OwnerEntity> GetAllOwners();
        OwnerEntity GetOwner(string passportNumber);
        //TODO by ID
        //Owner GetOwner(int id);

        //TODO Get All types of account

    }
}
