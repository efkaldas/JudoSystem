﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Entities.Migrations
{
    [DbContext(typeof(JudoDbContext))]
    [Migration("20200414070015_alterTableOrganization")]
    partial class alterTableOrganization
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Entities.Models.AgeGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CompetitionsId")
                        .HasColumnType("int");

                    b.Property<int>("CompetitonsId")
                        .HasColumnType("int");

                    b.Property<int>("DanKyuFrom")
                        .HasColumnType("int");

                    b.Property<int>("DanKyuTo")
                        .HasColumnType("int");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.Property<int>("YearsFrom")
                        .HasColumnType("int");

                    b.Property<int>("YearsTo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionsId");

                    b.HasIndex("GenderId");

                    b.ToTable("AgeGroup");
                });

            modelBuilder.Entity("Entities.Models.Competitions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("CardPayment")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Regulations")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("Competitions");
                });

            modelBuilder.Entity("Entities.Models.Competitor", b =>
                {
                    b.Property<int>("WeightCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("JudokaId")
                        .HasColumnType("int");

                    b.HasKey("WeightCategoryId", "JudokaId");

                    b.HasIndex("JudokaId");

                    b.ToTable("Competitor");
                });

            modelBuilder.Entity("Entities.Models.DanKyu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<string>("Imagepath")
                        .HasColumnType("VARCHAR(1024)")
                        .HasMaxLength(1024);

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("DanKyu");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Grade = 1,
                            Text = "6 KYU"
                        },
                        new
                        {
                            Id = 2,
                            Grade = 2,
                            Text = "5 KYU"
                        },
                        new
                        {
                            Id = 3,
                            Grade = 3,
                            Text = "4 KYU"
                        },
                        new
                        {
                            Id = 4,
                            Grade = 4,
                            Text = "3 KYU"
                        },
                        new
                        {
                            Id = 5,
                            Grade = 5,
                            Text = "2 KYU"
                        },
                        new
                        {
                            Id = 6,
                            Grade = 5,
                            Text = "1 KYU"
                        },
                        new
                        {
                            Id = 7,
                            Grade = 7,
                            Text = "1 DAN"
                        },
                        new
                        {
                            Id = 8,
                            Grade = 8,
                            Text = "2 DAN"
                        },
                        new
                        {
                            Id = 9,
                            Grade = 9,
                            Text = "3 DAN"
                        },
                        new
                        {
                            Id = 10,
                            Grade = 10,
                            Text = "4 DAN"
                        },
                        new
                        {
                            Id = 11,
                            Grade = 11,
                            Text = "5 DAN"
                        },
                        new
                        {
                            Id = 12,
                            Grade = 12,
                            Text = "6 DAN"
                        },
                        new
                        {
                            Id = 13,
                            Grade = 13,
                            Text = "7 DAN"
                        },
                        new
                        {
                            Id = 14,
                            Grade = 14,
                            Text = "8 DAN"
                        },
                        new
                        {
                            Id = 15,
                            Grade = 15,
                            Text = "9 DAN"
                        },
                        new
                        {
                            Id = 16,
                            Grade = 16,
                            Text = "10 DAN"
                        });
                });

            modelBuilder.Entity("Entities.Models.Gender", b =>
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TextEN = "Male",
                            TextLT = "Vyras",
                            TextRU = "Mужчина"
                        },
                        new
                        {
                            Id = 2,
                            TextEN = "Female",
                            TextLT = "Moteris",
                            TextRU = "Женщина"
                        });
                });

            modelBuilder.Entity("Entities.Models.Judoka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BirthYears")
                        .HasColumnType("int");

                    b.Property<int>("DanKyuId")
                        .HasColumnType("int");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DanKyuId");

                    b.HasIndex("GenderId");

                    b.HasIndex("UserId");

                    b.ToTable("Judoka");
                });

            modelBuilder.Entity("Entities.Models.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.Property<string>("ExactName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Image")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("OrganizationTypeId")
                        .HasColumnType("int");

                    b.Property<string>("ShortName")
                        .HasColumnType("VARCHAR(128)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("OrganizationTypeId");

                    b.ToTable("Organization");
                });

            modelBuilder.Entity("Entities.Models.OrganizationType", b =>
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TypeNameEN = "Club",
                            TypeNameLT = "Klubas",
                            TypeNameRU = "Клуб"
                        },
                        new
                        {
                            Id = 2,
                            TypeNameEN = "Sports Center",
                            TypeNameLT = "Sporto Centras",
                            TypeNameRU = "Спортивный Центр"
                        },
                        new
                        {
                            Id = 3,
                            TypeNameEN = "Judges Association",
                            TypeNameLT = "Teisėjų Asociacija",
                            TypeNameRU = "Ассоциация Судей"
                        });
                });

            modelBuilder.Entity("Entities.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("RoleNameEN")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.Property<string>("RoleNameLT")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.Property<string>("RoleNameRU")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleNameEN = "Admin",
                            RoleNameLT = "Administratorius",
                            RoleNameRU = "Администратор"
                        },
                        new
                        {
                            Id = 2,
                            RoleNameEN = "Moderator",
                            RoleNameLT = "Moderatorius",
                            RoleNameRU = "Модератор"
                        },
                        new
                        {
                            Id = 3,
                            RoleNameEN = "Coach",
                            RoleNameLT = "Treneris",
                            RoleNameRU = "Тренер"
                        },
                        new
                        {
                            Id = 4,
                            RoleNameEN = "Judge",
                            RoleNameLT = "Teisėjas",
                            RoleNameRU = "Судья"
                        });
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("DanKyuId")
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

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("VARCHAR(1056)")
                        .HasMaxLength(1056);

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

                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(2);

                    b.HasKey("Id");

                    b.HasIndex("DanKyuId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("GenderId");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("ParentUserId");

                    b.HasIndex("StatusId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Entities.Models.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Entities.Models.UserStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("StatusNameEN")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.Property<string>("StatusNameLT")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.Property<string>("StatusNameRU")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("UserStatus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            StatusNameEN = "Approved",
                            StatusNameLT = "Patvirtintas",
                            StatusNameRU = "Одобренный"
                        },
                        new
                        {
                            Id = 2,
                            StatusNameEN = "Not аpproved",
                            StatusNameLT = "Nepatvirtintas",
                            StatusNameRU = "Не одобренный"
                        },
                        new
                        {
                            Id = 3,
                            StatusNameEN = "Blocked",
                            StatusNameLT = "Užblokuotas",
                            StatusNameRU = "Заблокирован"
                        });
                });

            modelBuilder.Entity("Entities.Models.WeightCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AgeGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("AgeGroupId");

                    b.ToTable("WeightCategory");
                });

            modelBuilder.Entity("Entities.Models.AgeGroup", b =>
                {
                    b.HasOne("Entities.Models.Competitions", "Competitions")
                        .WithMany("AgeGroups")
                        .HasForeignKey("CompetitionsId");

                    b.HasOne("Entities.Models.Gender", "gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.Competitor", b =>
                {
                    b.HasOne("Entities.Models.Judoka", "Judoka")
                        .WithMany("WeightCategories")
                        .HasForeignKey("JudokaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.WeightCategory", "WeightCategory")
                        .WithMany("Competitors")
                        .HasForeignKey("WeightCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.Judoka", b =>
                {
                    b.HasOne("Entities.Models.DanKyu", "DanKyu")
                        .WithMany()
                        .HasForeignKey("DanKyuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.User", "User")
                        .WithMany("Judokas")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.Organization", b =>
                {
                    b.HasOne("Entities.Models.OrganizationType", "OrganizationType")
                        .WithMany()
                        .HasForeignKey("OrganizationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.HasOne("Entities.Models.DanKyu", "DanKyu")
                        .WithMany()
                        .HasForeignKey("DanKyuId");

                    b.HasOne("Entities.Models.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId");

                    b.HasOne("Entities.Models.User", "ParentUser")
                        .WithMany()
                        .HasForeignKey("ParentUserId");

                    b.HasOne("Entities.Models.UserStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.UserRole", b =>
                {
                    b.HasOne("Entities.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.WeightCategory", b =>
                {
                    b.HasOne("Entities.Models.AgeGroup", "AgeGroup")
                        .WithMany()
                        .HasForeignKey("AgeGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
