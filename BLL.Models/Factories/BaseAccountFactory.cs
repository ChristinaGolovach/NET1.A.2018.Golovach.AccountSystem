using BLL.Models.Accounts;
using BLL.Models.Owners;

namespace BLL.Models.Factories
{
    public class BaseAccountFactory : AccountFactory
    {
        public override AccountType AccountType => AccountType.BASE;

        public override Account CreateAccount(string accountNumber, Owner owner, decimal initialBalance = 0M)
        {
            return new BaseAccount(accountNumber, owner, initialBalance);
        }
    }
}
