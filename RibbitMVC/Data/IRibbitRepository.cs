using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RibbitMVC.Data;
using RibbitMVC.Models;

namespace RibbitMVC.Data
{
    public interface IRibbitRepository : IRepository<Ribbit>
    {
        Ribbit GetBy(int id);
        IEnumerable<Ribbit> GetFor(User user);
        void AddFor(Ribbit ribbit, User user);

    }
}