using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Interfaces;
using BLL.Interface.Entities.Owners;
using BLL.Interface.Entities.Accounts;
using DAL.Interface.Interfaces;
using BLL.Mappers;

namespace BLL.ServiceImplementation
{
    public class OwnerService : IOwnerService
    {
        private IEnumerable<Owner> owners;
        private IOwnerRepository ownerRepository;

        public IEnumerable<Owner> Owners
        {
            get => owners;
        }

        public OwnerService(IOwnerRepository ownerRepository)
        {
            this.ownerRepository = ownerRepository;
            owners = ownerRepository.GetAll().ForEeach(dto => dto.ToOwner());
        }

        public Owner CreateOwner(string passportNumber, string firstName, string lastName, string email)
        {
            Owner existingOwner = ownerRepository.GetByPassportNumber(passportNumber)?.ToOwner();

            if (!ReferenceEquals(existingOwner, null))
            {
                if (existingOwner.FirstName.Equals(firstName, StringComparison.CurrentCultureIgnoreCase) && (existingOwner.LastName.Equals(lastName, StringComparison.CurrentCultureIgnoreCase)))
                {
                    return existingOwner;
                }

                throw new InvalidOperationException($"The owner with passport number {passportNumber} already exists.");
            }

            Owner owner = new Owner(passportNumber.ToUpperInvariant(), firstName, lastName, email);

            ownerRepository.Add(owner.ToOwnerDTO());

            return owner;
        }

        //public void OpenNewAccount(Owner owner, Account account)
        //{            
        //    owner.OpenAccount(account);
        //}

        public Owner FindByPassport(string passportNumber)
        {
            return ownerRepository.GetByPassportNumber(passportNumber)?.ToOwner();
        }

    }
}
