using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Penetration_Testing_Hub.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal.ExternalLoginModel;

namespace Penetration_Testing_Hub.Data
{
    public class PTHDbContext : IdentityDbContext
    {
        public PTHDbContext(DbContextOptions<PTHDbContext> options): base(options)
        {
        }

   //     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   //     {
   //optionsBuilder.UseMySQL("server=localhost;database=library;user=user;password=password");
   //     }

        public DbSet<PTHThread> PTHThreads { get; set; }
        public DbSet<PTHPost> PTHPosts { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
