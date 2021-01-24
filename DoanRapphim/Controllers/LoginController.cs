using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoanRapphim.Areas.Admin.Data;
using DoanRapphim.Areas.Admin.Models;
using DoanRapphim.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DoanRapphim.Controllers
{
    public class LoginController : Controller
    {
        private readonly DPContext _context;

        public LoginController(DPContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [TempData]
        public int id { get; set; }
        [TempData]
        public string user { get; set; }
        [TempData]
        public string admin { get; set; }
        [TempData]
        public string Message { get; set; }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("TaiKhoan,MatKhau")] NguoiDungModel nguoidung)
        {
            var r = _context.NguoiDung.Where(x => (x.TaiKhoan == nguoidung.TaiKhoan && x.MatKhau == StringProcessing.CreateMD5Hash(nguoidung.MatKhau) && x.TinhTrang == true)).ToList();

            if (r.Count == 0)
            {
                Message = "Tài Khoản Hoặc mật khẩu không chính xác";
                return RedirectToAction("Index");
            }
            nguoidung.NguoiDung = r[0].NguoiDung;
            nguoidung.Id = r[0].Id;
            nguoidung.PhanQuyen = r[0].PhanQuyen;
            var thongtin = JsonConvert.SerializeObject(nguoidung);
            HttpContext.Session.SetString("nguoidung", thongtin);

            if (r[0].PhanQuyen == 1)
            {
                admin = r[0].NguoiDung;
                var url = Url.RouteUrl("Admin", new { controller = "Home", action = "Index", area = "Admin" });
                return Redirect(url);
                id = r[0].Id;
            }
            user = r[0].NguoiDung;
            id = r[0].Id;
            return RedirectToAction("Index", "Home");
        }
    }
}
