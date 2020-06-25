using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.API.Migrations
{
    public partial class screenplayOrgStructure2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Screenplays_OrgStructures_OrgStructureId",
                table: "Screenplays");

            migrationBuilder.AlterColumn<int>(
                name: "OrgStructureId",
                table: "Screenplays",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Screenplays_OrgStructures_OrgStructureId",
                table: "Screenplays",
                column: "OrgStructureId",
                principalTable: "OrgStructures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Screenplays_OrgStructures_OrgStructureId",
                table: "Screenplays");

            migrationBuilder.AlterColumn<int>(
                name: "OrgStructureId",
                table: "Screenplays",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Screenplays_OrgStructures_OrgStructureId",
                table: "Screenplays",
                column: "OrgStructureId",
                principalTable: "OrgStructures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
