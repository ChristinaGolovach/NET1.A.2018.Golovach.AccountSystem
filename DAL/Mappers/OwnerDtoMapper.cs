using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using ORMDBFirst;

namespace DAL.Mappers
{
    internal static class OwnerDtoMapper
    {
        public static OwnerDTO ToOwnerDTO(this AccountOwner ownerOrm)
        {
            return new OwnerDTO()
            {
                Id = ownerOrm.Id,
                FirstName = ownerOrm.FirstName,
                LastName = ownerOrm.LastName,
                PassportNumber = ownerOrm.PassportNumber,
                Email = ownerOrm.Email
            };
        }

        public static AccountOwner ToOwnerORM(this OwnerDTO ownerDto)
        {
            return new AccountOwner()
            {
                Id = ownerDto.Id,
                FirstName = ownerDto.FirstName,
                LastName = ownerDto.LastName,
                PassportNumber = ownerDto.PassportNumber,
                Email = ownerDto.Email
            };
        }
    }
}
