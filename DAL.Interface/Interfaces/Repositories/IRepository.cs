using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        //T GetById(int id);
        void Add(T t);
        void Update(T t);        
    }
}
