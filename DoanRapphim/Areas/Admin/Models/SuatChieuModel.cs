using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoanRapphim.Areas.Admin.Models
{
    public class SuatChieuModel
    {
        [Key]
        public int Id { get; set; }
        public int IdLoaiSuatChieu { get; set; }
        [ForeignKey("IdLoaiSuatChieu")]
        public virtual LoaiSuatChieuModel SuatChieu { get; set; }
        public int IdPhim { get; set; }
        [ForeignKey("IdPhim")]
        public virtual PhimModel Phim { get; set; }
        public int IdLichChieu { get; set; }
        [ForeignKey("IdLichChieu")]
        public virtual LichChieuModel LichChieu { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm:ss tt}")]
        public DateTime GioChieu { get; set; }
        public bool TinhTrang { get; set; }
    }
}
