using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class AddUserSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "Lastname", "Password", "StatusId" },
                values: new object[] { new DateTime(2020, 5, 7, 12, 8, 12, 153, DateTimeKind.Local).AddTicks(1653), "Kuslevic", "AQAAAAEAACcQAAAAEOb8eaaH5Xa4Dng9RWEtql+DN7SCJc1OwAnMUEOD5mcLA+TfNzt85/STAJM2fvzoyQ==", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "Lastname", "Password", "StatusId" },
                values: new object[] { new DateTime(2020, 5, 7, 12, 6, 10, 548, DateTimeKind.Local).AddTicks(631), "Kušlevič", "AQAAAAEAACcQAAAAELeYklfLMHb42XD6cMlwko4V778ORHceXP4XUW521csPrwC+KIYYeO0jctoBqu5IaQ==", 1 });
        }
    }
}
