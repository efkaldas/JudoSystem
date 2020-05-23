using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class changeOrganizationImageType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "Password", "StatusId" },
                values: new object[] { new DateTime(2020, 5, 23, 13, 42, 34, 76, DateTimeKind.Local).AddTicks(3361), "AQAAAAEAACcQAAAAEE4KcWYLR1m0Wr5orYJESDnWXqIZlSTi2r3ZZ97JBnRVRnnuuLTv77hSzrR/v1j5+Q==", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "Password", "StatusId" },
                values: new object[] { new DateTime(2020, 5, 23, 13, 41, 40, 38, DateTimeKind.Local).AddTicks(1701), "AQAAAAEAACcQAAAAEJFxvJE6bpqKB5SR9weiJvjTba9QCPnnyE9UWvIPAiskTWdTLat3pDYvj5oLjYy5Gg==", 1 });
        }
    }
}
