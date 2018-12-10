using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Interfaces;
using DAL.Interface.DTO;

namespace DAL.Fake.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private List<AccountDTO> accounts;

        public AccountRepository()
        {
            accounts = new List<AccountDTO>();
        }

        public void Add(AccountDTO account)
        {
            accounts.Add(account);
        }

        public void Update(AccountDTO account)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AccountDTO> GetAll()
        {
            return accounts;
        }

        public AccountDTO GetByNumber(string number)
        {
            //TODO EQUALS ??
            return accounts.FirstOrDefault(x => x.Number == number);
        }
    }
}
