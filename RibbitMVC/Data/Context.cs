using System.Data.Entity;
using System.Web.Configuration;

namespace RibbitMVC.Data
{
    public class Context: IContext
    {
        private readonly DbContext _db;

        public Context(IRibbitRepository ribbits = null, 
                       DbContext context = null, 
                       IUserRepository users = null,
                       IUserProfileRepository profiles = null)
        {
            _db = context ?? new RibbitDatabase();
            Users = users ?? new UserRepository(_db, true);
            Ribbits = ribbits ?? new RibbitRepository(_db, true);
            Profiles = profiles ?? new UserProfileRepository(_db, true);
        }

        public IUserRepository Users { get; private set; }
        public IRibbitRepository Ribbits { get; private set; }
        public IUserProfileRepository Profiles{ get; private set; }
        
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