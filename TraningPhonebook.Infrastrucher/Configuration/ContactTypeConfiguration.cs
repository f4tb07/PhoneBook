using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TraningPhonebook.Core;

namespace TraningPhonebook.Infrastrucher.Configuration
{
    public class ContactTypeConfiguration : IEntityTypeConfiguration<ContactType>
    {
        public void Configure(EntityTypeBuilder<ContactType> builder)
        {
            builder.Property(CT => CT.Name).HasMaxLength(20);
        }
    }

}
