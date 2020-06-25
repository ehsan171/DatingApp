using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.API.Migrations
{
    public partial class screenplayOrgStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScreenplayOrgStructures",
                columns: table => new
                {
                    ScreenplayId = table.Column<int>(nullable: false),
                    OrgStructureId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreenplayOrgStructures", x => new { x.ScreenplayId, x.OrgStructureId });
                    table.ForeignKey(
                        name: "FK_ScreenplayOrgStructures_OrgStructures_OrgStructureId",
                        column: x => x.OrgStructureId,
                        principalTable: "OrgStructures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScreenplayOrgStructures_Screenplays_ScreenplayId",
                        column: x => x.ScreenplayId,
                        principalTable: "Screenplays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScreenplayOrgStructures_OrgStructureId",
                table: "ScreenplayOrgStructures",
                column: "OrgStructureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScreenplayOrgStructures");
        }
    }
}
