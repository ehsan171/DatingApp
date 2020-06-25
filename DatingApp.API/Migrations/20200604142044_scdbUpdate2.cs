using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.API.Migrations
{
    public partial class scdbUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Screenplays_OrgStructures_OrgStructureId",
                table: "Screenplays");

            migrationBuilder.DropIndex(
                name: "IX_Screenplays_OrgStructureId",
                table: "Screenplays");

            migrationBuilder.DropColumn(
                name: "OrgStructureId",
                table: "Screenplays");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrgStructureId",
                table: "Screenplays",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Screenplays_OrgStructureId",
                table: "Screenplays",
                column: "OrgStructureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Screenplays_OrgStructures_OrgStructureId",
                table: "Screenplays",
                column: "OrgStructureId",
                principalTable: "OrgStructures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
