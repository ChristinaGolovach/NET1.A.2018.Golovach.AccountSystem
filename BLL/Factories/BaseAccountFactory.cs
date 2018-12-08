using BLL.Interface.Entities.Accounts;
using BLL.Interface.Entities.Owners;

namespace BLL.Factories
{
    public class BaseAccountFactory : AccountFactory
    {
        internal override AccountType AccountType => AccountType.BASE;

        internal override Account CreateAccount(string accountNumber, Owner owner, decimal initialBalance = 0M)
        {
            return new BaseAccount(accountNumber, owner, initialBalance);
        }
    }
}
