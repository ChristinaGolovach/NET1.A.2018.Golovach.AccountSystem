using System;
using System.Collections.Generic;
using BLL.Interface.Interfaces;
using BLL.Interface.Entities;
using BLL.Mappers;
using BLL.Models.Owners;
using DAL.Interface.Interfaces;


namespace BLL.ServiceImplementation
{
    public class OwnerService : IOwnerService
    {
        private IOwnerRepository ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            this.ownerRepository = ownerRepository;
        }

        public OwnerEntity CreateOwner(string passportNumber, string firstName, string lastName, string email)
        {
            OwnerEntity existingOwner = ownerRepository.GetByPassportNumber(passportNumber)?.ToOwnerEntity();

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

            return owner.ToOwnerEntity();
        }

        public IEnumerable<OwnerEntity> GetAllOwners()
        {
            return ownerRepository.GetAll().ForEeach(dto => dto.ToOwnerEntity());
        }

        public OwnerEntity FindByPassport(string passportNumber)
        {
            return ownerRepository.GetByPassportNumber(passportNumber)?.ToOwnerEntity();
        }
    }
}
