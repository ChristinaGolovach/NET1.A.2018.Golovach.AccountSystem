using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models.Accounts.Utils;
using BLL.Models.Owners;

namespace BLL.Models.Accounts
{
    public class GoldenAccount : Account
    {
        private const decimal BALANSECOST = 0.3M;
        private const decimal AMAUNTCOST = 0.3M;
        private const decimal ALLOWEDBALANCEMINUS = -300M;

        public override AccountType AccountType => AccountType.GOLDEN;

        public GoldenAccount(string accountNumber, Owner owner, decimal initialBalance = 0M) : base(accountNumber, owner, initialBalance) { }

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
