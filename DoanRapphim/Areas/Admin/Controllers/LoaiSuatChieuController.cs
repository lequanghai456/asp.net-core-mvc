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
    public class LoaiSuatChieuController : BaseController
    {
        private readonly DPContext _context;

        public LoaiSuatChieuController(DPContext context)
        {
            _context = context;
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        { 
            if (Request.QueryString.Value.IndexOf("Key")<0)
            {
                ViewBag.List = _context.LoaiSuatChieu.ToList() ;
            }                
            base.OnActionExecuted(context);
        }
        // GET: Admin/LoaiSuatChieu
        public async Task<IActionResult> Index(int id,String? Key)
        {
            LoaiSuatChieuModel mod = null;
            if (id!=null)
            {
                mod = _context.LoaiSuatChieu.FirstOrDefault(s => s.Id == id);
            }
            ViewBag.List = _context.LoaiSuatChieu.ToList();
            if (Key!=null)
            {
                ViewBag.List = _context.LoaiSuatChieu.Where(s => s.TenSuatChieu.Contains(Key)).ToList();
            }
            return View(mod);
        }

        // GET: Admin/LoaiSuatChieu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiSuatChieuModel = await _context.LoaiSuatChieu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loaiSuatChieuModel == null)
            {
                return NotFound();
            }

            return View(loaiSuatChieuModel);
        }


        // POST: Admin/LoaiSuatChieu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenSuatChieu,GiaSuatChieu")] LoaiSuatChieuModel loaiSuatChieuModel)
        { 
            if (ModelState.IsValid)
            {
                _context.Add(loaiSuatChieuModel);
                await _context.SaveChangesAsync();
            }
            return View("Index");
        }


        // POST: Admin/LoaiSuatChieu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenSuatChieu,GiaSuatChieu")] LoaiSuatChieuModel loaiSuatChieuModel)
        {
            if (id != loaiSuatChieuModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiSuatChieuModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiSuatChieuModelExists(loaiSuatChieuModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View("Index");
        }

        private bool LoaiSuatChieuModelExists(int id)
        {
            return _context.LoaiSuatChieu.Any(e => e.Id == id);
        }
    }
}
