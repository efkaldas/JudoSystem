using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class firstMigratino : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DanKyu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Grade = table.Column<int>(nullable: false),
                    Text = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    Imagepath = table.Column<string>(type: "VARCHAR(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanKyu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TextEN = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    TextLT = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    TextRU = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TypeNameEN = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    TypeNameLT = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    TypeNameRU = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleNameEN = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    RoleNameLT = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    RoleNameRU = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusNameEN = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    StatusNameLT = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    StatusNameRU = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ExactName = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    ShortName = table.Column<string>(type: "VARCHAR(128)", maxLength: 250, nullable: false),
                    Country = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    City = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    Address = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    OrganizationTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organization_OrganizationType_OrganizationTypeId",
                        column: x => x.OrganizationTypeId,
                        principalTable: "OrganizationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ParentUserId = table.Column<int>(nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    Firstname = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    Lastname = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    PhoneNumber = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    StatuId = table.Column<int>(nullable: false, defaultValue: 2),
                    StatusId = table.Column<int>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: true),
                    Password = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_User_ParentUserId",
                        column: x => x.ParentUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_UserStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "UserStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Judoka",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Firstname = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    Lastname = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    GenderId = table.Column<int>(nullable: true),
                    BirthYears = table.Column<int>(nullable: false),
                    DanKyuId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Judoka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Judoka_DanKyu_DanKyuId",
                        column: x => x.DanKyuId,
                        principalTable: "DanKyu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Judoka_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Judoka_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DanKyu",
                columns: new[] { "Id", "Grade", "Imagepath", "Text" },
                values: new object[,]
                {
                    { 1, 1, null, "6 KYU" },
                    { 16, 16, null, "10 DAN" },
                    { 15, 15, null, "9 DAN" },
                    { 13, 13, null, "7 DAN" },
                    { 12, 12, null, "6 DAN" },
                    { 11, 11, null, "5 DAN" },
                    { 10, 10, null, "4 DAN" },
                    { 9, 9, null, "3 DAN" },
                    { 14, 14, null, "8 DAN" },
                    { 7, 7, null, "1 DAN" },
                    { 6, 5, null, "1 KYU" },
                    { 5, 5, null, "2 KYU" },
                    { 4, 4, null, "3 KYU" },
                    { 3, 3, null, "4 KYU" },
                    { 2, 2, null, "5 KYU" },
                    { 8, 8, null, "2 DAN" }
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "Id", "TextEN", "TextLT", "TextRU" },
                values: new object[,]
                {
                    { 1, "Male", "Vyras", "Mужчина" },
                    { 2, "Female", "Moteris", "Женщина" }
                });

            migrationBuilder.InsertData(
                table: "OrganizationType",
                columns: new[] { "Id", "TypeNameEN", "TypeNameLT", "TypeNameRU" },
                values: new object[,]
                {
                    { 3, "Judges Association", "Teisėjų Asociacija", "Ассоциация Судей" },
                    { 1, "Club", "Klubas", "Клуб" },
                    { 2, "Sports Center", "Sporto Centras", "Спортивный Центр" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "RoleNameEN", "RoleNameLT", "RoleNameRU" },
                values: new object[,]
                {
                    { 1, "Admin", "Administratorius", "Администратор" },
                    { 2, "Moderator", "Moderatorius", "Модератор" },
                    { 3, "Coach", "Treneris", "Тренер" },
                    { 4, "Judge", "Teisėjas", "Судья" }
                });

            migrationBuilder.InsertData(
                table: "UserStatus",
                columns: new[] { "Id", "StatusNameEN", "StatusNameLT", "StatusNameRU" },
                values: new object[,]
                {
                    { 2, "Not аpproved", "Nepatvirtintas", "Не одобренный" },
                    { 1, "Approved", "Patvirtintas", "Одобренный" },
                    { 3, "Blocked", "Užblokuotas", "Заблокирован" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Judoka_DanKyuId",
                table: "Judoka",
                column: "DanKyuId");

            migrationBuilder.CreateIndex(
                name: "IX_Judoka_GenderId",
                table: "Judoka",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Judoka_UserId",
                table: "Judoka",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_OrganizationTypeId",
                table: "Organization",
                column: "OrganizationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_OrganizationId",
                table: "User",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ParentUserId",
                table: "User",
                column: "ParentUserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_StatusId",
                table: "User",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Judoka");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "DanKyu");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropTable(
                name: "UserStatus");

            migrationBuilder.DropTable(
                name: "OrganizationType");
        }
    }
}
