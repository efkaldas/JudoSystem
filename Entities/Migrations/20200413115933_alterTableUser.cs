using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class alterTableUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DanKyuId",
                table: "User",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_DanKyuId",
                table: "User",
                column: "DanKyuId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_DanKyu_DanKyuId",
                table: "User",
                column: "DanKyuId",
                principalTable: "DanKyu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_DanKyu_DanKyuId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_DanKyuId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DanKyuId",
                table: "User");
        }
    }
}
