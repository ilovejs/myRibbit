using System;
using System.Linq;
using System.Linq.Expressions;

namespace RibbitMVC.Data
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> All();

        bool Any(Expression<Func<T, bool>> predicate);

        int Count { get; }

        T Create(T t);

        int Delete(T t);
        int Delete(Expression<Func<T, bool>> predicate);  //del multiple base on criteria

        T Find(params object[] keys);                     //what is params
        T Find(Expression<Func<T, bool>> predicate);
        
        IQueryable<T> FindAll(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, int index, int size);

        int Update(T t);        
    }
}