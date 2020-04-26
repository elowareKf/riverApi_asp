using Microsoft.EntityFrameworkCore.Migrations;

namespace RiverApi.Db.Migrations
{
    public partial class RemovedSectionIdFromLevelSpot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_LevelSpots_LevelSpotId",
                table: "Sections");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_LevelSpots_SectionId",
                table: "LevelSpots");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "LevelSpots");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_LevelSpots_LevelSpotId",
                table: "Sections",
                column: "LevelSpotId",
                principalTable: "LevelSpots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_LevelSpots_LevelSpotId",
                table: "Sections");

            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "LevelSpots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_LevelSpots_SectionId",
                table: "LevelSpots",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_LevelSpots_LevelSpotId",
                table: "Sections",
                column: "LevelSpotId",
                principalTable: "LevelSpots",
                principalColumn: "SectionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
