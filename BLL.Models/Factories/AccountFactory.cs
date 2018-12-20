using BLL.Models.Accounts;
using BLL.Models.Owners;

namespace BLL.Models.Factories
{
    //TODO think internal and friendly
    public abstract class AccountFactory
    {
        public abstract AccountType AccountType { get; }

        public abstract Account CreateAccount(string accountNumber, Owner owner, decimal initialBalance = 0M);
    }
}
