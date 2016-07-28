using FrameWork.EntityFramework;
using FrameWork.EntityFramework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   public  class DemoRepository <TEntity> : EfBaseRepository<DemoDBEntities, TEntity>
        where TEntity : class
    {
        private readonly IDbContextProvider<DemoDBEntities> _dbContextProvider;
        public DemoRepository(IDbContextProvider<DemoDBEntities> dbContextProvdier)
            : base(dbContextProvdier)
        {
            _dbContextProvider = dbContextProvdier;
        }
    }
}
