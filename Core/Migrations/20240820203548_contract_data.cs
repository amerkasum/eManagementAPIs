using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class contract_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "TaskReviews");

            migrationBuilder.AddColumn<DateTime>(
                name: "ContractExpireDate",
                table: "UserPositions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ContractTypeCode",
                table: "UserPositions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContractExpireDate",
                table: "UserPositions");

            migrationBuilder.DropColumn(
                name: "ContractTypeCode",
                table: "UserPositions");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "TaskReviews",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
