using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Framework.Infrastructure.Repository
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
          where TEntity : class
    {
        public abstract IQueryable<TEntity> GetAll();

        public abstract IQueryable<TEntity> Entity { get; }

        public virtual List<TEntity> GetAllList()
        {
            return GetAll().ToList();
        }

        public virtual List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).ToList();
        }

        public virtual T Query<T>(Func<IQueryable<TEntity>, T> queryMethod)
        {
            return queryMethod(GetAll());
        }

        public virtual TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Single(predicate);
        }

        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().FirstOrDefault(predicate);
        }

        public abstract TEntity Insert(TEntity entity);

        public abstract TEntity Update(TEntity entity);

        public virtual int Count()
        {
            return GetAll().Count();
        }

        public virtual int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).Count();
        }

        public virtual long LongCount()
        {
            return GetAll().LongCount();
        }

        public virtual long LongCount(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).LongCount();
        }

        public abstract void Delete(TEntity entity);

        public virtual void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            foreach (var entity in GetAll().Where(predicate).ToList())
            {
                Delete(entity);
            }
        }
    }
}
