using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using ORMDBFirst;
using DAL.Mappers;

namespace DAL.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DbContext dbContext;

        public OwnerRepository(DbContext context)
        {
            dbContext = context;
        }

        public void Add(OwnerDTO owner)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OwnerDTO> GetAll()
        {
            return dbContext.Set<AccountOwner>().AsEnumerable().Select(a => a.ToOwnerDTO());
        }

        //TODO Delete this method. due to the fact I have GetByPredicate
        public OwnerDTO GetByPassportNumber(string passportNumber)
        {
            return dbContext.Set<AccountOwner>().FirstOrDefault(owner => owner.PassportNumber == passportNumber).ToOwnerDTO();
        }

        public IEnumerable<OwnerDTO> GetByPredicate(Expression<Func<OwnerDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(OwnerDTO owner)
        {
            throw new NotImplementedException();
        }
    }
}
