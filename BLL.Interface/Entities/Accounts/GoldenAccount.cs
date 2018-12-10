using BLL.Interface.Entities.Accounts.Utils;
using BLL.Interface.Entities.Owners;

namespace BLL.Interface.Entities.Accounts
{
    public class GoldenAccount : Account
    {
        private const decimal BALANSECOST = 0.3M;
        private const decimal AMAUNTCOST = 0.3M;
        private const decimal ALLOWEDBALANCEMINUS = -300M;

        public override AccountType AccountType => AccountType.GOLDEN;

        public GoldenAccount(string accountNumber, Owner owner, decimal initialBalance = 0M) : base (accountNumber, owner, initialBalance) { }

        protected override int CalculateBonusPoints(decimal amount)
        {
            return this.CalculateBonusPoints(BALANSECOST, Balance, AMAUNTCOST, amount);
        }

        protected override bool IsAllowedToWithdraw(decimal amount)
        {
            return this.IsAllowedToWithdraw(ALLOWEDBALANCEMINUS, Balance, amount);
        }
    }
}
