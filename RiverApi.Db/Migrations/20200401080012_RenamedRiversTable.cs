using Microsoft.EntityFrameworkCore.Migrations;

namespace RiverApi.Db.Migrations
{
    public partial class RenamedRiversTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LevelSpots_River_RiverId",
                table: "LevelSpots");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_River_RiverId",
                table: "Sections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_River",
                table: "River");

            migrationBuilder.RenameTable(
                name: "River",
                newName: "Rivers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rivers",
                table: "Rivers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LevelSpots_Rivers_RiverId",
                table: "LevelSpots",
                column: "RiverId",
                principalTable: "Rivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Rivers_RiverId",
                table: "Sections",
                column: "RiverId",
                principalTable: "Rivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LevelSpots_Rivers_RiverId",
                table: "LevelSpots");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Rivers_RiverId",
                table: "Sections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rivers",
                table: "Rivers");

            migrationBuilder.RenameTable(
                name: "Rivers",
                newName: "River");

            migrationBuilder.AddPrimaryKey(
                name: "PK_River",
                table: "River",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LevelSpots_River_RiverId",
                table: "LevelSpots",
                column: "RiverId",
                principalTable: "River",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_River_RiverId",
                table: "Sections",
                column: "RiverId",
                principalTable: "River",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
