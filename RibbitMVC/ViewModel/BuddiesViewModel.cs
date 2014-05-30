﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RibbitMVC.Models;

namespace RibbitMVC.ViewModel
{
    public class BuddiesViewModel
    {
        public User User { get; set; }
        public IEnumerable<User> Buddies { get; set; } 
    }
}