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
using DoanRapphim.Controllers;

namespace DoanRapphim.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SuatChieuController : BaseController
    {
        private readonly DPContext _context;

        public SuatChieuController(DPContext context)
        {
            _context = context;
        }

        //public override void OnActionExecuted(ActionExecutedContext context)
        //{
        //    //var b = Request.QueryString.Value.IndexOf("S_phim");
        //    //bool a = b < 0;
        //    //if (a)
        //    //{
        //        //ViewBag.ListPhim = _context.Phim.ToList();
        //        ViewBag.ListSuatChieu = _context.SuatChieu.Include(s => s.LichChieu).Include(s => s.Phim).Include(s => s.SuatChieu).ToList();
        //    //}
        //    base.OnActionExecuted(context);
        //}

        // GET: Admin/SuatChieu
        public async Task<IActionResult> Index(int s_phim)
        {
            ViewBag.ListPhim = _context.Phim.ToList();
            var dPContext = _context.SuatChieu.Include(s => s.LichChieu).Include(s => s.Phim).Include(s => s.SuatChieu);
            if (s_phim != 0)
            {
                ViewBag.ListSuatChieu = dPContext.Where(s => s.IdPhim == s_phim).ToList();
            }
            else
            {
                ViewBag.ListSuatChieu = dPContext.ToList();
            }
            return View();
        }

        // GET: Admin/SuatChieu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suatChieuModel = await _context.SuatChieu
                .Include(s => s.LichChieu)
                .Include(s => s.Phim)
                .Include(s => s.SuatChieu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (suatChieuModel == null)
            {
                return NotFound();
            }

            return View(suatChieuModel);
        }

        // GET: Admin/SuatChieu/Create
        public IActionResult Create()
        {
            ViewData["IdLichChieu"] = new SelectList(_context.LichChieu, "Id", "Id");
            ViewData["IdPhim"] = new SelectList(_context.Phim, "Id", "TenPhim");
            ViewData["IdLoaiSuatChieu"] = new SelectList(_context.LoaiSuatChieu, "Id", "Id");
            ViewBag.ListLichChieu = _context.LichChieu.ToList();
            ViewBag.ListPhim = _context.Phim.ToList();
            ViewBag.ListLoaiSuatChieu = _context.LoaiSuatChieu.ToList();
            return View();
        }

        // POST: Admin/SuatChieu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdLoaiSuatChieu,IdPhim,IdLichChieu,GioChieu,TinhTrang")] SuatChieuModel suatChieuModel)
        {
            if (ModelState.IsValid)
            {
                suatChieuModel.TinhTrang = true;
                _context.Add(suatChieuModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLichChieu"] = new SelectList(_context.LichChieu, "Id", "Id", suatChieuModel.IdLichChieu);
            ViewData["IdPhim"] = new SelectList(_context.Phim, "Id", "TenPhim", suatChieuModel.IdPhim);
            ViewData["IdLoaiSuatChieu"] = new SelectList(_context.LoaiSuatChieu, "Id", "Id", suatChieuModel.IdLoaiSuatChieu);
            return View(suatChieuModel);
        }

        // GET: Admin/SuatChieu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suatChieuModel = await _context.SuatChieu.FindAsync(id);
            if (suatChieuModel == null)
            {
                return NotFound();
            }
            ViewData["IdLichChieu"] = new SelectList(_context.LichChieu, "Id", "Id", suatChieuModel.IdLichChieu);
            ViewData["IdPhim"] = new SelectList(_context.Phim, "Id", "TenPhim", suatChieuModel.IdPhim);
            ViewData["IdLoaiSuatChieu"] = new SelectList(_context.LoaiSuatChieu, "Id", "Id", suatChieuModel.IdLoaiSuatChieu);
            ViewBag.ListLichChieu = _context.LichChieu.ToList();
            ViewBag.ListPhim = _context.Phim.ToList();
            ViewBag.ListLoaiSuatChieu = _context.LoaiSuatChieu.ToList();
            return View(suatChieuModel);
        }

        // POST: Admin/SuatChieu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdLoaiSuatChieu,IdPhim,IdLichChieu,GioChieu,TinhTrang")] SuatChieuModel suatChieuModel)
        {
            if (id != suatChieuModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suatChieuModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuatChieuModelExists(suatChieuModel.Id))
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
            ViewData["IdLichChieu"] = new SelectList(_context.LichChieu, "Id", "Id", suatChieuModel.IdLichChieu);
            ViewData["IdPhim"] = new SelectList(_context.Phim, "Id", "TenPhim", suatChieuModel.IdPhim);
            ViewData["IdLoaiSuatChieu"] = new SelectList(_context.LoaiSuatChieu, "Id", "Id", suatChieuModel.IdLoaiSuatChieu);
            return View(suatChieuModel);
        }

        // GET: Admin/SuatChieu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suatChieuModel = await _context.SuatChieu
                .Include(s => s.LichChieu)
                .Include(s => s.Phim)
                .Include(s => s.SuatChieu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (suatChieuModel == null)
            {
                return NotFound();
            }

            return View(suatChieuModel);
        }

        // POST: Admin/SuatChieu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var suatChieuModel = await _context.SuatChieu.FindAsync(id);
            _context.SuatChieu.Remove(suatChieuModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuatChieuModelExists(int id)
        {
            return _context.SuatChieu.Any(e => e.Id == id);
        }
    }
}
