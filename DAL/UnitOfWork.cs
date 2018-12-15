using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Interface.Interfaces;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext DbContext { get; private set; }

        public UnitOfWork(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Commit()
        {
            if (DbContext != null)
            {
                DbContext.SaveChanges();
            }
        }

        public void Dispose()
        {
            if (DbContext != null)
            {
                DbContext.Dispose();
            }
        }
    }
}
