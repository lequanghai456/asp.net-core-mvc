using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoanRapphim.Areas.Admin.Models
{
    public class NguoiDungModel
    {
        [Key]
        public int Id { get; set; }
        public string NguoiDung { get; set; }
        [Required]
        public string TaiKhoan { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(60, MinimumLength = 3)]
        public string MatKhau { get; set; }
        public DateTime NgaySinh { get; set; }
        public DateTime NgayDangKy { get; set; }
        public bool TinhTrang{ get; set; }
        public int PhanQuyen { get; set; }
        public ICollection<VeModel> lstVe { get; set; }
    }
}
