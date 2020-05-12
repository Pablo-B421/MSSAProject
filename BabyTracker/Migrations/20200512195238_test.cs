using Microsoft.EntityFrameworkCore.Migrations;

namespace BabyTracker.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DiaperChange",
                table: "DiaperChange");

            migrationBuilder.AlterColumn<int>(
                name: "NumberofDiaperChanges",
                table: "DiaperChange",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "DiaperChangeID",
                table: "DiaperChange",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiaperChange",
                table: "DiaperChange",
                column: "DiaperChangeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DiaperChange",
                table: "DiaperChange");

            migrationBuilder.DropColumn(
                name: "DiaperChangeID",
                table: "DiaperChange");

            migrationBuilder.AlterColumn<int>(
                name: "NumberofDiaperChanges",
                table: "DiaperChange",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiaperChange",
                table: "DiaperChange",
                column: "NumberofDiaperChanges");
        }
    }
}
