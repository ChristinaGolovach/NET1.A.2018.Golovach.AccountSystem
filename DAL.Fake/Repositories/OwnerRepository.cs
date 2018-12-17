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
    public class OwnerFakeRepository : IOwnerRepository
    {
        private List<OwnerDTO> owners;

        public OwnerFakeRepository()
        {
            owners = new List<OwnerDTO>();
        }

        public void Add(OwnerDTO owner)
        {
            if (ReferenceEquals(owner, null))
            {
                throw new ArgumentNullException($"The {nameof(owner)} can not be null.");
            }

            owners.Add(owner);
        }

        public void Update(OwnerDTO owner)
        {
            if (ReferenceEquals(owner, null))
            {
                throw new ArgumentNullException($"The {nameof(owner)} can not be null.");
            }

            OwnerDTO ownerForUpdate = owners.FirstOrDefault(x => x.PassportNumber == owner.PassportNumber);

            ownerForUpdate.FirstName = owner.FirstName;
            ownerForUpdate.LastName = owner.LastName;
            ownerForUpdate.Email = owner.Email;
        }

        public IEnumerable<OwnerDTO> GetAll()
        {
            return owners;
        }
        
        public OwnerDTO GetByPassportNumber(string passportNumber)
        {
            if (ReferenceEquals(passportNumber, null))
            {
                throw new ArgumentNullException($"The {nameof(passportNumber)} can not be null.");
            }

            return owners.FirstOrDefault(x => x.PassportNumber.Equals(passportNumber, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<OwnerDTO> GetByPredicate(Expression<Func<OwnerDTO, bool>> f)
        {
            throw new NotImplementedException();
        }

        public OwnerDTO Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
