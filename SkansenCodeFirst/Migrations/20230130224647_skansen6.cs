using Microsoft.EntityFrameworkCore.Migrations;

namespace SkansenCodeFirst.Migrations
{
    public partial class skansen6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ObrazUrl",
                table: "Zabytki",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ObrazUrl",
                table: "Zabytki");
        }
    }
}
