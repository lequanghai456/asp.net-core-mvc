using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoanRapphim.Areas.Admin.Models;
using DoanRapphim.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace DoanRapphim.Controllers
{
    public class DanhSachPhimController : Controller
    {
        private readonly DPContext _context;

        public DanhSachPhimController(DPContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phimModel = await _context.Phim.FirstOrDefaultAsync(m => m.Id == id);
            if (phimModel == null)
            {
                return NotFound();
            }

            return View(phimModel);
        }

        
        public IActionResult DatVe(int? id,int? idsc)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (idsc == null)
            {
                return NotFound();
            }

            var p1 = _context.SuatChieu.Find(idsc);
            var ListLichChieu = (from sc in _context.SuatChieu
                                 join lc in _context.LichChieu on sc.IdLichChieu equals lc.Id
                                 join p in _context.Phong on lc.IdPhong equals p.Id
                                 join r in _context.RapChieuPhim on p.IdRapChieu equals r.Id
                                 where lc.Id==p1.IdLichChieu && (from sc in lc.dsSuatChieu
                                        where lc.NgayChieu.Date.CompareTo(DateTime.Now.Date) == 1
                                            && sc.GioChieu.TimeOfDay.CompareTo(DateTime.Now.TimeOfDay) == 1
                                        select sc).Count() > 0
                                 select sc).ToList();

            if (ListLichChieu.Count() > 0)
            {
                ViewBag.Ten = _context.Phim.Find(p1.IdPhim).TenPhim;
                PhongModel phong = _context.Phong.Find(id);
                ViewData["Id"] = idsc;

                try
                {
                    JObject nguoidung = JObject.Parse(HttpContext.Session.GetString("nguoidung"));
                }
                catch
                {
                    return RedirectToAction("Index", "Login");
                }
                return View(phong);
            }
            return NotFound();
        }
        public IActionResult XacNhan(String dsghe)
        {
            return View();
        }


    }
}
