using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class updateOrganizationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Organization",
                type: "longblob",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(250)",
                oldMaxLength: 250,
                oldNullable: true,
                oldDefaultValue: "no_organization_image.png")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Organization",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "Password" },
                values: new object[] { new DateTime(2023, 3, 17, 21, 43, 26, 477, DateTimeKind.Local).AddTicks(9405), "AQAAAAEAACcQAAAAEF7hyQzDHxWHMQOo2O7vHS9TzLvkLU+6HgU4XzbnzBdDBr3QcFWgx8oPHr2mqyIIew==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Organization",
                type: "VARCHAR(250)",
                maxLength: 250,
                nullable: true,
                defaultValue: "no_organization_image.png",
                oldClrType: typeof(byte[]),
                oldType: "longblob",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Organization",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "no_organization_image.png");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "Password" },
                values: new object[] { new DateTime(2023, 3, 17, 20, 36, 8, 373, DateTimeKind.Local).AddTicks(3334), "AQAAAAEAACcQAAAAEC9L+JZjZVkOwR/fTQAJjzoUswG64nYtAAeLQsVnXY5i8U4WS2zp6JiNfnK7mclJNA==" });
        }
    }
}
