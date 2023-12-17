using Microsoft.EntityFrameworkCore.Migrations;

namespace SpeakAndRead.Data.Migrations
{
    public partial class little_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Courses",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Courses",
                type: "float",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
