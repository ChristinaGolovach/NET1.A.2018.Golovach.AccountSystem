using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities.Accounts.Utils
{
    internal static class AccountUtils
    {
        public static int CalculateBonusPoints(decimal balanceCost, decimal balance, decimal amauntCost, decimal money)
        {
            return (int)(balanceCost * balance + amauntCost * money);
        }

        public static bool IsAllowedToWithdraw(decimal allowedBalanceMinus, decimal balance, decimal money)
        {
            if (allowedBalanceMinus <= (balance - money))
            {
                return true;
            }

            return false;
        }
    }
}
