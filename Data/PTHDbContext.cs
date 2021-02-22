using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Penetration_Testing_Hub.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Penetration_Testing_Hub.Data
{
    public class PTHDbContext : DbContext
    {
        public PTHDbContext(DbContextOptions<PTHDbContext> options): base(options)
        {
        }

        public DbSet<StageTechnique_Reconnaissance_Tool> StageTechnique_Reconnaissance_Tools { get; set; }
        public DbSet<StageTechnique_Reconnaissance_Tool_Post> StageTechnique_Reconnaissance_Tool_Posts { get; set; }
    }
}
