using Microsoft.EntityFrameworkCore.Migrations;

namespace SkansenCodeFirst.Migrations
{
    public partial class skansen2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "WymagaRenowacji",
                table: "Zabytki",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WymagaRenowacji",
                table: "Zabytki");
        }
    }
}
