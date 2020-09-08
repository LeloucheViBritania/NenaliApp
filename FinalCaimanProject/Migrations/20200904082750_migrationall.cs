using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalCaimanProject.Migrations
{
    public partial class migrationall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageSpecialité",
                table: "Specialites");

            migrationBuilder.AddColumn<string>(
                name: "ImageSpecialite",
                table: "Specialites",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageSpecialite",
                table: "Specialites");

            migrationBuilder.AddColumn<string>(
                name: "ImageSpecialité",
                table: "Specialites",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
