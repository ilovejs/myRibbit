﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RibbitMVC.Models;

namespace RibbitMVC.Data
{
    public class UserRepository :EfRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context, bool sharedContext)
            :base(context, sharedContext){}

        public IQueryable<User> All(bool includeProfile)
        {
            //load profile OR call empty All() from EfRepository 
            return includeProfile ? DbSet.Include(u => u.Profile).AsQueryable() : All();
        }

        public void CreateFollower(string username, User follower)
        {
            var user = GetBy(username);
            DbSet.Attach(follower);
            user.Followers.Add(follower);

            if (!ShareContext)
            {
                Context.SaveChanges();
            }
        }

        public void DeleteFollower(string username, User follower)
        {
            var user = GetBy(username);
            DbSet.Attach(follower);
            //instead, call Remove
            user.Followers.Remove(follower);

            if (!ShareContext)
            {
                Context.SaveChanges();
            }
        }

        //get user by id
        public User GetBy(
                int id,
                bool includeProfile = false,
                bool includeRibbits = false,
                bool includeFollowers = false,
                bool includeFollowing = false)
        {
            var query = BuildUserQuery(includeProfile, includeRibbits, includeFollowers, includeFollowing);

            return query.SingleOrDefault(u => u.Id == id);
        }

        private IQueryable<User> BuildUserQuery(bool includeProfile, bool includeRibbits, bool includeFollowers, bool includeFollowing)
        {
            var query = DbSet.AsQueryable();

            if (includeProfile)
                query = DbSet.Include(u => u.Profile);
            if (includeRibbits)
                query = DbSet.Include(u => u.Followers);
            if (includeFollowers)
                query = DbSet.Include(u => u.Followers);
            if (includeFollowing)
                query = DbSet.Include(u => u.Followings);
            return query;
        }

        //get user by username
        public User GetBy(
            string username,
            bool includeProfile = false,
            bool includeRibbits = false,
            bool includeFollowers = false,
            bool includeFollowing = false)
        {

            var query = BuildUserQuery(includeProfile, includeRibbits, includeFollowers, includeFollowing);

            return query.SingleOrDefault(u => u.Username == username);
        }
    }
}