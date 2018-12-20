using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    //TODO Internal and friendly for BLL
    public interface IOwnerService
    {
        IEnumerable<OwnerEntity> GetAllOwners();
        OwnerEntity CreateOwner(string passportNumber, string firstName, string lastName, string email);
        OwnerEntity FindByPassport(string passportNumber);
    }
}
