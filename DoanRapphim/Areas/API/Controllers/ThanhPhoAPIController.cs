using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoanRapphim.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoanRapphim.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThanhPhoAPIController : ControllerBase
    {
        private readonly DPContext _context;
        public ThanhPhoAPIController(DPContext context)
        {
            _context = context;
        }

        // GET: api/<ThanhPhoAPIController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ThanhPhoAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
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
                          where phim.Id == id
                          select new
                          {
                              ThanhPho = rap.ThanhPho,
                          };
            var result = result1.GroupBy(i => i.ThanhPho).Select(group => group.First());
            return JsonConvert.SerializeObject(result);
        }

        // POST api/<ThanhPhoAPIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ThanhPhoAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ThanhPhoAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
