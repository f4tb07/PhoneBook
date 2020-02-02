using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TraningPhonebook.Core;

namespace TraningPhonebook.Infrastrucher.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(U => U.PersonelId).HasMaxLength(6);
            builder.Property(U => U.Password).HasMaxLength(10);
        }
    }

}
