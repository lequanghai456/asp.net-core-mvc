using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoanRapphim.Areas.Admin.Data;
using DoanRapphim.Areas.Admin.Models;
using DoanRapphim.Data;
using Microsoft.AspNetCore.Mvc;

namespace DoanRapphim.Controllers
{
    public class DangKyController : Controller
    {
        private readonly DPContext _context;

        public DangKyController(DPContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NguoiDung,TaiKhoan,MatKhau,NgaySinh")] NguoiDungModel nguoiDungModel)
        {
            if (ModelState.IsValid)
            {
                nguoiDungModel.TinhTrang = true;
                nguoiDungModel.NgayDangKy = DateTime.Now;
                nguoiDungModel.PhanQuyen = 0;
                var r = _context.NguoiDung.Where(m => (m.TaiKhoan.Equals(nguoiDungModel.TaiKhoan))).ToList();
                if (r.Count == 0)
                {
                        nguoiDungModel.MatKhau = StringProcessing.CreateMD5Hash(nguoiDungModel.MatKhau).ToString();
                        _context.Add(nguoiDungModel);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Index","Login");
                }
                else
                {
                    return View("Index",nguoiDungModel);
                }
            }
            return View("Index",nguoiDungModel);
        }
    }
}
