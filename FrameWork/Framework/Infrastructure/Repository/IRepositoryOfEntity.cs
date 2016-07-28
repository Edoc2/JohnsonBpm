using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Framework.Infrastructure.Repository
{
    public interface IRepository<TEntity> : IRepository where TEntity : class
    {
        IQueryable<TEntity> Entity { get; }

        IQueryable<TEntity> GetAll();

        List<TEntity> GetAllList();

        List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate);

        T Query<T>(Func<IQueryable<TEntity>, T> queryMethod);

        TEntity Single(Expression<Func<TEntity, bool>> predicate);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        TEntity Insert(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(Expression<Func<TEntity, bool>> predicate);

        int Count();

        int Count(Expression<Func<TEntity, bool>> predicate);

        long LongCount();

        long LongCount(Expression<Func<TEntity, bool>> predicate);
    }
}
