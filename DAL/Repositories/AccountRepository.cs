using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using ORMDBFirst;
using System.Linq.Expressions;

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
            throw new NotImplementedException();
        }

        public IEnumerable<AccountDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public AccountDTO GetByNumber(string number)
        {
            throw new NotImplementedException();
        }

        public AccountDTO GetByPredicate(Expression<Func<AccountDTO, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Update(AccountDTO account)
        {
            throw new NotImplementedException();
        }

        IEnumerable<AccountDTO> IRepository<AccountDTO>.GetByPredicate(Expression<Func<AccountDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
