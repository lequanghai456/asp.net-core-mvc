using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DoanRapphim.Areas.Admin.Models;

namespace DoanRapphim.Areas.Admin.Models
{
    public class LichChieuModel
    {
        [Key]
        public int Id { get; set; }
        public int IdPhong { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime NgayChieu { get; set; }
        [ForeignKey("IdPhong")]
        public PhongModel Phong { get; set; }
        public ICollection<SuatChieuModel> dsSuatChieu { get; set; }
    }
}