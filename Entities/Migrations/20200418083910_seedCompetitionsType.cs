using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class seedCompetitionsType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Complication",
                table: "CompetitionsType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Complication",
                table: "CompetitionsType",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
