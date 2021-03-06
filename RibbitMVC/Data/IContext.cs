﻿using System;

namespace RibbitMVC.Data
{
    //handle shared context
    public interface IContext :IDisposable
    {
        IUserRepository Users { get; }
        IRibbitRepository Ribbits { get; }
        int SaveChanges();
    }
}