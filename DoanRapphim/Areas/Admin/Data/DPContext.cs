using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DoanRapphim.Areas.Admin.Models;

namespace DoanRapphim.Data
{
    public class DPContext : DbContext
    {
        public DPContext (DbContextOptions<DPContext> options)
            : base(options)
        {
        }

        public DbSet<DoanRapphim.Areas.Admin.Models.LoaiPhimModel> LoaiPhim { get; set; }
        public DbSet<DoanRapphim.Areas.Admin.Models.PhimModel> Phim { get; set; }
        public DbSet<DoanRapphim.Areas.Admin.Models.PhongModel> Phong { get; set; }
        public DbSet<DoanRapphim.Areas.Admin.Models.LoaiGheModel> LoaiGhe { get; set; }
        public DbSet<DoanRapphim.Areas.Admin.Models.LoaiSuatChieuModel> LoaiSuatChieu { get; set; }
        public DbSet<DoanRapphim.Areas.Admin.Models.SuatChieuModel> SuatChieu { get; set; }
        public DbSet<DoanRapphim.Areas.Admin.Models.BinhLuanModel> BinhLuan { get; set; }
        public DbSet<DoanRapphim.Areas.Admin.Models.LichChieuModel> LichChieu { get; set; }
        public DbSet<DoanRapphim.Areas.Admin.Models.NguoiDungModel> NguoiDung { get; set; }
        public DbSet<DoanRapphim.Areas.Admin.Models.VeModel> Ve { get; set; }
        public DbSet<DoanRapphim.Areas.Admin.Models.RapChieuPhimModel> RapChieuPhim { get; set; }
    }
}
