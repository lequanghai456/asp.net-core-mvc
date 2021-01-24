using DoanRapphim.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoanRapphim.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhongAPIController : ControllerBase
    {
        private readonly DPContext _context;

        public PhongAPIController(DPContext context)
        {
            _context = context;
        }
        // GET: api/<PhongAPIController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet("DSPhong")]
        public string DSphong()
        {

            var dsphong = _context.Phong.ToList();
            var dsrapchieuphim = _context.RapChieuPhim.ToList();
            var Kq = from phong in dsphong
                     join rapchieuphim in dsrapchieuphim on phong.IdRapChieu equals rapchieuphim.Id
                     select new
                     {
                         tenrap = rapchieuphim.TenRapChieu,
                         tenphong = phong.TenPhong,
                         soluonghang = phong.SoLuongHang,
                         soluongcot = phong.SoLuongCot,
                         Id = phong.Id
                     };
            return JsonConvert.SerializeObject(Kq);
        }
        // GET api/<PhongAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var result1 = from p in _context.Phong select p;
            //var result = result1.GroupBy(i => i.GioChieu).Select(group => group.First());
            return JsonConvert.SerializeObject(result1);
        }

        //[HttpGet("Hang")]
        //public string Hangcot(int id, string tp, string qh, int rp, DateTime nc, DateTime gc,int p)
        //{
        //    var lc = _context.LichChieu.ToList();
        //    var phi = _context.Phim.ToList();
        //    var pho = _context.Phong.ToList();
        //    var sc = _context.SuatChieu.ToList();
        //    var lp = _context.LoaiPhim.ToList();
        //    var r = _context.RapChieuPhim.ToList();
        //    var v = _context.Ve.ToList();
        //    var Datve = from ve in v
        //                  where ve.IdPhim == id && ve.ThanhPho == tp && ve.QuanHuyen == qh && ve.IdRap == rp && ve.NgayChieu == nc && ve.GioChieu == gc && ve.IdPhong == p
        //                  select new
        //                  {
        //                      TenGhe = ve.TenGhe,
        //                  };
        //    var GheDaChon = Datve.GroupBy(i => i.TenGhe).Select(group => group.First());
        //    var a = (JsonConvert.SerializeObject(GheDaChon).Length);
        //    if (JsonConvert.SerializeObject(GheDaChon).Length > 2)
        //    {
        //        var result1 = from phim in phi
        //                      join suatchieu in sc on phim.Id equals suatchieu.IdPhim
        //                      join loaiphim in lp on phim.IdLoaiPhim equals loaiphim.Id
        //                      join lichchieu in lc on suatchieu.IdLichChieu equals lichchieu.Id
        //                      join phong in pho on lichchieu.IdPhong equals phong.Id
        //                      join rap in r on phong.IdRapChieu equals rap.Id
        //                      from ve in v
        //                      where phim.Id == id && rap.ThanhPho == tp && rap.QuanHuyen == qh && rap.Id == rp && lichchieu.NgayChieu == nc && suatchieu.GioChieu == gc && phong.Id == p && ve.IdPhim == id && ve.ThanhPho == tp && ve.QuanHuyen == qh && ve.IdRap == rp && ve.NgayChieu == nc && ve.GioChieu == gc && ve.IdPhong == p
        //                      select new
        //                      {
        //                          tenphong = phong.TenPhong,
        //                          soluonghang = phong.SoLuongHang,
        //                          soluongcot = phong.SoLuongCot,
        //                          Id = phong.Id,

        //                          TenGhe = ve.TenGhe,
        //                      };
        //        return JsonConvert.SerializeObject(result1);
        //    }
        //    else
        //    {
        //        var result1 = from phim in phi
        //                      join suatchieu in sc on phim.Id equals suatchieu.IdPhim
        //                      join loaiphim in lp on phim.IdLoaiPhim equals loaiphim.Id
        //                      join lichchieu in lc on suatchieu.IdLichChieu equals lichchieu.Id
        //                      join phong in pho on lichchieu.IdPhong equals phong.Id
        //                      join rap in r on phong.IdRapChieu equals rap.Id
        //                      where phim.Id == id && rap.ThanhPho == tp && rap.QuanHuyen == qh && rap.Id == rp && lichchieu.NgayChieu == nc && suatchieu.GioChieu == gc && phong.Id == p
        //                      select new
        //                      {
        //                          tenphong = phong.TenPhong,
        //                          soluonghang = phong.SoLuongHang,
        //                          soluongcot = phong.SoLuongCot,
        //                          Id = phong.Id,
        //                      };
        //        return JsonConvert.SerializeObject(result1);
        //    }
        //    //var result = result1.GroupBy(i => i.GioChieu).Select(group => group.First());

        //}

        // POST api/<PhongAPIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PhongAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PhongAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        public bool Thaydoitrangthai(int id)
        {
            var phong = _context.Phong.Find(id);
            phong.Daxoa = !phong.Daxoa;
            _context.SaveChangesAsync();
            return phong.Daxoa;
        }
        [HttpGet("Thaydoitrangthai")]
        public string ThaydoitrangthaiJson(int id)
        {
            var result = Thaydoitrangthai(id);
            return JsonConvert.SerializeObject(result);
        }
    }
}
