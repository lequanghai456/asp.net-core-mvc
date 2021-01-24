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

namespace DoanRapphim.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoaiPhimController : BaseController
    {
        private readonly DPContext _context;

        public LoaiPhimController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/LoaiPhim
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoaiPhim.ToListAsync());
        }

        // GET: Admin/LoaiPhim/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiPhimModel = await _context.LoaiPhim
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loaiPhimModel == null)
            {
                return NotFound();
            }

            return View(loaiPhimModel);
        }

        // GET: Admin/LoaiPhim/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiPhim/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenLoai")] LoaiPhimModel loaiPhimModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaiPhimModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaiPhimModel);
        }

        // GET: Admin/LoaiPhim/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiPhimModel = await _context.LoaiPhim.FindAsync(id);
            if (loaiPhimModel == null)
            {
                return NotFound();
            }
            return View(loaiPhimModel);
        }

        // POST: Admin/LoaiPhim/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenLoai")] LoaiPhimModel loaiPhimModel)
        {
            if (id != loaiPhimModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiPhimModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiPhimModelExists(loaiPhimModel.Id))
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
            return View(loaiPhimModel);
        }

        // GET: Admin/LoaiPhim/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiPhimModel = await _context.LoaiPhim
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loaiPhimModel == null)
            {
                return NotFound();
            }

            return View(loaiPhimModel);
        }

        // POST: Admin/LoaiPhim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loaiPhimModel = await _context.LoaiPhim.FindAsync(id);
            _context.LoaiPhim.Remove(loaiPhimModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiPhimModelExists(int id)
        {
            return _context.LoaiPhim.Any(e => e.Id == id);
        }
    }
}
