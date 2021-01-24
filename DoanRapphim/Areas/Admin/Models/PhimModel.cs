using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoanRapphim.Areas.Admin.Models
{
    public class PhimModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TenPhim { get; set; }
        public string AnhPhim { get; set; }
        [Required]
        public int ThoiLuong { get; set; }
        public string MoTa { get; set; }
        [Required]
        public bool TinhTrang { get; set; }
        public int IdLoaiPhim { get; set; }
        [ForeignKey("IdLoaiPhim")]
        public LoaiPhimModel loaiPhim { get; set; }
        public ICollection<SuatChieuModel> lstSuatChieu { get; set; }
    }
}
