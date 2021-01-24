using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoanRapphim.Migrations
{
    public partial class khoitao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoaiGhe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiGhe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaGhe = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TinhTrang = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiGhe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiPhim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiPhim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiSuatChieu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSuatChieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaSuatChieu = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSuatChieu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDung",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiKhoan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayDangKy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinhTrang = table.Column<bool>(type: "bit", nullable: false),
                    PhanQuyen = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RapChieuPhim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenRapChieu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TongSoPhong = table.Column<int>(type: "int", nullable: false),
                    ThanhPho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuanHuyen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RapChieuPhim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPhim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnhPhim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiLuong = table.Column<int>(type: "int", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TinhTrang = table.Column<bool>(type: "bit", nullable: false),
                    IdLoaiPhim = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phim_LoaiPhim_IdLoaiPhim",
                        column: x => x.IdLoaiPhim,
                        principalTable: "LoaiPhim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRapChieu = table.Column<int>(type: "int", nullable: false),
                    TenPhong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoLuongHang = table.Column<int>(type: "int", nullable: false),
                    SoLuongCot = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phong_RapChieuPhim_IdRapChieu",
                        column: x => x.IdRapChieu,
                        principalTable: "RapChieuPhim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BinhLuan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdNguoiDung = table.Column<int>(type: "int", nullable: false),
                    IdPhim = table.Column<int>(type: "int", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayDang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinhTrang = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinhLuan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BinhLuan_NguoiDung_IdNguoiDung",
                        column: x => x.IdNguoiDung,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BinhLuan_Phim_IdPhim",
                        column: x => x.IdPhim,
                        principalTable: "Phim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LichChieu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPhong = table.Column<int>(type: "int", nullable: false),
                    NgayChieu = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichChieu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LichChieu_Phong_IdPhong",
                        column: x => x.IdPhong,
                        principalTable: "Phong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuatChieu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLoaiSuatChieu = table.Column<int>(type: "int", nullable: false),
                    IdPhim = table.Column<int>(type: "int", nullable: false),
                    IdLichChieu = table.Column<int>(type: "int", nullable: false),
                    GioChieu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinhTrang = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuatChieu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuatChieu_LichChieu_IdLichChieu",
                        column: x => x.IdLichChieu,
                        principalTable: "LichChieu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SuatChieu_LoaiSuatChieu_IdLoaiSuatChieu",
                        column: x => x.IdLoaiSuatChieu,
                        principalTable: "LoaiSuatChieu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SuatChieu_Phim_IdPhim",
                        column: x => x.IdPhim,
                        principalTable: "Phim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ve",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdNguoiDung = table.Column<int>(type: "int", nullable: false),
                    IdLoaiGhe = table.Column<int>(type: "int", nullable: false),
                    ThanhPho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuanHuyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdRap = table.Column<int>(type: "int", nullable: false),
                    IdSuatChieu = table.Column<int>(type: "int", nullable: false),
                    TenGhe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayDat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GiaVe = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PhimModelId = table.Column<int>(type: "int", nullable: true),
                    PhongModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ve", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ve_LoaiGhe_IdLoaiGhe",
                        column: x => x.IdLoaiGhe,
                        principalTable: "LoaiGhe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ve_NguoiDung_IdNguoiDung",
                        column: x => x.IdNguoiDung,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ve_Phim_PhimModelId",
                        column: x => x.PhimModelId,
                        principalTable: "Phim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ve_Phong_PhongModelId",
                        column: x => x.PhongModelId,
                        principalTable: "Phong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ve_SuatChieu_IdSuatChieu",
                        column: x => x.IdSuatChieu,
                        principalTable: "SuatChieu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BinhLuan_IdNguoiDung",
                table: "BinhLuan",
                column: "IdNguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_BinhLuan_IdPhim",
                table: "BinhLuan",
                column: "IdPhim");

            migrationBuilder.CreateIndex(
                name: "IX_LichChieu_IdPhong",
                table: "LichChieu",
                column: "IdPhong");

            migrationBuilder.CreateIndex(
                name: "IX_Phim_IdLoaiPhim",
                table: "Phim",
                column: "IdLoaiPhim");

            migrationBuilder.CreateIndex(
                name: "IX_Phong_IdRapChieu",
                table: "Phong",
                column: "IdRapChieu");

            migrationBuilder.CreateIndex(
                name: "IX_SuatChieu_IdLichChieu",
                table: "SuatChieu",
                column: "IdLichChieu");

            migrationBuilder.CreateIndex(
                name: "IX_SuatChieu_IdLoaiSuatChieu",
                table: "SuatChieu",
                column: "IdLoaiSuatChieu");

            migrationBuilder.CreateIndex(
                name: "IX_SuatChieu_IdPhim",
                table: "SuatChieu",
                column: "IdPhim");

            migrationBuilder.CreateIndex(
                name: "IX_Ve_IdLoaiGhe",
                table: "Ve",
                column: "IdLoaiGhe");

            migrationBuilder.CreateIndex(
                name: "IX_Ve_IdNguoiDung",
                table: "Ve",
                column: "IdNguoiDung");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BinhLuan");

            migrationBuilder.DropTable(
                name: "Ve");

            migrationBuilder.DropTable(
                name: "LoaiGhe");

            migrationBuilder.DropTable(
                name: "NguoiDung");

            migrationBuilder.DropTable(
                name: "SuatChieu");

            migrationBuilder.DropTable(
                name: "LichChieu");

            migrationBuilder.DropTable(
                name: "LoaiSuatChieu");

            migrationBuilder.DropTable(
                name: "Phim");

            migrationBuilder.DropTable(
                name: "Phong");

            migrationBuilder.DropTable(
                name: "LoaiPhim");

            migrationBuilder.DropTable(
                name: "RapChieuPhim");
        }
    }
}
