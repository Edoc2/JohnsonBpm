using FrameWork.Framework.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.EntityFramework.Repository
{
    public class EfBaseRepository<TDbContext, TEntity> : BaseRepository<TEntity>
        where TEntity : class
        where TDbContext : DbContext
    {
        protected virtual TDbContext Context { get { return _dbContextProvider.DbContext; } }

        protected virtual DbSet<TEntity> Table { get { return Context.Set<TEntity>(); } }

        private readonly IDbContextProvider<TDbContext> _dbContextProvider;

        public EfBaseRepository(IDbContextProvider<TDbContext> dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public override IQueryable<TEntity> Entity
        {
            get
            {
                return Table;
            }
        }

        public override IQueryable<TEntity> GetAll()
        {
            return Table;
        }

        public override TEntity Insert(TEntity entity)
        {
            return Table.Add(entity);
        }

        public override TEntity Update(TEntity entity)
        {
            AttachIfNot(entity);
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public override void Delete(TEntity entity)
        {
            AttachIfNot(entity);
            Table.Remove(entity);
        }

        protected virtual void AttachIfNot(TEntity entity)
        {
            if (!Table.Local.Contains(entity))
            {
                Table.Attach(entity);
            }
        }
    }
}
