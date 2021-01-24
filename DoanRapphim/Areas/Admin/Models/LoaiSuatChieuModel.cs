using DoanRapphim.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoanRapphim.Areas.Admin.Models
{
    public class LoaiSuatChieuModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TenSuatChieu { get; set; }
        public decimal GiaSuatChieu { get; set; }
        public ICollection<SuatChieuModel> dsSuatChieu { get; set; }
    }
}
