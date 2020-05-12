using Microsoft.EntityFrameworkCore.Migrations;

namespace BabyTracker.Migrations
{
    public partial class CorrectedForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BabyInfo_Users_UsersUserID",
                table: "BabyInfo");

            migrationBuilder.DropIndex(
                name: "IX_BabyInfo_UsersUserID",
                table: "BabyInfo");

            migrationBuilder.DropColumn(
                name: "UsersUserID",
                table: "BabyInfo");

            migrationBuilder.CreateIndex(
                name: "IX_BabyInfo_UserID",
                table: "BabyInfo",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_BabyInfo_Users_UserID",
                table: "BabyInfo",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BabyInfo_Users_UserID",
                table: "BabyInfo");

            migrationBuilder.DropIndex(
                name: "IX_BabyInfo_UserID",
                table: "BabyInfo");

            migrationBuilder.AddColumn<int>(
                name: "UsersUserID",
                table: "BabyInfo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BabyInfo_UsersUserID",
                table: "BabyInfo",
                column: "UsersUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_BabyInfo_Users_UsersUserID",
                table: "BabyInfo",
                column: "UsersUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
