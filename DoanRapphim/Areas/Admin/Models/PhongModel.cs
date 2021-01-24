using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoanRapphim.Areas.Admin.Models
{
    public class PhongModel
    {
        [Key]
        public int Id { get; set; }
        public int IdRapChieu { get; set; }
        [ForeignKey("IdRapChieu")]
        public RapChieuPhimModel RapChieuPhim { get; set; }
        [Required]
        public string TenPhong { get; set; }
        public int SoLuongHang { get; set; }
        public int SoLuongCot { get; set; }
        public bool Daxoa { get; set; }
        public ICollection<LichChieuModel> lstLichChieu { get; set; }
    }
}