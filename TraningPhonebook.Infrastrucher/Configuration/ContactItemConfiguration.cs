using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TraningPhonebook.Core;

namespace TraningPhonebook.Infrastrucher.Configuration
{
    public class ContactItemConfiguration : IEntityTypeConfiguration<ContactItem>
    {
        public void Configure(EntityTypeBuilder<ContactItem> builder)
        {
            builder.Property(CI => CI.Value).HasMaxLength(50);
           // builder.HasOne(CI => CI.ItemType).WithOne(CT => CT.ContactItem).HasForeignKey<ContactType>(CT => CT.ContactItemId);
        }
    }

}
