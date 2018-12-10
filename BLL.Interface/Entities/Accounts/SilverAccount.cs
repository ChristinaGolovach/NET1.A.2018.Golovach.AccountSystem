using BLL.Interface.Entities.Accounts.Utils;
using BLL.Interface.Entities.Owners;

namespace BLL.Interface.Entities.Accounts
{
    public class SilverAccount : Account
    {
        private const decimal BALANSECOST = 0.2M;
        private const decimal AMAUNTCOST = 0.2M;
        private const decimal ALLOWEDBALANCEMINUS = -200M;

        public override AccountType AccountType => AccountType.SILVER;

        public SilverAccount(string accountNumber, Owner owner, decimal initialBalance = 0M) : base (accountNumber, owner, initialBalance) { }

        protected override int CalculateBonusPoints(decimal money)
        {
            return this.CalculateBonusPoints(BALANSECOST, Balance, AMAUNTCOST, money);
        }

        protected override bool IsAllowedToWithdraw(decimal money)
        {
            return this.IsAllowedToWithdraw(ALLOWEDBALANCEMINUS, Balance, money);
        }
    }
}
