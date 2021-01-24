using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DoanRapphim.Areas.Admin.Models;
using DoanRapphim.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoanRapphim.Areas.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RapChieuPhimAPIController : ControllerBase
    {
        private readonly DPContext _context;

        public RapChieuPhimAPIController(DPContext context)
        {
            _context = context;
        }
        // GET: api/<RapChieuPhimAPIController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var ds = _context.RapChieuPhim.ToList();
            return new string[] { JsonConvert.SerializeObject(ds) };
        }

        // GET api/<RapChieuPhimAPIController>/5
        [HttpGet("{id}")]
        public string getrap(int id,string tp, string qh)
        {
            var lc = _context.LichChieu.ToList();
            var phi = _context.Phim.ToList();
            var pho = _context.Phong.ToList();
            var sc = _context.SuatChieu.ToList();
            var lp = _context.LoaiPhim.ToList();
            var r = _context.RapChieuPhim.ToList();
            var result1 = from phim in phi
                          join suatchieu in sc on phim.Id equals suatchieu.IdPhim
                          join loaiphim in lp on phim.IdLoaiPhim equals loaiphim.Id
                          join lichchieu in lc on suatchieu.IdLichChieu equals lichchieu.Id
                          join phong in pho on lichchieu.IdPhong equals phong.Id
                          join rap in r on phong.IdRapChieu equals rap.Id
                          where phim.Id == id && rap.ThanhPho == tp && rap.QuanHuyen == qh
                          select new
                          {
                              Id = rap.Id,
                              TenRap = rap.TenRapChieu
                          };
            var result = result1.GroupBy(i => i.TenRap).Select(group => group.First());
            return JsonConvert.SerializeObject(result);
        }

        // POST api/<RapChieuPhimAPIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<RapChieuPhimAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RapChieuPhimAPIController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRap(int id)
        {
            return NoContent();
        }
    }
}
