using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoanRapphim.Areas.Admin.Models
{
    public class RapChieuPhimModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Phải nhập tên rạp chiếu phim")]
        [MaxLength(50, ErrorMessage = "Tên rạp chiếu phim không quá 50 kí tự ")]
        public string TenRapChieu { get; set; }
        public int TongSoPhong { get; set; }
        [Required]
        public string ThanhPho { get; set; }
        [Required]
        public string QuanHuyen { get; set; }
    }
}
