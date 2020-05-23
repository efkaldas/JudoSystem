using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class defaultValuesForImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "User",
                type: "VARCHAR(250)",
                maxLength: 250,
                nullable: true,
                defaultValue: "no_user_image.png",
                oldClrType: typeof(string),
                oldType: "VARCHAR(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Organization",
                type: "VARCHAR(250)",
                maxLength: 250,
                nullable: true,
                defaultValue: "no_organization_image.png",
                oldClrType: typeof(string),
                oldType: "VARCHAR(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "Image", "Password", "StatusId" },
                values: new object[] { new DateTime(2020, 5, 23, 13, 43, 26, 830, DateTimeKind.Local).AddTicks(6186), "Admin_Image", "AQAAAAEAACcQAAAAEFJFZH64liHecFIfINW7iBKk25Xz5v1F/OntfRw8ICdAg5MMv3pvdBS6BnD3VrGJLg==", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "User",
                type: "VARCHAR(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(250)",
                oldMaxLength: 250,
                oldNullable: true,
                oldDefaultValue: "no_user_image.png");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Organization",
                type: "VARCHAR(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(250)",
                oldMaxLength: 250,
                oldNullable: true,
                oldDefaultValue: "no_organization_image.png");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "Password", "StatusId" },
                values: new object[] { new DateTime(2020, 5, 23, 13, 42, 34, 76, DateTimeKind.Local).AddTicks(3361), "AQAAAAEAACcQAAAAEE4KcWYLR1m0Wr5orYJESDnWXqIZlSTi2r3ZZ97JBnRVRnnuuLTv77hSzrR/v1j5+Q==", 1 });
        }
    }
}
