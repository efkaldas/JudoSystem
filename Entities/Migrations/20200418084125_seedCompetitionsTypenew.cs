using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class seedCompetitionsTypenew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CompetitionsType",
                columns: new[] { "Id", "Points", "Title" },
                values: new object[] { 1, 20, "National" });

            migrationBuilder.InsertData(
                table: "CompetitionsType",
                columns: new[] { "Id", "Points", "Title" },
                values: new object[] { 2, 30, "International" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CompetitionsType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CompetitionsType",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
