using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TraningPhonebook.Core;

namespace TraningPhonebook.Infrastrucher.Configuration
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(CC => CC.LastName).HasMaxLength(30);
            builder.Property(CC => CC.FirstName).HasMaxLength(20);
            builder.Property(CC => CC.Note).HasMaxLength(100);
            builder.Property(CC => CC.Title).HasMaxLength(50);
        }
    }

}
