using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class updateOrganizationTable20230328 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "Country",
                table: "Organization",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(250)",
                oldMaxLength: 250)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Organization",
                keyColumn: "Id",
                keyValue: 1,
                column: "Country",
                value: 1);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "Password" },
                values: new object[] { new DateTime(2023, 3, 28, 22, 56, 9, 536, DateTimeKind.Local).AddTicks(5095), "AQAAAAEAACcQAAAAEDDSuEK23O9PGAMN1zJIeVhCIeuKoKKxo8OXbx0Y8Q4bGsFlZGrI1WA9x+PI2v/jOw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Country",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Organization",
                type: "VARCHAR(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Organization",
                keyColumn: "Id",
                keyValue: 1,
                column: "Country",
                value: "LTU");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "Country", "Password" },
                values: new object[] { new DateTime(2023, 3, 28, 22, 28, 19, 49, DateTimeKind.Local).AddTicks(4136), 1, "AQAAAAEAACcQAAAAEL6lvHumQ1tYdPP+4LpchSKilXXJWplYhWfw4jFSf+t9+BZGpeHk4RBWQoykMphZZw==" });
        }
    }
}
