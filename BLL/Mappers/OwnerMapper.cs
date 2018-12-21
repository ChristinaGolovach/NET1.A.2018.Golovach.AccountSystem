using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Models.Owners;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    //TODO validation 
    internal static class OwnerMapper
    {
        public static OwnerDTO ToOwnerDTO(this OwnerEntity ownerEntity)
        {
            return new OwnerDTO()
            {
                Id = ownerEntity.Id,
                FirstName = ownerEntity.FirstName,
                LastName = ownerEntity.LastName,
                PassportNumber = ownerEntity.PassportNumber,
                Email = ownerEntity.Email                               
            };
        }

        public static OwnerDTO ToOwnerDTO(this Owner owner)
        {
            return new OwnerDTO()
            {
                Id = owner.Id,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                PassportNumber = owner.PassportNumber,
                Email = owner.Email
            };
        }

        public static OwnerEntity ToOwnerEntity(this OwnerDTO ownerDto)
        {
            return new OwnerEntity()
            {
                Id = ownerDto.Id,
                FirstName = ownerDto.FirstName,
                LastName = ownerDto.LastName,
                PassportNumber = ownerDto.PassportNumber,
                Email = ownerDto.Email                
            };
        }

        public static OwnerEntity ToOwnerEntity(this Owner owner)
        {
            return new OwnerEntity()
            {
                Id = owner.Id,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                PassportNumber = owner.PassportNumber,
                Email = owner.Email
            };
        }

        public static Owner ToOwner (this OwnerEntity ownerEntity)
        {
            Owner owner = new Owner(ownerEntity.PassportNumber, ownerEntity.FirstName, ownerEntity.LastName, ownerEntity.PassportNumber);
            owner.Id = ownerEntity.Id;

            return owner;
        }

        public static Owner ToOwner(this OwnerDTO ownerDto)
        {
            Owner owner = new Owner(ownerDto.PassportNumber, ownerDto.FirstName, ownerDto.LastName, ownerDto.PassportNumber);
            owner.Id = ownerDto.Id;

            return owner;
        }
    }
}
