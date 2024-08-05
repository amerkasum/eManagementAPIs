using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserResidence_UserLogger_UserId",
                table: "UserResidence");

            migrationBuilder.AddForeignKey(
                name: "FK_UserResidence_Users_UserId",
                table: "UserResidence",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserResidence_Users_UserId",
                table: "UserResidence");

            migrationBuilder.AddForeignKey(
                name: "FK_UserResidence_UserLogger_UserId",
                table: "UserResidence",
                column: "UserId",
                principalTable: "UserLogger",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
