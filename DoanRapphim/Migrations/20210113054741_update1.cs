using Microsoft.EntityFrameworkCore.Migrations;

namespace DoanRapphim.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Ve_IdSuatChieu",
                table: "Ve",
                column: "IdSuatChieu");

            migrationBuilder.AddForeignKey(
                name: "FK_Ve_SuatChieu_IdSuatChieu",
                table: "Ve",
                column: "IdSuatChieu",
                principalTable: "SuatChieu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ve_SuatChieu_IdSuatChieu",
                table: "Ve");

            migrationBuilder.DropIndex(
                name: "IX_Ve_IdSuatChieu",
                table: "Ve");
        }
    }
}
