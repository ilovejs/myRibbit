using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RibbitMVC.Models;

namespace RibbitMVC.Data
{
    public class UserProfileRepository : EfRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(DbContext context, bool sharedContext) 
            : base(context, sharedContext) { }
    }
}