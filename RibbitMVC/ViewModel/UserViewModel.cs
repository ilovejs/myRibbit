using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RibbitMVC.Models;

namespace RibbitMVC.ViewModel
{
    public class UserViewModel
    {
        public User User { get; set; }
        public IEnumerable<Ribbit> Ribbits { get; set; }
    }
}