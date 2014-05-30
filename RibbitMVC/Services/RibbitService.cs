using System;
using System.Net.Http.Headers;
using RibbitMVC.Data;
using RibbitMVC.Models;

namespace RibbitMVC.Services
{
    public class RibbitService : IRibbitService
    {
        private readonly IContext _context;
        private readonly IRibbitRepository _ribbits;

        public RibbitService(IContext context)
        {
            _context = context;
            _ribbits = context.Ribbits;
        }

        public Ribbit GetBy(int id)
        {
            return _ribbits.GetBy(id);
        }

        public Ribbit Create(User user, string status, DateTime? created = null)
        {
            var ribbit = new Ribbit()
            {
                Status = status,
                DateCreated = created.HasValue ? created.Value : DateTime.Now
            };

            _ribbits.AddFor(ribbit, user);
            _context.SaveChanges();
            return ribbit; 
        }
    }
}