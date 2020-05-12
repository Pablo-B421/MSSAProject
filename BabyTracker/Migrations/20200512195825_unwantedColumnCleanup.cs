using Microsoft.EntityFrameworkCore.Migrations;

namespace BabyTracker.Migrations
{
    public partial class unwantedColumnCleanup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropColumn(
                name: "DiaperChangeID",
                table: "DiaperChange");

        
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

        }
    }
}
