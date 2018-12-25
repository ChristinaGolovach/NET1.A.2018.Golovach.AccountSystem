using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interface.Entities;
using MvcPL.ViewModels;

namespace MvcPL.Infrastructure.Mappers
{
    public static class AccountMvcMapper
    {
        public static AccountViewModel ToAccountVM (this AccountEntity accountEntity)
        {
            return new AccountViewModel()
            {
                Id = accountEntity.Id,
                AccountTypeId = accountEntity.AccountType.Id,
                OwnerId = accountEntity.Owner.Id,
                Number = accountEntity.Number,
                Balance = accountEntity.Balance,
                BonusPoints = accountEntity.BonusPoints,
                IsOponed = accountEntity.IsOponed
            };
        }

        public static AccountEntity ToAccountEntity (this AccountViewModel accountViewModel)
        {
            return new AccountEntity()
            {
                Id = accountViewModel.Id,
                AccountType = new AccountTypeEntity() { Id = accountViewModel.Id },
                Number = accountViewModel.Number,
                Owner = new OwnerEntity() { Id = accountViewModel.OwnerId },
                Balance = accountViewModel.Balance,
                BonusPoints = accountViewModel.BonusPoints,
                IsOponed = accountViewModel.IsOponed
            };
        }
    }
}