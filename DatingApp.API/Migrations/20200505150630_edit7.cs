using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.API.Migrations
{
    public partial class edit7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "type",
                table: "BasicDatas",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "BasicDatas",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "BasicDatas",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "Basic",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basic", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Basic");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "BasicDatas",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "BasicDatas",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BasicDatas",
                newName: "id");
        }
    }
}
