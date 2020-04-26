using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RiverApi.Db.Migrations
{
    public partial class ChangedDefinitionsDueToImporter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LatLng",
                table: "LevelSpots");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeStamp",
                table: "Measurements",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "LevelSpots",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "LevelSpots");

            migrationBuilder.AlterColumn<string>(
                name: "TimeStamp",
                table: "Measurements",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "LatLng",
                table: "LevelSpots",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
