using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoanRapphim.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoanRapphim.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LichChieuAPIController : ControllerBase
    {
        private readonly DPContext _context;

        public LichChieuAPIController(DPContext context)
        {
            _context = context;
        }

        // GET: api/<LichChieuAPIController>
        [HttpGet]
        public string Get()
        {
            var lc = from m in _context.LichChieu
                      select m;
            if (lc == null)
                return "not found";

            return JsonConvert.SerializeObject(lc);
        }

        // GET api/<LichChieuAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id,string tp,string qh,int rp)
        {
            //var lc = from m in _context.LichChieu
            //          where m.Id == id
            //          select m;
            //return JsonConvert.SerializeObject(lc);
            var lc = _context.LichChieu.ToList();
            var phi = _context.Phim.ToList();
            var pho = _context.Phong.ToList();
            var sc = _context.SuatChieu.ToList();
            var lp = _context.LoaiPhim.ToList();
            var r = _context.RapChieuPhim.ToList();
            var result1 = from phim in phi
                          join suatchieu in sc on phim.Id equals suatchieu.IdPhim
                          join loaiphim in lp on phim.IdLoaiPhim equals loaiphim.Id
                          join lichchieu in lc on suatchieu.IdLichChieu equals lichchieu.Id
                          join phong in pho on lichchieu.IdPhong equals phong.Id
                          join rap in r on phong.IdRapChieu equals rap.Id
                          where phim.Id == id && rap.ThanhPho == tp && rap.QuanHuyen == qh && rap.Id == rp /*&& lichchieu.NgayChieu > today*/
                          select new
                          {
                              NgayChieu = lichchieu.NgayChieu,
                          };
            var result = result1.GroupBy(i => i.NgayChieu).Select(group => group.First());
            return JsonConvert.SerializeObject(result);
        }


        // GET api/<LichChieuAPIController>/5
        [HttpGet("LayLichChieu/{id}")]
        public string Get(int id)
        {
            var lc = from m in _context.LichChieu
                     where m.Id == id
                     select m;
            return JsonConvert.SerializeObject(lc);
        }

        [HttpGet("{idRap}/{idPhim}")]
        public String GetListLichChieu(int idRap,int idPhim)
        {
            var ListLichChieu = from lc in _context.LichChieu
                                join p in _context.Phong on lc.IdPhong equals p.Id
                                join r in _context.RapChieuPhim on p.IdRapChieu equals r.Id
                                where r.Id == idRap && (from sc in lc.dsSuatChieu
                                                        where sc.IdPhim==idPhim
                                                        select sc).Count()>0
                                select lc;

           var result = ListLichChieu.GroupBy(lc=>lc.NgayChieu).Select(s => new { NgayChieu = s.Key});
            return JsonConvert.SerializeObject(result);
        }
    }
}
