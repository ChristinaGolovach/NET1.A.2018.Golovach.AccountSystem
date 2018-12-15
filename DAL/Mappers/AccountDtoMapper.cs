using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using ORMDBFirst;

namespace DAL.Mappers
{
    internal static class AccountDtoMapper
    {
        public static AccountDTO ToAccountDTO(this Account accountOrm)
        {
            return new AccountDTO()
            {
                Id = accountOrm.Id,
                AccountTypeId = accountOrm.AccountTypeId,
                Number = accountOrm.Number,
                Balance = accountOrm.Balance,
                BonusPoints = accountOrm.BonusPoints,
                IsOponed = accountOrm.IsOponed,
                Owner = accountOrm.AccountOwner.ToOwnerDTO()
            };
        }

        public static Account ToAccountORM(this AccountDTO accountDTO)
        {
            return new Account()
            {
                Id = accountDTO.Id,
                AccountOwnerId = accountDTO.Id,
                AccountTypeId = accountDTO.AccountTypeId,
                Number = accountDTO.Number,
                Balance = accountDTO.Balance,
                BonusPoints = accountDTO.BonusPoints,
                IsOponed = accountDTO.IsOponed
                //TODO Owner
            };
        }
    }
}
