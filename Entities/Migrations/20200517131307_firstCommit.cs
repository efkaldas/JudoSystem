using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class firstCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompetitionsType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: true),
                    Points = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionsType", x => x.Id);
                });

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
                name: "Competitions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    CompetitionsTypeId = table.Column<int>(nullable: false),
                    Place = table.Column<string>(nullable: true),
                    CompetitionsDate = table.Column<DateTime>(nullable: false),
                    EntryFee = table.Column<decimal>(nullable: true),
                    RegistrationStart = table.Column<DateTime>(nullable: false),
                    RegistrationEnd = table.Column<DateTime>(nullable: false),
                    Regulations = table.Column<string>(nullable: true),
                    CardPayment = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competitions_CompetitionsType_CompetitionsTypeId",
                        column: x => x.CompetitionsTypeId,
                        principalTable: "CompetitionsType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ExactName = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    ShortName = table.Column<string>(type: "VARCHAR(128)", maxLength: 250, nullable: true),
                    Country = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    City = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    Address = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    Image = table.Column<string>(nullable: true),
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
                name: "AgeGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    CompetitionsId = table.Column<int>(nullable: false),
                    GenderId = table.Column<int>(nullable: false),
                    YearsFrom = table.Column<int>(nullable: false),
                    YearsTo = table.Column<int>(nullable: false),
                    DanKyuFrom = table.Column<int>(nullable: false),
                    DanKyuTo = table.Column<int>(nullable: false),
                    CompetitionsDate = table.Column<DateTime>(nullable: false),
                    WeightInFrom = table.Column<DateTime>(nullable: false),
                    WeightInTo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgeGroup_Competitions_CompetitionsId",
                        column: x => x.CompetitionsId,
                        principalTable: "Competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgeGroup_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
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
                    BirthDate = table.Column<DateTime>(nullable: false),
                    DanKyuId = table.Column<int>(nullable: true),
                    GenderId = table.Column<int>(nullable: false),
                    Image = table.Column<string>(type: "VARCHAR(1056)", maxLength: 1056, nullable: true),
                    StatusId = table.Column<int>(nullable: false, defaultValue: 2),
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
                        name: "FK_User_DanKyu_DanKyuId",
                        column: x => x.DanKyuId,
                        principalTable: "DanKyu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeightCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    AgeGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeightCategory_AgeGroup_AgeGroupId",
                        column: x => x.AgeGroupId,
                        principalTable: "AgeGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionsJudge",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    JudgeId = table.Column<int>(nullable: false),
                    CompetitionsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionsJudge", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_CompetitionsJudge_Competitions_CompetitionsId",
                        column: x => x.CompetitionsId,
                        principalTable: "Competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetitionsJudge_User_JudgeId",
                        column: x => x.JudgeId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Judoka",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Firstname = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    Lastname = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    GenderId = table.Column<int>(nullable: false),
                    BirthYears = table.Column<int>(nullable: false),
                    DanKyuId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Points = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Judoka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Judoka_DanKyu_DanKyuId",
                        column: x => x.DanKyuId,
                        principalTable: "DanKyu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Judoka_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Judoka_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "CompetitionsResults",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WeightCategoryId = table.Column<int>(nullable: false),
                    JudokaId = table.Column<int>(nullable: false),
                    Place = table.Column<int>(nullable: false),
                    Points = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionsResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetitionsResults_Judoka_JudokaId",
                        column: x => x.JudokaId,
                        principalTable: "Judoka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetitionsResults_WeightCategory_WeightCategoryId",
                        column: x => x.WeightCategoryId,
                        principalTable: "WeightCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Competitor",
                columns: table => new
                {
                    WeightCategoryId = table.Column<int>(nullable: false),
                    JudokaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitor", x => new { x.WeightCategoryId, x.JudokaId });
                    table.ForeignKey(
                        name: "FK_Competitor_Judoka_JudokaId",
                        column: x => x.JudokaId,
                        principalTable: "Judoka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Competitor_WeightCategory_WeightCategoryId",
                        column: x => x.WeightCategoryId,
                        principalTable: "WeightCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CompetitionsType",
                columns: new[] { "Id", "Points", "Title" },
                values: new object[,]
                {
                    { 1, 20, "National" },
                    { 2, 30, "International" }
                });

            migrationBuilder.InsertData(
                table: "DanKyu",
                columns: new[] { "Id", "Grade", "Imagepath", "Text" },
                values: new object[,]
                {
                    { 16, 16, null, "10 DAN" },
                    { 15, 15, null, "9 DAN" },
                    { 14, 14, null, "8 DAN" },
                    { 12, 12, null, "6 DAN" },
                    { 11, 11, null, "5 DAN" },
                    { 10, 10, null, "4 DAN" },
                    { 9, 9, null, "3 DAN" },
                    { 13, 13, null, "7 DAN" },
                    { 7, 7, null, "1 DAN" },
                    { 6, 5, null, "1 KYU" },
                    { 5, 5, null, "2 KYU" },
                    { 4, 4, null, "3 KYU" },
                    { 8, 8, null, "2 DAN" },
                    { 3, 3, null, "4 KYU" },
                    { 2, 2, null, "5 KYU" },
                    { 1, 1, null, "6 KYU" }
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "Id", "TextEN", "TextLT", "TextRU" },
                values: new object[,]
                {
                    { 2, "Female", "Moteris", "Женщина" },
                    { 1, "Male", "Vyras", "Mужчина" }
                });

            migrationBuilder.InsertData(
                table: "OrganizationType",
                columns: new[] { "Id", "TypeNameEN", "TypeNameLT", "TypeNameRU" },
                values: new object[,]
                {
                    { 1, "Club", "Klubas", "Клуб" },
                    { 2, "Sports Center", "Sporto Centras", "Спортивный Центр" },
                    { 3, "Judges Association", "Teisėjų Asociacija", "Ассоциация Судей" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "RoleNameEN", "RoleNameLT", "RoleNameRU" },
                values: new object[,]
                {
                    { 1, "Admin", "Administratorius", "Администратор" },
                    { 2, "Organization admin", "Organizacijos administratorius", "Администратор организации" },
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

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "BirthDate", "DanKyuId", "Email", "Firstname", "GenderId", "Image", "Lastname", "OrganizationId", "ParentUserId", "Password", "PhoneNumber", "StatusId" },
                values: new object[] { 1, new DateTime(2020, 5, 17, 16, 13, 6, 640, DateTimeKind.Local).AddTicks(306), null, "judosystem.info@gmail.com", "Evaldas", 1, "Admin_Image", "Kušlevič", null, null, "AQAAAAEAACcQAAAAEIi6mkBBDRVE/jYakeCr3AGu0/yZz3WzP4nTWZDNyvpigD8HDhm2MuoCBef8oD4eeQ==", "+37060477292", 1 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AgeGroup_CompetitionsId",
                table: "AgeGroup",
                column: "CompetitionsId");

            migrationBuilder.CreateIndex(
                name: "IX_AgeGroup_GenderId",
                table: "AgeGroup",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_CompetitionsTypeId",
                table: "Competitions",
                column: "CompetitionsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionsJudge_CompetitionsId",
                table: "CompetitionsJudge",
                column: "CompetitionsId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionsJudge_JudgeId",
                table: "CompetitionsJudge",
                column: "JudgeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionsResults_JudokaId",
                table: "CompetitionsResults",
                column: "JudokaId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionsResults_WeightCategoryId",
                table: "CompetitionsResults",
                column: "WeightCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitor_JudokaId",
                table: "Competitor",
                column: "JudokaId");

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
                name: "IX_User_DanKyuId",
                table: "User",
                column: "DanKyuId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_GenderId",
                table: "User",
                column: "GenderId");

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

            migrationBuilder.CreateIndex(
                name: "IX_WeightCategory_AgeGroupId",
                table: "WeightCategory",
                column: "AgeGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetitionsJudge");

            migrationBuilder.DropTable(
                name: "CompetitionsResults");

            migrationBuilder.DropTable(
                name: "Competitor");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Judoka");

            migrationBuilder.DropTable(
                name: "WeightCategory");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "AgeGroup");

            migrationBuilder.DropTable(
                name: "DanKyu");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropTable(
                name: "UserStatus");

            migrationBuilder.DropTable(
                name: "Competitions");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "OrganizationType");

            migrationBuilder.DropTable(
                name: "CompetitionsType");
        }
    }
}
