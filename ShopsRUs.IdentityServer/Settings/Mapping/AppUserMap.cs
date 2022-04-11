using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopsRUs.IdentityServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.IdentityServer.Settings.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(30).IsRequired();

            builder.Property(x => x.SurName).HasMaxLength(30).IsRequired();

            builder.Property(x => x.IsEmployee).IsRequired();

            builder.Property(x => x.IsMember).IsRequired();
        }
    }
}
