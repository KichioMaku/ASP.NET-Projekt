using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projekt_.net.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_.net.Database
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<OrderEntity> Orders { get; set; }
        public AppDbContext(DbContextOptions options)
            : base(options)
        {

        }
    }
}
