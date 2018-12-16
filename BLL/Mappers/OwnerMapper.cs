﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities.Accounts;
using BLL.Interface.Entities.Owners;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    internal static class OwnerMapper
    {
        public static OwnerDTO ToOwnerDTO(this Owner owner)
        {
            return new OwnerDTO()
            {
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                PassportNumber = owner.PassportNumber,
                Email = owner.Email,
                Id = owner.Id                
            };
        }


        public static Owner ToOwner(this OwnerDTO ownerDTO)
        {
            Owner owner = new Owner(ownerDTO.PassportNumber, ownerDTO.FirstName, ownerDTO.LastName, ownerDTO.Email);
            owner.Id = ownerDTO.Id;
            return owner;
        }
    }
}
