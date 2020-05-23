using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class createOrganizationSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "Image", "Password", "StatusId" },
                values: new object[] { new DateTime(2020, 5, 23, 13, 48, 37, 692, DateTimeKind.Local).AddTicks(1063), "admin_image.png", "AQAAAAEAACcQAAAAEF86PBDmAJBHAtIHm7S+Ku/NcQ6nAAb3N3d3FGuA6kDhzVBv4KnNg+FihTUGJQYTxg==", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "Image", "Password", "StatusId" },
                values: new object[] { new DateTime(2020, 5, 23, 13, 43, 26, 830, DateTimeKind.Local).AddTicks(6186), "Admin_Image", "AQAAAAEAACcQAAAAEFJFZH64liHecFIfINW7iBKk25Xz5v1F/OntfRw8ICdAg5MMv3pvdBS6BnD3VrGJLg==", 1 });
        }
    }
}
