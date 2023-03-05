using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class addOrgnizationSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Organization",
                columns: new[] { "Id", "Address", "City", "Country", "ExactName", "Image", "ShortName", "Type" },
                values: new object[] { 1, "Vilniaus g. 18", "Vilnius", "LTU", "Administration Organization", "no_organization_image.png", "Admin org", 1 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DanKyuId", "OrganizationId", "Password" },
                values: new object[] { new DateTime(2023, 3, 5, 17, 40, 16, 61, DateTimeKind.Local).AddTicks(4726), 1, 1, "AQAAAAEAACcQAAAAEN80opLXRrq91kGxFm9dld5KKhJ53U0EiLoqs/1fjFkYI7m5vj/LJx10Z99D3T13BA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Organization",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DanKyuId", "OrganizationId", "Password" },
                values: new object[] { new DateTime(2023, 3, 5, 11, 52, 31, 795, DateTimeKind.Local).AddTicks(6018), null, null, "AQAAAAEAACcQAAAAEAfCwlX/oSU22RL4TmnPKX8+97gW3VXOSqAYP6Gn2vAlnstkfv5Wz3PjfpYZ5GGfSQ==" });
        }
    }
}
