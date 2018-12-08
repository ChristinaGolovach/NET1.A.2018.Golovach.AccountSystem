using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities.Accounts;
using BLL.Interface.Entities.Owners;

namespace BLL.Factories
{
    //TODO MAKE INTERNAL
    public abstract class AccountFactory
    {
        internal abstract AccountType AccountType { get; }

        internal abstract Account CreateAccount(string accountNumber, Owner owner, decimal initialBalance = 0M);
    }
}
