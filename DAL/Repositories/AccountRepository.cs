﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using DAL.Mappers;
using ORMDBFirst;

namespace DAL.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DbContext dbContext;

        public AccountRepository(DbContext context)
        {
            dbContext = context;
        }

        public void Add(AccountDTO account)
        {
             dbContext.Set<Account>().Add(account.ToAccountORM());
        }

        public IEnumerable<AccountDTO> GetAll()
        {
            return dbContext.Set<Account>().Include(account => account.AccountOwner).AsEnumerable().Select(a => a.ToAccountDTO());
        }

        public AccountDTO Get(int id)
        {
            return dbContext.Set<Account>().Find(id)?.ToAccountDTO();
        }

        public AccountDTO GetByNumber(string number)
        {
            return dbContext.Set<Account>().FirstOrDefault(account => account.Number == number)?.ToAccountDTO();
        }

        public IEnumerable<AccountDTO> GetByPredicate(Expression<Func<AccountDTO, bool>> predicate)
        {
            //TODO ExpressionVisitor
            throw new NotImplementedException();
        }

        public void Update(AccountDTO account)
        {
            //TODO if null
            Account accountForUpdate = dbContext.Set<Account>().Find(account.Id);

            accountForUpdate.Balance = account.Balance;
            accountForUpdate.BonusPoints = account.BonusPoints;
            accountForUpdate.IsOponed = account.IsOponed;
        }
    }
}
