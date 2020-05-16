using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BabyTracker2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "BabyInfo",
                columns: table => new
                {
                    BabyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BabyName = table.Column<string>(nullable: true),
                    BabyGender = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BabyInfo", x => x.BabyID);
                    table.ForeignKey(
                        name: "FK_BabyInfo_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BabyMileStone",
                columns: table => new
                {
                    MileStoneID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<int>(nullable: false),
                    BabyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BabyMileStone", x => x.MileStoneID);
                    table.ForeignKey(
                        name: "FK_BabyMileStone_BabyInfo_BabyID",
                        column: x => x.BabyID,
                        principalTable: "BabyInfo",
                        principalColumn: "BabyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiaperChange",
                columns: table => new
                {
                    NumberofDiaperChanges = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BabyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaperChange", x => x.NumberofDiaperChanges);
                    table.ForeignKey(
                        name: "FK_DiaperChange_BabyInfo_BabyID",
                        column: x => x.BabyID,
                        principalTable: "BabyInfo",
                        principalColumn: "BabyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feeding",
                columns: table => new
                {
                    FeedingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfFeedings = table.Column<int>(nullable: false),
                    FeedingTime = table.Column<DateTime>(nullable: false),
                    BabyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feeding", x => x.FeedingID);
                    table.ForeignKey(
                        name: "FK_Feeding_BabyInfo_BabyID",
                        column: x => x.BabyID,
                        principalTable: "BabyInfo",
                        principalColumn: "BabyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BabyInfo_UserID",
                table: "BabyInfo",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_BabyMileStone_BabyID",
                table: "BabyMileStone",
                column: "BabyID");

            migrationBuilder.CreateIndex(
                name: "IX_DiaperChange_BabyID",
                table: "DiaperChange",
                column: "BabyID");

            migrationBuilder.CreateIndex(
                name: "IX_Feeding_BabyID",
                table: "Feeding",
                column: "BabyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BabyMileStone");

            migrationBuilder.DropTable(
                name: "DiaperChange");

            migrationBuilder.DropTable(
                name: "Feeding");

            migrationBuilder.DropTable(
                name: "BabyInfo");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
