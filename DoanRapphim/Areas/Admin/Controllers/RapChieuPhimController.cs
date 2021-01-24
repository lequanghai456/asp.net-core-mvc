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
    public class RapChieuPhimController : BaseController
    {
        private readonly DPContext _context;

        public RapChieuPhimController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/RapChieuPhim
        public async Task<IActionResult> Index(string searchString)
        {
            var rap = from m in _context.RapChieuPhim
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                rap = rap.Where(s => s.TenRapChieu.Contains(searchString));
            }
            return View(await rap.ToListAsync());
        }

        // GET: Admin/RapChieuPhim/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rapChieuPhimModel = await _context.RapChieuPhim
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rapChieuPhimModel == null)
            {
                return NotFound();
            }

            return View(rapChieuPhimModel);
        }

        // GET: Admin/RapChieuPhim/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/RapChieuPhim/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenRapChieu,TongSoPhong,ThanhPho,QuanHuyen")] RapChieuPhimModel rapChieuPhimModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rapChieuPhimModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rapChieuPhimModel);
        }

        // GET: Admin/RapChieuPhim/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rapChieuPhimModel = await _context.RapChieuPhim.FindAsync(id);
            if (rapChieuPhimModel == null)
            {
                return NotFound();
            }
            return View(rapChieuPhimModel);
        }

        // POST: Admin/RapChieuPhim/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenRapChieu,TongSoPhong,ThanhPho,QuanHuyen")] RapChieuPhimModel rapChieuPhimModel)
        {
            if (id != rapChieuPhimModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rapChieuPhimModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RapChieuPhimModelExists(rapChieuPhimModel.Id))
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
            return View(rapChieuPhimModel);
        }

        // GET: Admin/RapChieuPhim/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rapChieuPhimModel = await _context.RapChieuPhim
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rapChieuPhimModel == null)
            {
                return NotFound();
            }

            return View(rapChieuPhimModel);
        }

        // POST: Admin/RapChieuPhim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rapChieuPhimModel = await _context.RapChieuPhim.FindAsync(id);
            _context.RapChieuPhim.Remove(rapChieuPhimModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RapChieuPhimModelExists(int id)
        {
            return _context.RapChieuPhim.Any(e => e.Id == id);
        }
    }
}
