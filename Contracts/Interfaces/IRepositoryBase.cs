using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Contracts.Interfaces
{
    public interface IRepositoryBase<T>
    {
        List<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void CreateMany(List<T> entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
