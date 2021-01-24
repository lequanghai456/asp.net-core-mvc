using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoanRapphim.Areas.Admin.Models;
using DoanRapphim.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Filters;
using DoanRapphim.Controllers;

namespace DoanRapphim.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LichChieuController : BaseController
    {
        private readonly DPContext _context;

        public LichChieuController(DPContext context)
        {
            _context = context;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if(Request.QueryString.Value.IndexOf("phong")<0|| Request.QueryString.Value.IndexOf("phong=-1") > 0 )
            { 
                ViewBag.List = _context.LichChieu.Include(l => l.Phong);
            }
            base.OnActionExecuted(context);
        }


        public IActionResult Index(int id, int phong = -1)
        {
            LichChieuModel mod = null;
            if (id != null)
            {
                mod = _context.LichChieu.FirstOrDefault(s => s.Id == id);
            }
            ViewBag.List = _context.LichChieu.Include(l => l.Phong);
            if (phong > 0)
            {
            }
            ViewData["IdPhong"] = new SelectList(_context.Phong, "Id", "TenPhong");
            return View(mod);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lichChieuModel = await _context.LichChieu
                .Include(l => l.Phong)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lichChieuModel == null)
            {
                return NotFound();
            }

            return View(lichChieuModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdPhong,NgayChieu")] LichChieuModel lichChieuModel)
        {
            var exit = from lc in _context.LichChieu
                       where lc.IdPhong == lichChieuModel.IdPhong 
                       && lc.NgayChieu == lichChieuModel.NgayChieu
                       select lc;
            if (exit.Count() != 0)
            {
                ViewData["IdPhong"] = new SelectList(_context.Phong, "Id", "TenPhong", lichChieuModel.IdPhong);
                return View("Index");
            }
            if (ModelState.IsValid)
            {
                _context.Add(lichChieuModel);
                await _context.SaveChangesAsync();
            }
            ViewData["IdPhong"] = new SelectList(_context.Phong, "Id", "TenPhong", lichChieuModel.IdPhong);
            return View("Index");
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdPhong,NgayChieu")] LichChieuModel lichChieuModel)
        {
            if (id != lichChieuModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lichChieuModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LichChieuModelExists(lichChieuModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            ViewData["IdPhong"] = new SelectList(_context.Phong, "Id", "TenPhong", lichChieuModel.IdPhong);
            return View("Index");
        }
        private bool LichChieuModelExists(int id)
        {
            return _context.LichChieu.Any(e => e.Id == id);
        }
    }
}
