using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.API.Migrations
{
    public partial class AddActivities2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activity1",
                table: "Allocations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Activity2",
                table: "Allocations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Activity3",
                table: "Allocations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activity1",
                table: "Allocations");

            migrationBuilder.DropColumn(
                name: "Activity2",
                table: "Allocations");

            migrationBuilder.DropColumn(
                name: "Activity3",
                table: "Allocations");
        }
    }
}
