using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BabyTracker.Migrations
{
    public partial class AddedFeedingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feeding",
                columns: table => new
                {
                    NumberOfFeedings = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedingTime = table.Column<DateTime>(nullable: false),
                    BabyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feeding", x => x.NumberOfFeedings);
                    table.ForeignKey(
                        name: "FK_Feeding_BabyInfo_BabyID",
                        column: x => x.BabyID,
                        principalTable: "BabyInfo",
                        principalColumn: "BabyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feeding_BabyID",
                table: "Feeding",
                column: "BabyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feeding");
        }
    }
}
