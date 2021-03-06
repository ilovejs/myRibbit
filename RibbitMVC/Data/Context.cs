﻿using System.Data.Entity;

namespace RibbitMVC.Data
{
    public class Context:IContext
    {
        private readonly DbContext _db;

        public Context(IRibbitRepository ribbits = null, 
                       DbContext context = null, 
                       IUserRepository users = null)
        {
            _db = context ?? new RibbitDatabase();
            Users = users ?? new UserRepository(_db, true);
            Ribbits = ribbits ?? new RibbitRepository(_db, true);
        }

        public IUserRepository Users { get; private set; }
        public IRibbitRepository Ribbits { get; private set; }

        public void Dispose()
        {
            if (_db != null)
            {
                try
                {
                    _db.Dispose();
                }catch {}
            }
        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }
    }
}