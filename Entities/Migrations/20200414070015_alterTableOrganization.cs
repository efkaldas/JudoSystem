using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class alterTableOrganization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "User",
                type: "VARCHAR(1056)",
                maxLength: 1056,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Organization",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Organization");
        }
    }
}
