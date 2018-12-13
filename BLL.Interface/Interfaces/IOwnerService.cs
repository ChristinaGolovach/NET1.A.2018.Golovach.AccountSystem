using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities.Accounts;
using BLL.Interface.Entities.Owners;

namespace BLL.Interface.Interfaces
{
    //TODO Internal and friendly for BLL
    public interface IOwnerService
    {
        IEnumerable<Owner> Owners { get; }
        Owner CreateOwner(string passportNumber, string firstName, string lastName, string email);
        //void OpenNewAccount(Owner owner, Account account);
        Owner FindByPassport(string passportNumber);
    }
}
