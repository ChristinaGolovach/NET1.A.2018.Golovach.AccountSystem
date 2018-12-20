using BLL.Models.Accounts;
using BLL.Models.Owners;

namespace BLL.Models.Factories
{
    public class GoldenAccountFactory : AccountFactory
    {
        public override AccountType AccountType => AccountType.GOLDEN;

        public override Account CreateAccount(string accountNumber, Owner owner, decimal initialBalance = 0M)
        {
            return new GoldenAccount(accountNumber, owner, initialBalance);
        }
    }
}
