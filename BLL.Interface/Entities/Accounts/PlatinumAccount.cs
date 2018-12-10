using BLL.Interface.Entities.Accounts.Utils;
using BLL.Interface.Entities.Owners;

namespace BLL.Interface.Entities.Accounts
{
    public class PlatinumAccount : Account
    {
        private const decimal BALANSECOST = 0.4M;
        private const decimal AMAUNTCOST = 0.4M;
        private const decimal ALLOWEDBALANCEMINUS = -400M;

        public override AccountType AccountType => AccountType.PLATINUM;

        public PlatinumAccount(string accountNumber, Owner owner, decimal initialBalance = 0M) : base (accountNumber, owner, initialBalance) { }

        protected override int CalculateBonusPoints(decimal amount)
        {
            return this.CalculateBonusPoints( BALANSECOST, Balance, AMAUNTCOST, amount);
        }

        protected override bool IsAllowedToWithdraw(decimal amount)
        {
            return this.IsAllowedToWithdraw(ALLOWEDBALANCEMINUS, Balance, amount);
        }
    }
}
