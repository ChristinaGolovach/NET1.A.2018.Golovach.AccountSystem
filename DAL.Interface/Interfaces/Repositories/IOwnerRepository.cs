using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;

namespace DAL.Interface.Interfaces
{
    public interface IOwnerRepository : IRepository<OwnerDTO>
    {
        //TODO хотя можно удалить. есть предикат
        OwnerDTO GetByPassportNumber(string passportNumber);
       // OwnerDTO GetByPassportNumber(string passportNumber, StringComparison stringComparison);
    }
}
