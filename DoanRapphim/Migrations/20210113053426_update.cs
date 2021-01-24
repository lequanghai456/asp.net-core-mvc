using Microsoft.EntityFrameworkCore.Migrations;

namespace DoanRapphim.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ve_Phim_IdPhim",
                table: "Ve");

            migrationBuilder.DropForeignKey(
                name: "FK_Ve_Phong_IdPhong",
                table: "Ve");

            migrationBuilder.DropIndex(
                name: "IX_Ve_IdPhim",
                table: "Ve");

            migrationBuilder.DropIndex(
                name: "IX_Ve_IdPhong",
                table: "Ve");

            migrationBuilder.DropColumn(
                name: "IdPhim",
                table: "Ve");

            migrationBuilder.DropColumn(
                name: "IdPhong",
                table: "Ve");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPhim",
                table: "Ve",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPhong",
                table: "Ve",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ve_IdPhim",
                table: "Ve",
                column: "IdPhim");

            migrationBuilder.CreateIndex(
                name: "IX_Ve_IdPhong",
                table: "Ve",
                column: "IdPhong");

            migrationBuilder.AddForeignKey(
                name: "FK_Ve_Phim_IdPhim",
                table: "Ve",
                column: "IdPhim",
                principalTable: "Phim",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ve_Phong_IdPhong",
                table: "Ve",
                column: "IdPhong",
                principalTable: "Phong",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
