using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RibbitMVC.Models;

namespace RibbitMVC.Data
{
    public class RibbitDatabase: DbContext
    {
        //connection string
        public RibbitDatabase(): base("RibbitConnection"){}

        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Ribbit> Ribbits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //create a table, left column: FollowingId, right column: FollowerId
            modelBuilder.Entity<User>()
                .HasMany(u => u.Followers)
                .WithMany(u => u.Followings)
                .Map(map =>
                {
                    map.MapLeftKey("FollowingId");  //column
                    map.MapRightKey("FollowerId");
                    map.ToTable("Follow");  //table name
                });

            modelBuilder.Entity<User>()
                .HasMany(u => u.Ribbits);

            base.OnModelCreating(modelBuilder);
        }
    }
}