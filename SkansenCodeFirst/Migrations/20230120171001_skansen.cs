using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SkansenCodeFirst.Migrations
{
    public partial class skansen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pracownicy",
                columns: table => new
                {
                    PracownikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracownicy", x => x.PracownikId);
                });

            migrationBuilder.CreateTable(
                name: "Produkty",
                columns: table => new
                {
                    ProduktId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProduktName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProduktCena = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkty", x => x.ProduktId);
                });

            migrationBuilder.CreateTable(
                name: "Zabytki",
                columns: table => new
                {
                    ZabytekId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZabytekNazwa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zabytki", x => x.ZabytekId);
                });

            migrationBuilder.CreateTable(
                name: "Sprzedaze",
                columns: table => new
                {
                    SprzedazId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ilosc = table.Column<int>(type: "int", nullable: false),
                    DataSprzedazy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProduktId = table.Column<int>(type: "int", nullable: false),
                    PracownikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprzedaze", x => x.SprzedazId);
                    table.ForeignKey(
                        name: "FK_Sprzedaze_Pracownicy_PracownikId",
                        column: x => x.PracownikId,
                        principalTable: "Pracownicy",
                        principalColumn: "PracownikId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sprzedaze_Produkty_ProduktId",
                        column: x => x.ProduktId,
                        principalTable: "Produkty",
                        principalColumn: "ProduktId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CzynnosciKonserwacyjne",
                columns: table => new
                {
                    KonserwacjaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KonserwacjaData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PracownikId = table.Column<int>(type: "int", nullable: false),
                    ZabytekId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CzynnosciKonserwacyjne", x => x.KonserwacjaId);
                    table.ForeignKey(
                        name: "FK_CzynnosciKonserwacyjne_Pracownicy_PracownikId",
                        column: x => x.PracownikId,
                        principalTable: "Pracownicy",
                        principalColumn: "PracownikId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CzynnosciKonserwacyjne_Zabytki_ZabytekId",
                        column: x => x.ZabytekId,
                        principalTable: "Zabytki",
                        principalColumn: "ZabytekId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inwentaryzacje",
                columns: table => new
                {
                    InwentaryzacjaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PracownikId = table.Column<int>(type: "int", nullable: false),
                    ZabytekId = table.Column<int>(type: "int", nullable: false),
                    DataRaportu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Komentarz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WymagaRenowacji = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inwentaryzacje", x => x.InwentaryzacjaId);
                    table.ForeignKey(
                        name: "FK_Inwentaryzacje_Pracownicy_PracownikId",
                        column: x => x.PracownikId,
                        principalTable: "Pracownicy",
                        principalColumn: "PracownikId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inwentaryzacje_Zabytki_ZabytekId",
                        column: x => x.ZabytekId,
                        principalTable: "Zabytki",
                        principalColumn: "ZabytekId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CzynnosciKonserwacyjne_PracownikId",
                table: "CzynnosciKonserwacyjne",
                column: "PracownikId");

            migrationBuilder.CreateIndex(
                name: "IX_CzynnosciKonserwacyjne_ZabytekId",
                table: "CzynnosciKonserwacyjne",
                column: "ZabytekId");

            migrationBuilder.CreateIndex(
                name: "IX_Inwentaryzacje_PracownikId",
                table: "Inwentaryzacje",
                column: "PracownikId");

            migrationBuilder.CreateIndex(
                name: "IX_Inwentaryzacje_ZabytekId",
                table: "Inwentaryzacje",
                column: "ZabytekId");

            migrationBuilder.CreateIndex(
                name: "IX_Sprzedaze_PracownikId",
                table: "Sprzedaze",
                column: "PracownikId");

            migrationBuilder.CreateIndex(
                name: "IX_Sprzedaze_ProduktId",
                table: "Sprzedaze",
                column: "ProduktId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CzynnosciKonserwacyjne");

            migrationBuilder.DropTable(
                name: "Inwentaryzacje");

            migrationBuilder.DropTable(
                name: "Sprzedaze");

            migrationBuilder.DropTable(
                name: "Zabytki");

            migrationBuilder.DropTable(
                name: "Pracownicy");

            migrationBuilder.DropTable(
                name: "Produkty");
        }
    }
}
