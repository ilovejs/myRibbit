using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class mzDb : DbContext
    {
        public mzDb()
            : base("connection1")
        {

        }

        public DbSet<Buyer> Buyers;
    }
}