using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class createRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgeGroupId",
                table: "WeightCategory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WeightCategory_AgeGroupId",
                table: "WeightCategory",
                column: "AgeGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeightCategory_AgeGroup_AgeGroupId",
                table: "WeightCategory",
                column: "AgeGroupId",
                principalTable: "AgeGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeightCategory_AgeGroup_AgeGroupId",
                table: "WeightCategory");

            migrationBuilder.DropIndex(
                name: "IX_WeightCategory_AgeGroupId",
                table: "WeightCategory");

            migrationBuilder.DropColumn(
                name: "AgeGroupId",
                table: "WeightCategory");
        }
    }
}
