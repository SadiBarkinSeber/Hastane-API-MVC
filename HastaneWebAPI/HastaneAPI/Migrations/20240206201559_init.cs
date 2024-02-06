using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hastaneler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HastaneAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hastaneler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hastalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Klinik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MuayeneTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HastaneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hastalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hastalar_Hastaneler_HastaneId",
                        column: x => x.HastaneId,
                        principalTable: "Hastaneler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hastaneler",
                columns: new[] { "Id", "Adres", "HastaneAdi" },
                values: new object[] { 1, "Bagcilar", "Medipol" });

            migrationBuilder.InsertData(
                table: "Hastaneler",
                columns: new[] { "Id", "Adres", "HastaneAdi" },
                values: new object[] { 2, "Kadikoy", "Acibadem" });

            migrationBuilder.InsertData(
                table: "Hastalar",
                columns: new[] { "Id", "Adi", "HastaneId", "Klinik", "MuayeneTarihi", "Soyadi" },
                values: new object[] { 1, "Ahmet", 1, "Dis", new DateTime(2024, 2, 6, 23, 15, 59, 167, DateTimeKind.Local).AddTicks(6343), "Yilmaz" });

            migrationBuilder.InsertData(
                table: "Hastalar",
                columns: new[] { "Id", "Adi", "HastaneId", "Klinik", "MuayeneTarihi", "Soyadi" },
                values: new object[] { 2, "Mehmet", 2, "KBB", new DateTime(2024, 2, 6, 23, 15, 59, 167, DateTimeKind.Local).AddTicks(6345), "Yilacak" });

            migrationBuilder.InsertData(
                table: "Hastalar",
                columns: new[] { "Id", "Adi", "HastaneId", "Klinik", "MuayeneTarihi", "Soyadi" },
                values: new object[] { 3, "Ali", 1, "Goz", new DateTime(2024, 2, 6, 23, 15, 59, 167, DateTimeKind.Local).AddTicks(6347), "Yildi" });

            migrationBuilder.CreateIndex(
                name: "IX_Hastalar_HastaneId",
                table: "Hastalar",
                column: "HastaneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hastalar");

            migrationBuilder.DropTable(
                name: "Hastaneler");
        }
    }
}
