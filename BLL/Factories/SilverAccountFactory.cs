using BLL.Interface.Entities.Accounts;
using BLL.Interface.Entities.Owners;

namespace BLL.Factories
{
    public class SilverAccountFactory : AccountFactory
    {
        internal override AccountType AccountType => AccountType.SILVER;

        internal override Account CreateAccount(string accountNumber, Owner owner, decimal initialBalance = 0M)
        {
            return new SilverAccount(accountNumber, owner, initialBalance);
        }
    }
}
