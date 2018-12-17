using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DAL.Interface.Interfaces
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetByPredicate(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(int id);
        void Add(TEntity t);
        void Update(TEntity t);      
        //TODO Transaction
    }
}
