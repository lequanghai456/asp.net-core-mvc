using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoanRapphim.Areas.Admin.Models
{
    public class BinhLuanModel
    {
        [Key]
        public int Id { get; set; }
        public int IdNguoiDung { get; set; }
        [ForeignKey("IdNguoiDung")]
        public virtual NguoiDungModel NguoiDung{get;set;}
        public int IdPhim { get; set; }
        [ForeignKey("IdPhim")]
        public virtual PhimModel Phim { get; set; }
        [Required]
        public String NoiDung { get; set; }
        public DateTime NgayDang { get; set; }
        public Boolean TinhTrang { get; set; }

    }
}
