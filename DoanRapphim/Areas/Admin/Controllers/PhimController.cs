using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoanRapphim.Areas.Admin.Models;
using DoanRapphim.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using DoanRapphim.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DoanRapphim.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PhimController : BaseController
    {
        private readonly DPContext _context;

        public PhimController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/Phim
        public async Task<IActionResult> Index(string Search)
        {
            PhimModel phim = null;
            if(Search != null)
            {
                ViewBag.ListDuLieu = _context.Phim.Include(p => p.loaiPhim).Where(s => s.TenPhim.Contains(Search)).ToList();
            }
            else
            {
                ViewBag.ListDuLieu = _context.Phim.Include(p => p.loaiPhim).ToList();
            }
            //var dPContext = _context.Phim.Include(p => p.loaiPhim);
            //return View(await dPContext.ToListAsync());
            return View();
        }

        // GET: Admin/Phim/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phimModel = await _context.Phim
                .Include(p => p.loaiPhim)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phimModel == null)
            {
                return NotFound();
            }

            return View(phimModel);
        }

        // GET: Admin/Phim/Create
        public IActionResult Create()
        {
            ViewData["IdLoaiPhim"] = new SelectList(_context.LoaiPhim, "Id", "TenLoai");
            return View();
        }

        // POST: Admin/Phim/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenPhim,AnhPhim,ThoiLuong,MoTa,IdLoaiPhim")] PhimModel phimModel,IFormFile ful)
        {
            if (ModelState.IsValid)
            {
                phimModel.TinhTrang = true;
                _context.Add(phimModel);
                await _context.SaveChangesAsync();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AnhPhim",
                    phimModel.Id + "." + ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1]);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await ful.CopyToAsync(stream);
                }
                phimModel.AnhPhim = phimModel.Id + "." + ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1];
                _context.Update(phimModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLoaiPhim"] = new SelectList(_context.LoaiPhim, "Id", "TenLoai", phimModel.IdLoaiPhim);
            return View(phimModel);
        }

        // GET: Admin/Phim/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phimModel = await _context.Phim.FindAsync(id);
            if (phimModel == null)
            {
                return NotFound();
            }
            ViewData["IdLoaiPhim"] = new SelectList(_context.LoaiPhim, "Id", "TenLoai", phimModel.IdLoaiPhim);
            return View(phimModel);
        }

        // POST: Admin/Phim/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenPhim,AnhPhim,ThoiLuong,MoTa,TinhTrang,IdLoaiPhim")] PhimModel phimModel,IFormFile ful)
        {
            if (id != phimModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phimModel);
                    if (ful != null)
                    {
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AnhPhim", phimModel.AnhPhim);
                        System.IO.File.Delete(path);

                        path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AnhPhim",
                        phimModel.Id + "." + ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1]);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await ful.CopyToAsync(stream);
                        }
                        phimModel.AnhPhim = phimModel.Id + "." + ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1];
                        _context.Update(phimModel);
                        await _context.SaveChangesAsync();
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhimModelExists(phimModel.Id))
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
            ViewData["IdLoaiPhim"] = new SelectList(_context.LoaiPhim, "Id", "TenLoai", phimModel.IdLoaiPhim);
            return View(phimModel);
        }

        // GET: Admin/Phim/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phimModel = await _context.Phim
                .Include(p => p.loaiPhim)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phimModel == null)
            {
                return NotFound();
            }

            return View(phimModel);
        }

        // POST: Admin/Phim/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var phimModel = await _context.Phim.FindAsync(id);
        //    _context.Phim.Remove(phimModel);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phimModel = await _context.Phim.FindAsync(id);
            phimModel.TinhTrang = false;
            _context.Update(phimModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhimModelExists(int id)
        {
            return _context.Phim.Any(e => e.Id == id);
        }
    }
}
