using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities.Accounts;
using BLL.Interface.Entities.Owners;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    internal static class OwnerMapper
    {
        public static OwnerDTO ToOwnerDTO(this Owner owner)
        {
            return new OwnerDTO()
            {
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                PassportNumber = owner.PassportNumber,
                Email = owner.Email
                //я заціклюсь здесь
                //Accounts = owner.Accounts.Select(a => a.ToAccauntDTO())                
                //TODO Id
            };
        }

        public static OwnerDTO ToOwnerDTO(this Owner owner, Account accounts)
        {
            OwnerDTO ownerDTO =  new OwnerDTO()
            {
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                PassportNumber = owner.PassportNumber,
                Email = owner.Email
                //я заціклюсь здесь
                //Accounts = owner.Accounts.Select(a => a.ToAccauntDTO())                
                //TODO Id
            };

           // ownerDTO.Accounts.ToList().Add(new AccountDTO() { });

            return ownerDTO;
        }

        public static Owner ToOwner(this OwnerDTO ownerDTO)
        {
            Owner owner = new Owner(ownerDTO.PassportNumber, ownerDTO.FirstName, ownerDTO.LastName, ownerDTO.Email);

            //здесь я тоже заціклюсь
            //owner.AttachAccounts(ownerDTO.Accounts.ForEeach(dto => dto.ToAccount()));

            return owner;
        }
    }
}
