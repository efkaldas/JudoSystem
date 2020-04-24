using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class createRankungTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CompetitionsDate",
                table: "Competitions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CompetitionsTypeId",
                table: "Competitions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Competitions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "EntryFee",
                table: "Competitions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Place",
                table: "Competitions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CompetitionsDate",
                table: "AgeGroup",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "WeightInFrom",
                table: "AgeGroup",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "WeightInTo",
                table: "AgeGroup",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
                name: "CompetitionsType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: true),
                    Points = table.Column<int>(nullable: false),
                    Complication = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionsType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JudokaRank",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    JudokaId = table.Column<int>(nullable: false),
                    Points = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JudokaRank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JudokaRank_Judoka_JudokaId",
                        column: x => x.JudokaId,
                        principalTable: "Judoka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_JudokaRank_JudokaId",
                table: "JudokaRank",
                column: "JudokaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitions_CompetitionsType_CompetitionsTypeId",
                table: "Competitions",
                column: "CompetitionsTypeId",
                principalTable: "CompetitionsType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_CompetitionsType_CompetitionsTypeId",
                table: "Competitions");

            migrationBuilder.DropTable(
                name: "CompetitionsJudge");

            migrationBuilder.DropTable(
                name: "CompetitionsResults");

            migrationBuilder.DropTable(
                name: "CompetitionsType");

            migrationBuilder.DropTable(
                name: "JudokaRank");

            migrationBuilder.DropIndex(
                name: "IX_Competitions_CompetitionsTypeId",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "CompetitionsDate",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "CompetitionsTypeId",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "EntryFee",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "Place",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "CompetitionsDate",
                table: "AgeGroup");

            migrationBuilder.DropColumn(
                name: "WeightInFrom",
                table: "AgeGroup");

            migrationBuilder.DropColumn(
                name: "WeightInTo",
                table: "AgeGroup");
        }
    }
}
