using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class updateUsertable20230328 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Country",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "Country", "Password" },
                values: new object[] { new DateTime(2023, 3, 28, 22, 28, 19, 49, DateTimeKind.Local).AddTicks(4136), 1, "AQAAAAEAACcQAAAAEL6lvHumQ1tYdPP+4LpchSKilXXJWplYhWfw4jFSf+t9+BZGpeHk4RBWQoykMphZZw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "User");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "Password" },
                values: new object[] { new DateTime(2023, 3, 17, 21, 43, 26, 477, DateTimeKind.Local).AddTicks(9405), "AQAAAAEAACcQAAAAEF7hyQzDHxWHMQOo2O7vHS9TzLvkLU+6HgU4XzbnzBdDBr3QcFWgx8oPHr2mqyIIew==" });
        }
    }
}
