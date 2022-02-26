using Linker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linker.Persistence.Configuration
{
    public class LinkConfiguration : IEntityTypeConfiguration<Link>
    {
        public void Configure(EntityTypeBuilder<Link> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
