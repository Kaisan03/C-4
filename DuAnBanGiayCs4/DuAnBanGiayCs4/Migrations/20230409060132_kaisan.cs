using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DuAnBanGiayCs4.Migrations
{
    public partial class kaisan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url10",
                table: "Anhs");

            migrationBuilder.DropColumn(
                name: "Url4",
                table: "Anhs");

            migrationBuilder.DropColumn(
                name: "Url5",
                table: "Anhs");

            migrationBuilder.DropColumn(
                name: "Url6",
                table: "Anhs");

            migrationBuilder.DropColumn(
                name: "Url7",
                table: "Anhs");

            migrationBuilder.DropColumn(
                name: "Url8",
                table: "Anhs");

            migrationBuilder.DropColumn(
                name: "Url9",
                table: "Anhs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url10",
                table: "Anhs",
                type: "nvarchar(1000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url4",
                table: "Anhs",
                type: "nvarchar(1000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url5",
                table: "Anhs",
                type: "nvarchar(1000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url6",
                table: "Anhs",
                type: "nvarchar(1000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url7",
                table: "Anhs",
                type: "nvarchar(1000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url8",
                table: "Anhs",
                type: "nvarchar(1000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url9",
                table: "Anhs",
                type: "nvarchar(1000)",
                nullable: false,
                defaultValue: "");
        }
    }
}
