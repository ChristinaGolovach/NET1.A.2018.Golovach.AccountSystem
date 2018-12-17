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
            dbContext.Set<AccountOwner>().Add(owner.ToOwnerORM());
        }

        public OwnerDTO Get(int id)
        {
             return dbContext.Set<AccountOwner>().Find(id)?.ToOwnerDTO();
        } 

        public IEnumerable<OwnerDTO> GetAll() => dbContext.Set<AccountOwner>().AsEnumerable().Select(a => a.ToOwnerDTO());

        //TODO Delete this method. due to the fact I have GetByPredicate
        public OwnerDTO GetByPassportNumber(string passportNumber)
        {
            return dbContext.Set<AccountOwner>().FirstOrDefault(owner => owner.PassportNumber == passportNumber)?.ToOwnerDTO();
        }

        public IEnumerable<OwnerDTO> GetByPredicate(Expression<Func<OwnerDTO, bool>> predicate)
        {
            //TODO ExpressionVisitor
            throw new NotImplementedException();
        }

        public void Update(OwnerDTO owner)
        {
            //TODO if null
            AccountOwner ownerForUpdate = dbContext.Set<AccountOwner>().Find(owner.Id);

            ownerForUpdate.FirstName = owner.FirstName;
            ownerForUpdate.LastName = owner.LastName;
            ownerForUpdate.PassportNumber = owner.PassportNumber;
            ownerForUpdate.Email = owner.Email;
        }
    }
}
