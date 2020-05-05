using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.API.Migrations
{
    public partial class edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Namw",
                table: "Statuses");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Statuses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Statuses");

            migrationBuilder.AddColumn<string>(
                name: "Namw",
                table: "Statuses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
