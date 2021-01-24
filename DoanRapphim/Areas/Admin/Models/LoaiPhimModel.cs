using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DoanRapphim.Areas.Admin.Models
{ 
    public class LoaiPhimModel
    {
        [Key]
        public int Id { get; set; }
        public string TenLoai { get; set; }
        public ICollection<PhimModel> lstPhim { get; set; }
    }
}