﻿// <auto-generated />
using System;
using JudoSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JudoSystem.Migrations
{
    [DbContext(typeof(JudoDbContext))]
    [Migration("20200131132830_firstMigration")]
    partial class firstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("JudoSystem.Models.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("TextEN")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.Property<string>("TextLT")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.Property<string>("TextRU")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("Gender");
                });

            modelBuilder.Entity("JudoSystem.Models.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.Property<int?>("OrganizationTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationTypeId");

                    b.ToTable("Organization");
                });

            modelBuilder.Entity("JudoSystem.Models.OrganizationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("TypeNameEN")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.Property<string>("TypeNameLT")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.Property<string>("TypeNameRU")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("OrganizationType");
                });

            modelBuilder.Entity("JudoSystem.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("JudoSystem.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateUpdated")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.Property<int?>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<int?>("ParentUserId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("ParentUserId");

                    b.HasIndex("StatusId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("JudoSystem.Models.Organization", b =>
                {
                    b.HasOne("JudoSystem.Models.OrganizationType", "OrganizationType")
                        .WithMany()
                        .HasForeignKey("OrganizationTypeId");
                });

            modelBuilder.Entity("JudoSystem.Models.User", b =>
                {
                    b.HasOne("JudoSystem.Models.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId");

                    b.HasOne("JudoSystem.Models.User", "ParentUser")
                        .WithMany()
                        .HasForeignKey("ParentUserId");

                    b.HasOne("JudoSystem.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");
                });
#pragma warning restore 612, 618
        }
    }
}
