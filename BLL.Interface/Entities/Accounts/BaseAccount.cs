using BLL.Interface.Entities.Accounts.Utils;
using BLL.Interface.Entities.Owners;

namespace BLL.Interface.Entities.Accounts
{
    public class BaseAccount : Account
    {
        //хранить здесь коэф. в каждом классе и не передавать из вне.
        // но если их требуется изменить ?????
        private const decimal BALANSECOST = 0.1M;
        private const decimal AMAUNTCOST = 0.1M;
        private const decimal ALLOWEDBALANCEMINUS = -100M;

        public override AccountType AccountType => AccountType.BASE;

        public BaseAccount(string accountNumber, Owner owner, decimal initialBalance = 0M) : base (accountNumber, owner, initialBalance)
        {

        }

        protected override int CalculateBonusPoints(decimal amount)
        {
            return this.CalculateBonusPoints(BALANSECOST, Balance, AMAUNTCOST, amount);//AccountUtils.CalculateBonusPoints(this, BALANSECOST, Balance, AMAUNTCOST, amount);
        }

        protected override bool IsAllowedToWithdraw(decimal amount)
        {
            return this.IsAllowedToWithdraw(ALLOWEDBALANCEMINUS, Balance, amount);
        }
    }
}
