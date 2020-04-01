using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RiverApi.Db.Migrations
{
    public partial class CreatedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "River",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_River", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<DateTime>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LevelSpots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<DateTime>(nullable: true),
                    ApiUrl = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    CreekKm = table.Column<double>(nullable: true),
                    LatLng = table.Column<string>(nullable: true),
                    LastMeasurement = table.Column<DateTime>(nullable: false),
                    Flow = table.Column<double>(nullable: true),
                    Level = table.Column<double>(nullable: true),
                    Temperature = table.Column<double>(nullable: true),
                    RiverId = table.Column<int>(nullable: false),
                    SectionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelSpots", x => x.Id);
                    table.UniqueConstraint("AK_LevelSpots_SectionId", x => x.SectionId);
                    table.ForeignKey(
                        name: "FK_LevelSpots_River_RiverId",
                        column: x => x.RiverId,
                        principalTable: "River",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<DateTime>(nullable: true),
                    TimeStamp = table.Column<string>(nullable: true),
                    Level = table.Column<double>(nullable: true),
                    Flow = table.Column<double>(nullable: true),
                    Temperature = table.Column<double>(nullable: true),
                    Origin = table.Column<string>(nullable: true),
                    LevelSpotId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Measurements_LevelSpots_LevelSpotId",
                        column: x => x.LevelSpotId,
                        principalTable: "LevelSpots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Grade = table.Column<string>(nullable: true),
                    SpotGrade = table.Column<string>(nullable: true),
                    PutIn = table.Column<string>(nullable: true),
                    TakeOut = table.Column<string>(nullable: true),
                    ParkPutIn = table.Column<string>(nullable: true),
                    ParkTakeOut = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Origin = table.Column<string>(nullable: true),
                    ExtLevelSpot = table.Column<string>(nullable: true),
                    ExtLevelType = table.Column<string>(nullable: true),
                    MinFlow = table.Column<double>(nullable: true),
                    MidFlow = table.Column<double>(nullable: true),
                    MaxFlow = table.Column<double>(nullable: true),
                    MinLevel = table.Column<double>(nullable: true),
                    MidLevel = table.Column<double>(nullable: true),
                    MaxLevel = table.Column<double>(nullable: true),
                    LevelSpotId = table.Column<int>(nullable: true),
                    RiverId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_LevelSpots_LevelSpotId",
                        column: x => x.LevelSpotId,
                        principalTable: "LevelSpots",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sections_River_RiverId",
                        column: x => x.RiverId,
                        principalTable: "River",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotSpots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<DateTime>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SectionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotSpots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotSpots_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotSpots_SectionId",
                table: "HotSpots",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelSpots_RiverId",
                table: "LevelSpots",
                column: "RiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_LevelSpotId",
                table: "Measurements",
                column: "LevelSpotId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_LevelSpotId",
                table: "Sections",
                column: "LevelSpotId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_RiverId",
                table: "Sections",
                column: "RiverId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotSpots");

            migrationBuilder.DropTable(
                name: "Measurements");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "LevelSpots");

            migrationBuilder.DropTable(
                name: "River");
        }
    }
}
