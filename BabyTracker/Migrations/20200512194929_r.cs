using Microsoft.EntityFrameworkCore.Migrations;

namespace BabyTracker.Migrations
{
    public partial class r : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_BabyMileStone_BabyID",
                table: "BabyMileStone",
                column: "BabyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BabyMileStone");
        }
    }
}
