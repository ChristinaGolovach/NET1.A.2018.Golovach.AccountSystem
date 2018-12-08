using BLL.Interface.Entities.Accounts;
using BLL.Interface.Entities.Owners;

namespace BLL.Factories
{
    public class PlatinumAccountFactory : AccountFactory
    {
        internal override AccountType AccountType => AccountType.PLATINUM; 

        internal override Account CreateAccount(string accountNumber, Owner owner, decimal initialBalance = 0M)
        {
            return new PlatinumAccount(accountNumber, owner, initialBalance);
        }
    }
}
