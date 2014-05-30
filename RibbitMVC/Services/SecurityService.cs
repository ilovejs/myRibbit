﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.SessionState;
using RibbitMVC.Models;
using RibbitMVC.ViewModel;

namespace RibbitMVC.Services
{
    public class SecurityService: ISecurityService
    {
        private readonly IUserService _users;
        private readonly HttpSessionState _session;

        public SecurityService(IUserService users, HttpSessionState session = null)
        {
            _users = users;
            _session = session ?? HttpContext.Current.Session;
        }

        public bool Authenticate(string username, string password)
        {
            var user = _users.GetBy(username);
            if (user == null)
            {
                return false;
            }
            //match the encrypted password
            return Crypto.VerifyHashedPassword(user.Password, password);
        }

        public User CreateUser(SignupViewModel signupModel, bool login = true)
        {
            var user = _users.Create(signupModel.Username, signupModel.Password, new UserProfile()
            {
                Email = signupModel.Email
            });
            
            if (login) //true
            {
                Login(user);
            }
            return user;
        }

        public bool DoesUserExist(string username)
        {
            return _users.GetBy(username) != null;
        }

        public User GetCurrentUser()
        {
            return _users.GetBy(UserId);
        }

        public bool IsAuthenticated {
            //return _session["UserId"] != null;
            get { return UserId > 0; }
        }

        public void Login(User user)
        {
            _session["UserId"] = user.Id;
        }

        public void Login(string username)
        {
            var user = _users.GetBy(username);
            Login(user);
        }

        public void Logout()
        {
            _session.Abandon();
        }

        public int UserId
        {
            //will convert null to zero
            get { return Convert.ToInt32(_session["UserId"]); }
            set { _session["UserId"] = value; }
        }
    }
}