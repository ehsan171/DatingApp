using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.API.Migrations
{
    public partial class edit3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "ScreenplayProducers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ScreenplayGenres");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ScreenplayFormats");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EpisodeWriter");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ScreenplayProducers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ScreenplayGenres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ScreenplayFormats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EpisodeWriter",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
