using BLL.Models.Accounts;
using BLL.Models.Owners;

namespace BLL.Models.Factories
{
    public class SilverAccountFactory : AccountFactory
    {
        public override AccountType AccountType => AccountType.SILVER;

        public override Account CreateAccount(string accountNumber, Owner owner, decimal initialBalance = 0M)
        {
            return new SilverAccount(accountNumber, owner, initialBalance);
        }
    }
}
