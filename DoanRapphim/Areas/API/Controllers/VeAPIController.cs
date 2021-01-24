using DoanRapphim.Areas.Admin.Models;
using DoanRapphim.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace DoanRapphim.Areas.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VeAPIController : ControllerBase
    {
        private readonly DPContext _context;

        public VeAPIController(DPContext context)
        {
            _context = context;
        }

        public class Ve
        {
            public int id { get; set; }
            public string dsghe { get; set; }
        }

        public decimal TinhTien(int idsc,int idlg)
        {
            decimal Giaghe = _context.LoaiGhe.Find(idlg).GiaGhe;
            var Giasc = from sc in _context.SuatChieu
                        join lsc in _context.LoaiSuatChieu on sc.IdLoaiSuatChieu equals lsc.Id
                        where sc.Id == idsc
                        select new { Gia = lsc.GiaSuatChieu };
            decimal Gialsc = Giasc.Select(s=>s.Gia).FirstOrDefault();
            return Giaghe + Gialsc;
        }
        public int LoaiGhe(String Ten)
        {
            var Lg = _context.LoaiGhe.ToList().Take(3);
            switch (Ten[0])
            {
                case 'A':
                case 'B':
                case 'C':
                    return Lg.First().Id;
                case 'D':
                case 'E':
                case 'F':
                    return Lg.Skip(1).First().Id;
            }
            return Lg.Skip(1).Skip(1).First().Id;
        }
        // POST api/<VeAPIController>
        [HttpPost]
        public async Task<string> PostVe(Ve ve)
        {
            
            var tt = from r in _context.RapChieuPhim
                     join p in _context.Phong on r.Id equals p.IdRapChieu
                     join lc in _context.LichChieu on p.Id equals lc.IdPhong
                     join sc in _context.SuatChieu on lc.Id equals sc.IdLichChieu
                     where sc.Id == ve.id
                     select new
                     {
                         Tp = r.ThanhPho,
                         qh = r.QuanHuyen,
                         idr = r.Id,
                         nd = DateTime.Now.Date,
                     };
            JObject nguoidung = JObject.Parse(HttpContext.Session.GetString("nguoidung"));
            NguoiDungModel mem = new NguoiDungModel();
            mem.Id = (int)nguoidung.SelectToken("Id");
            decimal Gia=0;
            if (tt != null)
                foreach (string ghe in ve.dsghe.Split(","))
                {
                    VeModel Ve = new VeModel();
                    Ve.IdSuatChieu = (int)ve.id;
                    Ve.TenGhe = ghe;
                    Ve.ThanhPho = tt.Select(t => t.Tp).FirstOrDefault();
                    Ve.QuanHuyen = tt.Select(t => t.qh).FirstOrDefault();
                    Ve.IdRap = tt.Select(t => t.idr).FirstOrDefault();
                    Ve.NgayDat = tt.Select(t => t.nd).FirstOrDefault();
                    Ve.IdLoaiGhe = LoaiGhe(ghe);
                    Ve.GiaVe = TinhTien(Ve.IdSuatChieu,Ve.IdLoaiGhe);                    
                    Ve.IdNguoiDung = mem.Id;

                    try
                    {
                        _context.Add(Ve);
                        await _context.SaveChangesAsync();
                        Gia += Ve.GiaVe;
                    }
                    catch { return "{\"result\":\"" + false + "\"}"; }
                }
            return "{\"result\":\"" + Gia + "vnd\"}";
        }
            // PUT api/<VeAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VeAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
