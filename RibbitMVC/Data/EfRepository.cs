using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Razor.Parser.SyntaxTree;
using RibbitMVC.Data;

namespace RibbitMVC.Data
{
    public class EfRepository<T> : IRepository<T> 
        where T: class
    {
        protected DbContext Context;
        protected readonly bool ShareContext;

        //call second constructor
        public EfRepository(DbContext context) : this(context, false) { }

        public EfRepository(DbContext context, bool sharedContext)
        {
            Context = context;
            ShareContext = sharedContext;
        } 

        //since we use EF, we use this property to dump data
        protected DbSet<T> DbSet
        {
            get { return Context.Set<T>(); }
        }

        public IQueryable<T> All()
        {
            return DbSet.AsQueryable();
        }

        public bool Any(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return DbSet.Any(predicate);
        }

        public int Count
        {
            get { return DbSet.Count(); }
        }

        public T Create(T t)
        {
            DbSet.Add(t);
            if (!ShareContext)
            {
                Context.SaveChanges();
            }
            return t;
        }

        public int Delete(T t)
        {
            DbSet.Remove(t);
            if (!ShareContext)
            {
                Context.SaveChanges();
            }
            return 0;
        }

        public int Delete(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            var records = FindAll(predicate);
            foreach (var record in records)
            {
                DbSet.Remove(record);
            }
            if (!ShareContext)
            {
                Context.SaveChanges();
            }
            return 0;
        }

        public T Find(params object[] keys)
        {
            return DbSet.Find(keys);
        }

        public T Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return DbSet.SingleOrDefault(predicate);
        }

        public IQueryable<T> FindAll(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate).AsQueryable();
        }

        public IQueryable<T> FindAll(System.Linq.Expressions.Expression<Func<T, bool>> predicate, int index, int size)
        {
            var skip = index * size; //amount to skip
            IQueryable<T> query = DbSet;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (skip != 0)
            {
                query = query.Skip(skip);
            }

            return query.Take(size).AsQueryable();
        }

        public int Update(T t)
        {
            var entry = Context.Entry(t);
            //good to place it here
            DbSet.Attach(t);

            entry.State = System.Data.EntityState.Modified;
            if (!ShareContext)
            {
                return Context.SaveChanges();
            }
            return 0; 
        }

        public void Dispose()
        {
            //If shared context, sth else might need context, so not to dispose.
            if (!ShareContext && Context != null)
            {
                try
                {
                    Context.Dispose();
                }
                catch { }
            }
        }
    }
}