using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoanRapphim.Areas.Admin.Models;
using DoanRapphim.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;
using DoanRapphim.Controllers;

namespace DoanRapphim.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PhongController : BaseController
    {
        private readonly DPContext _context;

        public PhongController(DPContext context)
        {
            _context = context;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {

            if (Request.QueryString.Value.IndexOf("s_name") < 0)
            {
                ViewBag.ListPhong = _context.Phong.Include(p => p.RapChieuPhim).ToList();

            }

            ViewBag.ListRapChieu = _context.RapChieuPhim.ToList();

            base.OnActionExecuted(context);
        }

        // GET: Admin/Phong
        public async Task<IActionResult> Index(int? id, String? s_name, String? s_stt)
        {
            PhongModel phong = null;
            if (id != null)
            {
                phong = await _context.Phong.FirstOrDefaultAsync(m => m.Id == id);
            }
            if (s_name != null)
            {
                if (s_stt == null)
                {
                    ViewBag.ListPhong = (from p in _context.Phong
                                         where p.TenPhong.IndexOf(s_name) >= 0
                                         select p).ToList();
                }
                else
                {
                    ViewBag.ListPhong = (from p in _context.Phong
                                         where p.TenPhong.IndexOf(s_name) >= 0 && p.Daxoa == Convert.ToBoolean(s_stt)
                                         select p).ToList();
                }

            }
            else
            {
                if (s_stt == null)
                {
                    ViewBag.ListPhong = (from p in _context.Phong
                                         select p).ToList();
                }
                else
                {

                    ViewBag.ListPhong = (from p in _context.Phong
                                         where p.Daxoa == (s_stt.Equals("true") ? true : false)
                                         select p).ToList();
                }
            }
            return View(phong);
        }

        // GET: Admin/Phong/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.ListRapChieu = _context.RapChieuPhim.ToList();
            if (id == null)
            {
                return NotFound();
            }

            var phongModel = await _context.Phong
                .Include(p => p.RapChieuPhim)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phongModel == null)
            {
                return NotFound();
            }

            return View(phongModel);
        }

        // GET: Admin/Phong/Create
        public IActionResult Create()
        {
            ViewBag.ListRapChieu = _context.RapChieuPhim.ToList();
            ViewData["IdRapChieu"] = new SelectList(_context.RapChieuPhim, "Id", "TenRap");
            return View();
        }

        // POST: Admin/Phong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdRapChieu,TenPhong,SoLuongHang,SoLuongCot")] PhongModel phongModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phongModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRapChieu"] = new SelectList(_context.RapChieuPhim, "Id", "TenRap", phongModel.IdRapChieu);
            return View(phongModel);
        }

        // GET: Admin/Phong/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.ListRapChieu = _context.RapChieuPhim.ToList();
            if (id == null)
            {
                return NotFound();
            }

            var phongModel = await _context.Phong.FindAsync(id);
            if (phongModel == null)
            {
                return NotFound();
            }
            ViewData["IdRapChieu"] = new SelectList(_context.RapChieuPhim, "Id", "TenRap", phongModel.IdRapChieu);
            return View(phongModel);
        }

        // POST: Admin/Phong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdRapChieu,TenPhong,SoLuongHang,SoLuongCot")] PhongModel phongModel)
        {
            if (id != phongModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phongModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhongModelExists(phongModel.Id))
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
            ViewData["IdRapChieu"] = new SelectList(_context.RapChieuPhim, "Id", "TenRap", phongModel.IdRapChieu);
            return View(phongModel);
        }

        // GET: Admin/Phong/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phongModel = await _context.Phong
                .Include(p => p.RapChieuPhim)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phongModel == null)
            {
                return NotFound();
            }

            return View(phongModel);
        }

        // POST: Admin/Phong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phongModel = await _context.Phong.FindAsync(id);
            _context.Phong.Remove(phongModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhongModelExists(int id)
        {
            return _context.Phong.Any(e => e.Id == id);
        }
    }
}
