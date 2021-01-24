﻿// <auto-generated />
using System;
using DoanRapphim.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DoanRapphim.Migrations
{
    [DbContext(typeof(DPContext))]
    [Migration("20210113054741_update1")]
    partial class update1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("DoanRapphim.Areas.Admin.Models.BinhLuanModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IdNguoiDung")
                        .HasColumnType("int");

                    b.Property<int>("IdPhim")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayDang")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TinhTrang")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdNguoiDung");

                    b.HasIndex("IdPhim");

                    b.ToTable("BinhLuan");
                });

            modelBuilder.Entity("DoanRapphim.Areas.Admin.Models.LichChieuModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IdPhong")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayChieu")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdPhong");

                    b.ToTable("LichChieu");
                });

            modelBuilder.Entity("DoanRapphim.Areas.Admin.Models.LoaiGheModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("GiaGhe")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TenLoaiGhe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TinhTrang")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("LoaiGhe");
                });

            modelBuilder.Entity("DoanRapphim.Areas.Admin.Models.LoaiPhimModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("TenLoai")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LoaiPhim");
                });

            modelBuilder.Entity("DoanRapphim.Areas.Admin.Models.LoaiSuatChieuModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("GiaSuatChieu")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TenSuatChieu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LoaiSuatChieu");
                });

            modelBuilder.Entity("DoanRapphim.Areas.Admin.Models.NguoiDungModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("MatKhau")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<DateTime>("NgayDangKy")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("NguoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhanQuyen")
                        .HasColumnType("int");

                    b.Property<string>("TaiKhoan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TinhTrang")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("NguoiDung");
                });

            modelBuilder.Entity("DoanRapphim.Areas.Admin.Models.PhimModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AnhPhim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdLoaiPhim")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenPhim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ThoiLuong")
                        .HasColumnType("int");

                    b.Property<bool>("TinhTrang")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdLoaiPhim");

                    b.ToTable("Phim");
                });

            modelBuilder.Entity("DoanRapphim.Areas.Admin.Models.PhongModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IdRapChieu")
                        .HasColumnType("int");

                    b.Property<int>("SoLuongCot")
                        .HasColumnType("int");

                    b.Property<int>("SoLuongHang")
                        .HasColumnType("int");

                    b.Property<string>("TenPhong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdRapChieu");

                    b.ToTable("Phong");
                });

            modelBuilder.Entity("DoanRapphim.Areas.Admin.Models.RapChieuPhimModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("QuanHuyen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenRapChieu")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ThanhPho")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TongSoPhong")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RapChieuPhim");
                });

            modelBuilder.Entity("DoanRapphim.Areas.Admin.Models.SuatChieuModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("GioChieu")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdLichChieu")
                        .HasColumnType("int");

                    b.Property<int>("IdLoaiSuatChieu")
                        .HasColumnType("int");

                    b.Property<int>("IdPhim")
                        .HasColumnType("int");

                    b.Property<bool>("TinhTrang")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdLichChieu");

                    b.HasIndex("IdLoaiSuatChieu");

                    b.HasIndex("IdPhim");

                    b.ToTable("SuatChieu");
                });

            modelBuilder.Entity("DoanRapphim.Areas.Admin.Models.VeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("GiaVe")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("IdLoaiGhe")
                        .HasColumnType("int");

                    b.Property<int>("IdNguoiDung")
                        .HasColumnType("int");

                    b.Property<int>("IdRap")
                        .HasColumnType("int");

                    b.Property<int>("IdSuatChieu")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayDat")
                        .HasColumnType("datetime2");

                    b.Property<string>("QuanHuyen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenGhe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThanhPho")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdLoaiGhe");

                    b.HasIndex("IdNguoiDung");

                    b.HasIndex("IdSuatChieu");

                    b.ToTable("Ve");
                });

            modelBuilder.Entity("DoanRapphim.Areas.Admin.Models.BinhLuanModel", b =>
                {
                    b.HasOne("DoanRapphim.Areas.Admin.Models.NguoiDungModel", "NguoiDung")
                        .WithMany()
                        .HasForeignKey("IdNguoiDung")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoanRapphim.Areas.Admin.Models.PhimModel", "Phim")
                        .WithMany()
                        .HasForeignKey("IdPhim")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguoiDung");

                    b.Navigation("Phim");
                });

            modelBuilder.Entity("DoanRapphim.Areas.Admin.Models.LichChieuModel", b =>
                {
                    b.HasOne("DoanRapphim.Areas.Admin.Models.PhongModel", "Phong")
                        .WithMany("lstLichChieu")
                        .HasForeignKey("IdPhong")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Phong");
                });

            modelBuilder.Entity("DoanRapphim.Areas.Admin.Models.PhimModel", b =>
                {
                    b.HasOne("DoanRapphim.Areas.Admin.Models.LoaiPhimModel", "loaiPhim")
                        .WithMany("lstPhim")
                        .HasForeignKey("IdLoaiPhim")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("loaiPhim");
                });

            modelBuilder.Entity("DoanRapphim.Areas.Admin.Models.PhongModel", b =>
                {
                    b.HasOne("DoanRapphim.Areas.Admin.Models.RapChieuPhimModel", "RapChieuPhim")
                        .WithMany()
                        .HasForeignKey("IdRapChieu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RapChieuPhim");
                });

            modelBuilder.Entity("DoanRapphim.Areas.Admin.Models.SuatChieuModel", b =>
                {
                    b.HasOne("DoanRapphim.Areas.Admin.Models.LichChieuModel", "LichChieu")
                        .WithMany("dsSuatChieu")
                        .HasForeignKey("IdLichChieu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoanRapphim.Areas.Admin.Models.LoaiSuatChieuModel", "SuatChieu")
                        .WithMany("dsSuatChieu")
                        .HasForeignKey("IdLoaiSuatChieu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoanRapphim.Areas.Admin.Models.PhimModel", "Phim")
                        .WithMany("lstSuatChieu")
                        .HasForeignKey("IdPhim")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LichChieu");

                    b.Navigation("Phim");

                    b.Navigation("SuatChieu");
                });

            modelBuilder.Entity("DoanRapphim.Areas.Admin.Models.VeModel", b =>
                {
                    b.HasOne("DoanRapphim.Areas.Admin.Models.LoaiGheModel", "LoaiGhe")
                        .WithMany("lstVe")
                        .HasForeignKey("IdLoaiGhe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoanRapphim.Areas.Admin.Models.NguoiDungModel", "NguoiDung")
                        .WithMany("lstVe")
                        .HasForeignKey("IdNguoiDung")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoanRapphim.Areas.Admin.Models.SuatChieuModel", "SuatChieu")
                        .WithMany()
                        .HasForeignKey("IdSuatChieu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoaiGhe");

                    b.Navigation("NguoiDung");

                    b.Navigation("SuatChieu");
                });

            modelBuilder.Entity("DoanRapphim.Areas.Admin.Models.LichChieuModel", b =>
                {
                    b.Navigation("dsSuatChieu");
                });

            modelBuilder.Entity("DoanRapphim.Areas.Admin.Models.LoaiGheModel", b =>
                {
                    b.Navigation("lstVe");
                });

            modelBuilder.Entity("DoanRapphim.Areas.Admin.Models.LoaiPhimModel", b =>
                {
                    b.Navigation("lstPhim");
                });

            modelBuilder.Entity("DoanRapphim.Areas.Admin.Models.LoaiSuatChieuModel", b =>
                {
                    b.Navigation("dsSuatChieu");
                });

            modelBuilder.Entity("DoanRapphim.Areas.Admin.Models.NguoiDungModel", b =>
                {
                    b.Navigation("lstVe");
                });

            modelBuilder.Entity("DoanRapphim.Areas.Admin.Models.PhimModel", b =>
                {
                    b.Navigation("lstSuatChieu");
                });

            modelBuilder.Entity("DoanRapphim.Areas.Admin.Models.PhongModel", b =>
                {
                    b.Navigation("lstLichChieu");
                });
#pragma warning restore 612, 618
        }
    }
}
