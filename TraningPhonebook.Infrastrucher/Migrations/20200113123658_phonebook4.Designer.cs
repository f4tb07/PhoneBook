﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TraningPhonebook.Infrastrucher;

namespace TraningPhonebook.Infrastrucher.Migrations
{
    [DbContext(typeof(PhoneBookRepository))]
    [Migration("20200113123658_phonebook4")]
    partial class phonebook4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TraningPhonebook.Core.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("RelatedUserId")
                        .HasColumnType("int");

                    b.Property<bool>("Scope")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("RelatedUserId");

                    b.ToTable("ContactTable");
                });

            modelBuilder.Entity("TraningPhonebook.Core.ContactItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RelatedContactId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("RelatedContactId");

                    b.ToTable("ContactItemTable");
                });

            modelBuilder.Entity("TraningPhonebook.Core.ContactType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContactItemId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Icon")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("ContactItemId")
                        .IsUnique();

                    b.ToTable("ContactTypeTable");
                });

            modelBuilder.Entity("TraningPhonebook.Core.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("PersonelId")
                        .HasColumnType("nvarchar(6)")
                        .HasMaxLength(6);

                    b.Property<int>("ProfileContact")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserTable");
                });

            modelBuilder.Entity("TraningPhonebook.Core.Contact", b =>
                {
                    b.HasOne("TraningPhonebook.Core.User", "RelatedUser")
                        .WithMany("ContactList")
                        .HasForeignKey("RelatedUserId");
                });

            modelBuilder.Entity("TraningPhonebook.Core.ContactItem", b =>
                {
                    b.HasOne("TraningPhonebook.Core.Contact", "RelatedContact")
                        .WithMany("ContactItems")
                        .HasForeignKey("RelatedContactId");
                });

            modelBuilder.Entity("TraningPhonebook.Core.ContactType", b =>
                {
                    b.HasOne("TraningPhonebook.Core.ContactItem", "ContactItem")
                        .WithOne("ItemType")
                        .HasForeignKey("TraningPhonebook.Core.ContactType", "ContactItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
