using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoanRapphim.Areas.Admin.Models
{
    public class VeModel
    {
        [Key]
        public int Id { get; set; } 
        public int IdNguoiDung { get; set; } 
        public int IdLoaiGhe { get; set; }  
        public string ThanhPho { get; set; } 
        public string QuanHuyen { get; set; } 
        public int IdRap { get; set; } 
        public int IdSuatChieu { get; set; }
        public string TenGhe { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime NgayDat { get; set; } 
        public decimal GiaVe { get; set; }
        [ForeignKey("IdLoaiGhe")]
        public virtual LoaiGheModel LoaiGhe { get; set; }
        
        [ForeignKey("IdNguoiDung")]
        public virtual NguoiDungModel NguoiDung { get; set; }
        [ForeignKey("IdSuatChieu")]
        public virtual SuatChieuModel SuatChieu { get; set; }
        //public decimal TinhTien()
        //{
        //    decimal KQ = this.LoaiGhe.GiaGhe + this.SuatChieu.SuatChieu.GiaSuatChieu +30000;
        //    return KQ;
        //}
    }
}
