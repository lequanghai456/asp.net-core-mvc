using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoanRapphim.Areas.Admin.Models;
using DoanRapphim.Data;
using DoanRapphim.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DoanRapphim.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NguoiDungController : BaseController
    {
        private readonly DPContext _context;

        public NguoiDungController(DPContext context)
        {
            _context = context;
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {

            if (Request.QueryString.Value.IndexOf("s_name") < 0)
            {
                ViewBag.ListNguoidung = (from p in _context.NguoiDung
                                         where p.PhanQuyen == 0
                                         select p).ToList();

            }

            base.OnActionExecuted(context);
        }
        // GET: Admin/NguoiDung
        public async Task<IActionResult> Index(String? s_name,String? s_stt)
        {
            NguoiDungModel nguoiDung = null;
            if (s_name != null)
            {
                if (s_stt == null)
                {
                    ViewBag.ListNguoidung = (from p in _context.NguoiDung
                                         where p.PhanQuyen == 0 && p.NguoiDung.IndexOf(s_name) >= 0
                                         select p).ToList();
                }
                else
                {
                    ViewBag.ListNguoidung = (from p in _context.NguoiDung
                                         where p.PhanQuyen == 0 && p.NguoiDung.IndexOf(s_name) >= 0 && p.TinhTrang == Convert.ToBoolean(s_stt)
                                         select p).ToList();
                }

            }
            else
            {
                if (s_stt == null)
                {
                    ViewBag.ListNguoidung = (from p in _context.NguoiDung
                                            where p.PhanQuyen == 0
                                         select p).ToList();
                }
                else
                {

                    ViewBag.ListNguoidung = (from p in _context.NguoiDung
                                         where p.PhanQuyen == 0 && p.TinhTrang == (s_stt.Equals("true") ? true : false)
                                         select p).ToList();
                }
            }
            return View(nguoiDung);
        }

        // GET: Admin/NguoiDung/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoiDungModel = await _context.NguoiDung
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nguoiDungModel == null)
            {
                return NotFound();
            }

            return View(nguoiDungModel);
        }

        // GET: Admin/NguoiDung/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/NguoiDung/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NguoiDung,TaiKhoan,MatKhau,NgaySinh,NgayDangKy,TinhTrang")] NguoiDungModel nguoiDungModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nguoiDungModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nguoiDungModel);
        }

        // GET: Admin/NguoiDung/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoiDungModel = await _context.NguoiDung.FindAsync(id);
            if (nguoiDungModel == null)
            {
                return NotFound();
            }
            return View(nguoiDungModel);
        }

        // POST: Admin/NguoiDung/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NguoiDung,TaiKhoan,MatKhau,NgaySinh,NgayDangKy,TinhTrang")] NguoiDungModel nguoiDungModel)
        {
            if (id != nguoiDungModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nguoiDungModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NguoiDungModelExists(nguoiDungModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(nguoiDungModel);
        }

        // GET: Admin/NguoiDung/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoiDungModel = await _context.NguoiDung
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nguoiDungModel == null)
            {
                return NotFound();
            }

            return View(nguoiDungModel);
        }

        // POST: Admin/NguoiDung/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nguoiDungModel = await _context.NguoiDung.FindAsync(id);
            _context.NguoiDung.Remove(nguoiDungModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NguoiDungModelExists(int id)
        {
            return _context.NguoiDung.Any(e => e.Id == id);
        }

    }
}
