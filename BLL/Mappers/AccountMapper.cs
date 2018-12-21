using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using DAL.Interface.DTO;
using BLL.Models.Factories;
using BLL.Models.Accounts;

namespace BLL.Mappers
{
    //TODO validation
    internal static class AccountMapper
    {
        public static AccountDTO ToAccauntDTO(this AccountEntity accountEntity)
        {
            OwnerDTO ownerDTO = accountEntity.Owner.ToOwnerDTO();

            AccountDTO accountDTO = new AccountDTO()
            {
                Id = accountEntity.Id,
                Number = accountEntity.Number,
                AccountTypeId = accountEntity.AccountType.Id,
                Balance = accountEntity.Balance,
                BonusPoints = accountEntity.BonusPoints,
                IsOponed = accountEntity.IsOponed,
                Owner = ownerDTO
            };

            return accountDTO;
        }

        //TODO think about this copy-past
        public static AccountDTO ToAccountDTO(this Account account)
        {
            OwnerDTO ownerDTO = account.Owner.ToOwnerDTO();

            AccountDTO accountDTO = new AccountDTO()
            {
                Id = account.Id,
                Number = account.Number,
                AccountTypeId = (int)account.AccountType,
                Balance = account.Balance,
                BonusPoints = account.BonusPoints,
                IsOponed = account.IsOponed,
                Owner = ownerDTO
            };

            return accountDTO;
        }

        public static AccountEntity ToAccountEntity(this AccountDTO accountDTO)
        {
            AccountEntity accountEntity = new AccountEntity()
            {
                Id = accountDTO.Id,
                AccountType = new AccountTypeEntity() { Id = accountDTO.AccountTypeId },
                Number = accountDTO.Number,
                Balance = accountDTO.Balance,
                BonusPoints = accountDTO.BonusPoints,
                IsOponed = accountDTO.IsOponed,
                Owner = accountDTO.Owner.ToOwnerEntity()              
            };

            return accountEntity;
        }

        public static Account ToAccount(this AccountDTO accountDTO)
        {
            AccountFactory factory = FactoryCollection.Factories.FirstOrDefault(f => (int)f.AccountType == accountDTO.AccountTypeId);
            Account account = factory.CreateAccount(accountDTO.Number, accountDTO.Owner.ToOwner(), accountDTO.Balance);
            account.Id = accountDTO.Id;
            account.BonusPoints = accountDTO.BonusPoints;
            account.IsOponed = accountDTO.IsOponed;

            return account;
        }

        //TODO in another class move (instead use select)
        public static IEnumerable<TOutput> ForEeach<TOutput, TInput>(this IEnumerable<TInput> collection, Func<TInput, TOutput> transform)
        {
            foreach (var item in collection)
            {
                yield return transform(item);
            }
        }
    }
}
