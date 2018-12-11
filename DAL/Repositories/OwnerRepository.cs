using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using ORMDBFirst;

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
            throw new NotImplementedException();
        }

        public OwnerDTO GetByPassportNumber(string passportNumber)
        {
            throw new NotImplementedException();
        }

        public void Update(OwnerDTO owner)
        {
            throw new NotImplementedException();
        }
    }
}
