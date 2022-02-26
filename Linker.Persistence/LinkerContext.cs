using Linker.Domain.Entities;
using Linker.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linker.Persistence
{
    public class LinkerContext : DbContext
    {
        public virtual DbSet<Link> Links { get; set; }

        public LinkerContext(DbContextOptions<LinkerContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new LinkConfiguration());
        }
    }
}
