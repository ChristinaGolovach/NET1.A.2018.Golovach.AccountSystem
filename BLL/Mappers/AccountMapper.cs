﻿using System;
using System.Collections.Generic;
using System.Linq;
using BLL.ServiceImplementation;
using BLL.Interface.Entities.Accounts;
using BLL.Factories;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    internal static class AccountMapper
    {
        public static AccountDTO ToAccauntDTO(this Account account)
        {
           OwnerDTO ownerDTO = account.Owner.ToOwnerDTO();
            
           AccountDTO accountDTO = new AccountDTO()
            {
                Number = account.Number,
                IdAccountType = (int)account.AccountType,
                Balance = account.Balance,
                BonusPoints = account.BonusPoints,
                IsOponed = account.IsOponed,
                //TODO Owner or IDOwner
                Owner = ownerDTO
           };

            //TODO ASK почему не добавляется!!!!!!!!!!!!!!!!!!!!!!!!
           // ownerDTO.Accounts.ToList<AccountDTO>().Add(accountDTO);
           // accountDTO.Owner.Accounts.ToList<AccountDTO>().Add(accountDTO);

           return accountDTO;
        }

        public static Account ToAccount(this AccountDTO accountDTO)
        {
            AccountFactory factory = FactoryCollection.Factories.FirstOrDefault(f => (int)f.AccountType == accountDTO.IdAccountType);

            Account account = factory.CreateAccount(accountDTO.Number, accountDTO.Owner.ToOwner(), accountDTO.Balance);
            account.BonusPoints = accountDTO.BonusPoints;
            account.IsOponed = accountDTO.IsOponed;

            return account;
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