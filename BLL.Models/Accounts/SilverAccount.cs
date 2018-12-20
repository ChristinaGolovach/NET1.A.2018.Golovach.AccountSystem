using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models.Accounts.Utils;
using BLL.Models.Owners;

namespace BLL.Models.Accounts
{
    public class SilverAccount : Account
    {
        private const decimal BALANSECOST = 0.2M;
        private const decimal AMAUNTCOST = 0.2M;
        private const decimal ALLOWEDBALANCEMINUS = -200M;

        public override AccountType AccountType => AccountType.SILVER;

        public SilverAccount(string accountNumber, Owner owner, decimal initialBalance = 0M) : base(accountNumber, owner, initialBalance) { }

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
