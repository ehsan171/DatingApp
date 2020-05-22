using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.API.Migrations
{
    public partial class edit12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EpisodeWriter_Episodes_EpisodeId",
                table: "EpisodeWriter");

            migrationBuilder.DropForeignKey(
                name: "FK_EpisodeWriter_Persons_PersonId",
                table: "EpisodeWriter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EpisodeWriter",
                table: "EpisodeWriter");

            migrationBuilder.RenameTable(
                name: "EpisodeWriter",
                newName: "EpisodeWriters");

            migrationBuilder.RenameIndex(
                name: "IX_EpisodeWriter_PersonId",
                table: "EpisodeWriters",
                newName: "IX_EpisodeWriters_PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EpisodeWriters",
                table: "EpisodeWriters",
                columns: new[] { "EpisodeId", "PersonId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EpisodeWriters_Episodes_EpisodeId",
                table: "EpisodeWriters",
                column: "EpisodeId",
                principalTable: "Episodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EpisodeWriters_Persons_PersonId",
                table: "EpisodeWriters",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EpisodeWriters_Episodes_EpisodeId",
                table: "EpisodeWriters");

            migrationBuilder.DropForeignKey(
                name: "FK_EpisodeWriters_Persons_PersonId",
                table: "EpisodeWriters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EpisodeWriters",
                table: "EpisodeWriters");

            migrationBuilder.RenameTable(
                name: "EpisodeWriters",
                newName: "EpisodeWriter");

            migrationBuilder.RenameIndex(
                name: "IX_EpisodeWriters_PersonId",
                table: "EpisodeWriter",
                newName: "IX_EpisodeWriter_PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EpisodeWriter",
                table: "EpisodeWriter",
                columns: new[] { "EpisodeId", "PersonId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EpisodeWriter_Episodes_EpisodeId",
                table: "EpisodeWriter",
                column: "EpisodeId",
                principalTable: "Episodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EpisodeWriter_Persons_PersonId",
                table: "EpisodeWriter",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
