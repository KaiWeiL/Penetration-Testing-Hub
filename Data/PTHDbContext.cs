using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Penetration_Testing_Hub.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Penetration_Testing_Hub.Data
{
    public class PTHDbContext : IdentityDbContext
    {
        public PTHDbContext(DbContextOptions<PTHDbContext> options): base(options)
        {
        }

        public DbSet<PTHThread> PTHThreads { get; set; }
        public DbSet<PTHPost> PTHPosts { get; set; }
    }
}
