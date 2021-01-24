using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoanRapphim.Areas.Admin.Models
{
    public class LoaiGheModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TenLoaiGhe { get; set; }
        [Required]
        public Decimal GiaGhe { get; set; }
        public bool TinhTrang { get; set; }
        public ICollection<VeModel> lstVe { get; set; }
    }
}
