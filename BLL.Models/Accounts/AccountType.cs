using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Accounts
{
    //TODO think  - either add const column in DB with additional id or create account by its name.
    public enum AccountType
    {
        BASE = 1,
        SILVER = 2,
        GOLDEN = 3,
        PLATINUM = 4
    }
}
