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
    public class LoaiGheController : BaseController
    {
        private readonly DPContext _context;

        public LoaiGheController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/LoaiGhe
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoaiGhe.ToListAsync());
        }

        // GET: Admin/LoaiGhe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiGheModel = await _context.LoaiGhe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loaiGheModel == null)
            {
                return NotFound();
            }

            return View(loaiGheModel);
        }

        // GET: Admin/LoaiGhe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiGheModel = await _context.LoaiGhe.FindAsync(id);
            if (loaiGheModel == null)
            {
                return NotFound();
            }
            return View(loaiGheModel);
        }

        // POST: Admin/LoaiGhe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenLoaiGhe,GiaGhe,TinhTrang")] LoaiGheModel loaiGheModel)
        {
            if (id != loaiGheModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiGheModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiGheModelExists(loaiGheModel.Id))
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
            return View(loaiGheModel);
        }
        private bool LoaiGheModelExists(int id)
        {
            return _context.LoaiGhe.Any(e => e.Id == id);
        }
    }
}
