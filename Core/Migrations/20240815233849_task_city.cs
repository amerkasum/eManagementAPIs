using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class task_city : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Tasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CityId",
                table: "Tasks",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Cities_CityId",
                table: "Tasks",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Cities_CityId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_CityId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Tasks");
        }
    }
}
