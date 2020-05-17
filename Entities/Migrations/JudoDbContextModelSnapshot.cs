﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Entities.Migrations
{
    [DbContext(typeof(JudoDbContext))]
    partial class JudoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTime>("CompetitionsDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CompetitionsId")
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

                    b.Property<DateTime>("WeightInFrom")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("WeightInTo")
                        .HasColumnType("datetime(6)");

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

                    b.Property<DateTime>("CompetitionsDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CompetitionsTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.Property<decimal?>("EntryFee")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Place")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("RegistrationEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("RegistrationStart")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Regulations")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("CompetitionsTypeId");

                    b.ToTable("Competitions");
                });

            modelBuilder.Entity("Entities.Models.CompetitionsJudge", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CompetitionsId")
                        .HasColumnType("int");

                    b.Property<int>("JudgeId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("CompetitionsId");

                    b.HasIndex("JudgeId");

                    b.ToTable("CompetitionsJudge");
                });

            modelBuilder.Entity("Entities.Models.CompetitionsResults", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("JudokaId")
                        .HasColumnType("int");

                    b.Property<int>("Place")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("WeightCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JudokaId");

                    b.HasIndex("WeightCategoryId");

                    b.ToTable("CompetitionsResults");
                });

            modelBuilder.Entity("Entities.Models.CompetitionsType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("VARCHAR(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("CompetitionsType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Points = 20,
                            Title = "National"
                        },
                        new
                        {
                            Id = 2,
                            Points = 30,
                            Title = "International"
                        });
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

                    b.Property<int>("Points")
                        .HasColumnType("int");

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
                            RoleNameEN = "Organization admin",
                            RoleNameLT = "Organizacijos administratorius",
                            RoleNameRU = "Администратор организации"
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(2020, 5, 17, 16, 13, 6, 640, DateTimeKind.Local).AddTicks(306),
                            DateCreated = new DateTime(2020, 5, 17, 16, 13, 6, 640, DateTimeKind.Local).AddTicks(1288),
                            DateUpdated = new DateTime(2020, 5, 17, 16, 13, 6, 640, DateTimeKind.Local).AddTicks(1759),
                            Email = "judosystem.info@gmail.com",
                            Firstname = "Evaldas",
                            GenderId = 1,
                            Image = "Admin_Image",
                            Lastname = "Kušlevič",
                            Password = "AQAAAAEAACcQAAAAEIi6mkBBDRVE/jYakeCr3AGu0/yZz3WzP4nTWZDNyvpigD8HDhm2MuoCBef8oD4eeQ==",
                            PhoneNumber = "+37060477292",
                            StatusId = 1
                        });
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

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        });
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
                        .HasForeignKey("CompetitionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.Competitions", b =>
                {
                    b.HasOne("Entities.Models.CompetitionsType", "ComppetitionsType")
                        .WithMany()
                        .HasForeignKey("CompetitionsTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.CompetitionsJudge", b =>
                {
                    b.HasOne("Entities.Models.Competitions", "Competitions")
                        .WithMany("Judges")
                        .HasForeignKey("CompetitionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.User", "Judge")
                        .WithMany("Competitions")
                        .HasForeignKey("JudgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.CompetitionsResults", b =>
                {
                    b.HasOne("Entities.Models.Judoka", "Judoka")
                        .WithMany()
                        .HasForeignKey("JudokaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.WeightCategory", "WeightCategory")
                        .WithMany("Results")
                        .HasForeignKey("WeightCategoryId")
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
                        .WithMany("WeightCategories")
                        .HasForeignKey("AgeGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
