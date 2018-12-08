using BLL.Interface.Entities.Accounts;
using BLL.Interface.Entities.Owners;

namespace BLL.Factories
{
    public class GoldenAccountFactory : AccountFactory
    {
        internal override AccountType AccountType => AccountType.GOLDEN;

        internal override Account CreateAccount(string accountNumber, Owner owner, decimal initialBalance = 0M)
        {
            return new GoldenAccount(accountNumber, owner, initialBalance);
        }
    }
}
