
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoanRapphim.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoanRapphim.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuatChieuAPIController : ControllerBase
    {
        private readonly DPContext _context;

        public SuatChieuAPIController(DPContext context)
        {
            _context = context;
        }
        // GET: api/<SuatChieuAPIController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var sc = _context.SuatChieu.ToList();
            var lsc = _context.LoaiSuatChieu.ToList();
            var lc = _context.LichChieu.ToList();
            var p = _context.Phim.ToList();
            var result = from suatchieu in sc
                         join loaisuatchieu in lsc on suatchieu.IdLoaiSuatChieu equals loaisuatchieu.Id
                         join phim in p on suatchieu.IdPhim equals phim.Id
                         join lichchieu in lc on suatchieu.IdLichChieu equals lichchieu.Id
                         select new
                         {
                             Id = suatchieu.Id,
                             TenLoai = loaisuatchieu.TenSuatChieu,
                             Phim = phim.TenPhim,
                             NgayChieu = lichchieu.NgayChieu,
                             GioChieu = suatchieu.GioChieu
                         };
            return new string[] { JsonConvert.SerializeObject(result) };
        }

        // GET api/<SuatChieuAPIController>/5
        [HttpGet("RapChieu/{id}")]
        public string Dsduocchon(int id,string TenGhe)
        {
            var SuatChieu = from sc in _context.SuatChieu
                            join lsc in _context.LoaiSuatChieu on sc.IdLoaiSuatChieu equals lsc.Id
                            join lc in _context.LichChieu on sc.IdLichChieu equals lc.Id
                            where sc.Id == id
                            select new
                            {
                                Tensc = sc.SuatChieu.TenSuatChieu,
                                Giasc = sc.SuatChieu.GiaSuatChieu,
                                NgayChieu = lc.NgayChieu.ToString("dd/MM/yyyy"),
                                GioChieu = sc.GioChieu.ToString("hh:mm"),
                            };
            return JsonConvert.SerializeObject(SuatChieu);
        }
        [HttpGet("Dsduocchon/{id}")]
        public string TimSuatChieu(int id)
        {
            var Dsduocchon = from v in _context.Ve
                             join sc in _context.SuatChieu on v.IdSuatChieu equals sc.Id
                             join p in _context.Phim on sc.IdPhim equals p.Id
                             where sc.Id == id
                             select new
                             {
                                 tenghe = v.TenGhe,
                             };
            return JsonConvert.SerializeObject(Dsduocchon);

        }
        [HttpGet("{idRap}/{idPhim}")]
        public String GetListLichChieu(int idRap, int idPhim)
        {
            var ListLichChieu = from sc in _context.SuatChieu
                                join lc in _context.LichChieu on sc.IdLichChieu equals lc.Id
                                join p in _context.Phong on lc.IdPhong equals p.Id
                                join r in _context.RapChieuPhim on p.IdRapChieu equals r.Id
                                where r.Id == idRap && (from sc in lc.dsSuatChieu
                                                        where sc.IdPhim == idPhim
                                                        && lc.NgayChieu.Date.CompareTo(DateTime.Now.Date) == 1
                                                        && sc.GioChieu.TimeOfDay.CompareTo(DateTime.Now.TimeOfDay) == 1
                                                        select sc).Count() > 0
                                select new {
                                    id = sc.Id,
                                    NgayChieu = lc.NgayChieu.ToString("dd/MM/yyyy"),
                                    GioChieu = sc.GioChieu.ToString("hh:mm"),
                                    GioKetThuc = sc.GioChieu.AddMinutes(_context.Phim.Find(idPhim).ThoiLuong).ToString("hh:mm"),
                                    idPhong =lc.IdPhong,
                                    tenphong = p.TenPhong
                                };

            var result = ListLichChieu;
            return JsonConvert.SerializeObject(result);
        }

        // POST api/<SuatChieuAPIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SuatChieuAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SuatChieuAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
