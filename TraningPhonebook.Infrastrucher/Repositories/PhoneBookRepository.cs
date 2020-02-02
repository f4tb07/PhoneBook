using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using TraningPhonebook.Core;
using TraningPhonebook.Infrastrucher.Configuration;
using System.Linq;

namespace TraningPhonebook.Infrastrucher
{
    public class PhoneBookRepository : DbContext
    {
        public PhoneBookRepository( DbContextOptions options) : base(options)
        {
        }

        public DbSet<ContactType> ContactTypeTable { get; set; }
        public DbSet<ContactItem> ContactItemTable { get; set; }
        public DbSet<Contact> ContactTable { get; set; }
        public DbSet<User> UserTable { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(" ");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new ContactItemConfiguration());
            modelBuilder.ApplyConfiguration(new ContactTypeConfiguration());
            base.OnModelCreating(modelBuilder);

        }
    }
}
