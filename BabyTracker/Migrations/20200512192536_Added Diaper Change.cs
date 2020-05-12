using Microsoft.EntityFrameworkCore.Migrations;

namespace BabyTracker.Migrations
{
    public partial class AddedDiaperChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_DiaperChange_BabyID",
                table: "DiaperChange",
                column: "BabyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiaperChange");
        }
    }
}
