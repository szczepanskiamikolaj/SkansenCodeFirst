using Microsoft.EntityFrameworkCore.Migrations;

namespace SkansenCodeFirst.Migrations
{
    public partial class skansen7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PortretUrl",
                table: "Pracownicy",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PortretUrl",
                table: "Pracownicy");
        }
    }
}
