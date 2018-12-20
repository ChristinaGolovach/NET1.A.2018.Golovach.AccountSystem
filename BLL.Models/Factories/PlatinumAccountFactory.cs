using BLL.Models.Accounts;
using BLL.Models.Owners;

namespace BLL.Models.Factories
{
    public class PlatinumAccountFactory : AccountFactory
    {
        public override AccountType AccountType => AccountType.PLATINUM;

        public override Account CreateAccount(string accountNumber, Owner owner, decimal initialBalance = 0M)
        {
            return new PlatinumAccount(accountNumber, owner, initialBalance);
        }
    }
}
