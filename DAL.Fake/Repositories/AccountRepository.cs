using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Interfaces;
using DAL.Interface.DTO;
using System.Linq.Expressions;

namespace DAL.Fake.Repositories
{
    public class AccountFakeRepository : IAccountRepository
    {
        private List<AccountDTO> accounts;

        public AccountFakeRepository()
        {
            accounts = new List<AccountDTO>();
        }

        public void Add(AccountDTO account)
        {
            accounts.Add(account);
        }

        public void Update(AccountDTO account)
        {
            AccountDTO accountForUpdate = GetByNumber(account.Number);

            accountForUpdate.IsOponed = account.IsOponed;
            accountForUpdate.Balance = account.Balance;
            accountForUpdate.BonusPoints = account.BonusPoints;
        }

        public IEnumerable<AccountDTO> GetAll()
        {
            return accounts;
        }

        public AccountDTO GetByNumber(string number)
        {
            return accounts.FirstOrDefault(x => x.Number == number);
        }

        //TODO подумать - не все лямбды могут быть преобраз . в деревья. может ошибка возникнуть при выполнения этого метода
        public IEnumerable<AccountDTO> GetByPredicate(Expression<Func<AccountDTO, bool>> predicate)
        {
            var compiled = predicate.Compile();            
            IEnumerable <AccountDTO> matchedAccounts = accounts.Where(compiled).ToList();
            return matchedAccounts;
        }

        public AccountDTO Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
