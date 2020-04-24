using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class createTableCompetitions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Judoka_DanKyu_DanKyuId",
                table: "Judoka");

            migrationBuilder.DropForeignKey(
                name: "FK_Judoka_Gender_GenderId",
                table: "Judoka");

            migrationBuilder.DropForeignKey(
                name: "FK_Judoka_User_UserId",
                table: "Judoka");

            migrationBuilder.DropForeignKey(
                name: "FK_User_UserStatus_StatusId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "StatuId",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "User",
                nullable: false,
                defaultValue: 2,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Judoka",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                table: "Judoka",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DanKyuId",
                table: "Judoka",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    Regulations = table.Column<string>(nullable: true),
                    CardPayment = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeightCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AgeGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    CompetitonsId = table.Column<int>(nullable: false),
                    CompetitionsId = table.Column<int>(nullable: true),
                    GenderId = table.Column<int>(nullable: false),
                    YearsFrom = table.Column<int>(nullable: false),
                    YearsTo = table.Column<int>(nullable: false),
                    DanKyuFrom = table.Column<int>(nullable: false),
                    DanKyuTo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgeGroup_Competitions_CompetitionsId",
                        column: x => x.CompetitionsId,
                        principalTable: "Competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgeGroup_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
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

            migrationBuilder.CreateIndex(
                name: "IX_AgeGroup_CompetitionsId",
                table: "AgeGroup",
                column: "CompetitionsId");

            migrationBuilder.CreateIndex(
                name: "IX_AgeGroup_GenderId",
                table: "AgeGroup",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitor_JudokaId",
                table: "Competitor",
                column: "JudokaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Judoka_DanKyu_DanKyuId",
                table: "Judoka",
                column: "DanKyuId",
                principalTable: "DanKyu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Judoka_Gender_GenderId",
                table: "Judoka",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Judoka_User_UserId",
                table: "Judoka",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserStatus_StatusId",
                table: "User",
                column: "StatusId",
                principalTable: "UserStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Judoka_DanKyu_DanKyuId",
                table: "Judoka");

            migrationBuilder.DropForeignKey(
                name: "FK_Judoka_Gender_GenderId",
                table: "Judoka");

            migrationBuilder.DropForeignKey(
                name: "FK_Judoka_User_UserId",
                table: "Judoka");

            migrationBuilder.DropForeignKey(
                name: "FK_User_UserStatus_StatusId",
                table: "User");

            migrationBuilder.DropTable(
                name: "AgeGroup");

            migrationBuilder.DropTable(
                name: "Competitor");

            migrationBuilder.DropTable(
                name: "Competitions");

            migrationBuilder.DropTable(
                name: "WeightCategory");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "User",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldDefaultValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "StatuId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Judoka",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                table: "Judoka",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DanKyuId",
                table: "Judoka",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Judoka_DanKyu_DanKyuId",
                table: "Judoka",
                column: "DanKyuId",
                principalTable: "DanKyu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Judoka_Gender_GenderId",
                table: "Judoka",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Judoka_User_UserId",
                table: "Judoka",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserStatus_StatusId",
                table: "User",
                column: "StatusId",
                principalTable: "UserStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
