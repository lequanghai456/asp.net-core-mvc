using Microsoft.EntityFrameworkCore.Migrations;

namespace DoanRapphim.Migrations
{
    public partial class create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ve_Phim_PhimModelId",
                table: "Ve");

            migrationBuilder.DropForeignKey(
                name: "FK_Ve_Phong_PhongModelId",
                table: "Ve");

            migrationBuilder.DropForeignKey(
                name: "FK_Ve_SuatChieu_IdSuatChieu",
                table: "Ve");

            migrationBuilder.DropIndex(
                name: "IX_Ve_IdSuatChieu",
                table: "Ve");

            migrationBuilder.DropIndex(
                name: "IX_Ve_PhimModelId",
                table: "Ve");

            migrationBuilder.DropIndex(
                name: "IX_Ve_PhongModelId",
                table: "Ve");

            migrationBuilder.DropColumn(
                name: "PhimModelId",
                table: "Ve");

            migrationBuilder.DropColumn(
                name: "PhongModelId",
                table: "Ve");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "PhimModelId",
                table: "Ve",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhongModelId",
                table: "Ve",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ve_IdSuatChieu",
                table: "Ve",
                column: "IdSuatChieu");

            migrationBuilder.CreateIndex(
                name: "IX_Ve_PhimModelId",
                table: "Ve",
                column: "PhimModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Ve_PhongModelId",
                table: "Ve",
                column: "PhongModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ve_Phim_PhimModelId",
                table: "Ve",
                column: "PhimModelId",
                principalTable: "Phim",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ve_Phong_PhongModelId",
                table: "Ve",
                column: "PhongModelId",
                principalTable: "Phong",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ve_SuatChieu_IdSuatChieu",
                table: "Ve",
                column: "IdSuatChieu",
                principalTable: "SuatChieu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
