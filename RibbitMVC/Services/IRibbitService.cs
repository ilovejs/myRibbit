using System;
using System.Collections.Generic;
using RibbitMVC.Models;

namespace RibbitMVC.Services
{
    public interface IRibbitService
    {
        Ribbit GetBy(int id);
        Ribbit Create(int userId, string status, DateTime? created = null);
        Ribbit Create(User user, string status, DateTime? created = null);
        IEnumerable<Ribbit> GetTimelineFor(int userId);
    }
}