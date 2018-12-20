using System;
using System.Collections.Generic;
using System.Linq;
using BLL.ServiceImplementation;
using BLL.Interface.Entities;
///using BLL.Factories;
using DAL.Interface.DTO;
using BLL.Models.Factories;
using BLL.Models.Accounts;

namespace BLL.Mappers
{
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

        //public static AccountEntity ToAccountEntity(this AccountDTO accountDTO)
        //{
        //    AccountFactory factory = FactoryCollection.Factories.FirstOrDefault(f => (int)f.AccountType == accountDTO.AccountTypeId);

        //    AccountEntity account = factory.CreateAccount(accountDTO.Number, accountDTO.Owner.ToOwner(), accountDTO.Balance);
        //    account.Id = accountDTO.Id;
        //    account.BonusPoints = accountDTO.BonusPoints;
        //    account.IsOponed = accountDTO.IsOponed;

        //    return account;
        //}

        public static Account ToAccount(this AccountDTO accountDTO)
        {
            AccountFactory factory = FactoryCollection.Factories.FirstOrDefault(f => (int)f.AccountType == accountDTO.AccountTypeId);
            Account account = factory.CreateAccount(accountDTO.Number, accountDTO.Owner.ToOwner(), accountDTO.Balance);
            account.Id = accountDTO.Id;
            account.BonusPoints = accountDTO.BonusPoints;
            account.IsOponed = accountDTO.IsOponed;

            return account;
        }

        //TODO think about this copy-past
        public static AccountDTO ToAcountDTO(this Account account)
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

        //TODO in another class move (instead use select)
        public static IEnumerable<TOutput> ForEeach<TOutput, TInput>(this IEnumerable<TInput> accounts, Func<TInput, TOutput> transform)
        {
            foreach (var item in accounts)
            {
                yield return transform(item);
            }
        }

    }
}
