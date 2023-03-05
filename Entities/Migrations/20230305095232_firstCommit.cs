using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class firstCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CompetitionsType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionsType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DanKyu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Imagepath = table.Column<string>(type: "VARCHAR(1024)", maxLength: 1024, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanKyu", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ExactName = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShortName = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Image = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: true, defaultValue: "no_organization_image.png")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CompetitionsTypeId = table.Column<int>(type: "int", nullable: false),
                    Place = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CompetitionsDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EntryFee = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    RegistrationStart = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RegistrationEnd = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Regulations = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CardPayment = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ParentUserId = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Firstname = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Lastname = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DanKyuId = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: true, defaultValue: "no_user_image.png")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 2),
                    OrganizationId = table.Column<int>(type: "int", nullable: true),
                    Password = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ResetToken = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ResetTokenExpires = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    DateUpdated = table.Column<DateTime>(type: "datetime(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_DanKyu_DanKyuId",
                        column: x => x.DanKyuId,
                        principalTable: "DanKyu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_User_ParentUserId",
                        column: x => x.ParentUserId,
                        principalTable: "User",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AgeGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CompetitionsId = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    YearsFrom = table.Column<int>(type: "int", nullable: false),
                    YearsTo = table.Column<int>(type: "int", nullable: false),
                    DanKyuFrom = table.Column<int>(type: "int", nullable: false),
                    DanKyuTo = table.Column<int>(type: "int", nullable: false),
                    CompetitionsDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    WeightInFrom = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    WeightInTo = table.Column<DateTime>(type: "datetime(6)", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CompetitionsJudge",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    JudgeId = table.Column<int>(type: "int", nullable: false),
                    CompetitionsId = table.Column<int>(type: "int", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Judoka",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Firstname = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Lastname = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BirthYears = table.Column<int>(type: "int", nullable: false),
                    DanKyuId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_Judoka_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.Type });
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WeightCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AgeGroupId = table.Column<int>(type: "int", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CompetitionsResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WeightCategoryId = table.Column<int>(type: "int", nullable: false),
                    JudokaId = table.Column<int>(type: "int", nullable: false),
                    Place = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Competitor",
                columns: table => new
                {
                    WeightCategoryId = table.Column<int>(type: "int", nullable: false),
                    JudokaId = table.Column<int>(type: "int", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                    { 1, 1, null, "6 KYU" },
                    { 2, 2, null, "5 KYU" },
                    { 3, 3, null, "4 KYU" },
                    { 4, 4, null, "3 KYU" },
                    { 5, 5, null, "2 KYU" },
                    { 6, 5, null, "1 KYU" },
                    { 7, 7, null, "1 DAN" },
                    { 8, 8, null, "2 DAN" },
                    { 9, 9, null, "3 DAN" },
                    { 10, 10, null, "4 DAN" },
                    { 11, 11, null, "5 DAN" },
                    { 12, 12, null, "6 DAN" },
                    { 13, 13, null, "7 DAN" },
                    { 14, 14, null, "8 DAN" },
                    { 15, 15, null, "9 DAN" },
                    { 16, 16, null, "10 DAN" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "BirthDate", "DanKyuId", "Email", "Firstname", "Gender", "Image", "Lastname", "OrganizationId", "ParentUserId", "Password", "PhoneNumber", "ResetToken", "ResetTokenExpires", "Status" },
                values: new object[] { 1, new DateTime(2023, 3, 5, 11, 52, 31, 795, DateTimeKind.Local).AddTicks(6018), null, "judosystem.info@gmail.com", "Evaldas", 1, "admin_image.png", "Kušlevič", null, null, "AQAAAAEAACcQAAAAEAfCwlX/oSU22RL4TmnPKX8+97gW3VXOSqAYP6Gn2vAlnstkfv5Wz3PjfpYZ5GGfSQ==", "+37060477292", null, null, 1 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Type", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AgeGroup_CompetitionsId",
                table: "AgeGroup",
                column: "CompetitionsId");

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
                name: "IX_Judoka_UserId",
                table: "Judoka",
                column: "UserId");

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
                name: "IX_User_OrganizationId",
                table: "User",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ParentUserId",
                table: "User",
                column: "ParentUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId_Type",
                table: "UserRole",
                columns: new[] { "UserId", "Type" },
                unique: true);

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
                name: "User");

            migrationBuilder.DropTable(
                name: "AgeGroup");

            migrationBuilder.DropTable(
                name: "DanKyu");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropTable(
                name: "Competitions");

            migrationBuilder.DropTable(
                name: "CompetitionsType");
        }
    }
}
