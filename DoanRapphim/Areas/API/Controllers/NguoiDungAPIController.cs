using DoanRapphim.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoanRapphim.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiDungAPIController : ControllerBase
    {
        private readonly DPContext _context;

        public NguoiDungAPIController(DPContext context)
        {
            _context = context;
        }
        // GET: api/<NguoiDungController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<NguoiDungController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NguoiDungController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<NguoiDungController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NguoiDungController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        public bool Thaydoitrangthai(int id)
        {
            var nguoidung = _context.NguoiDung.Find(id);
            nguoidung.TinhTrang = !nguoidung.TinhTrang;
            _context.SaveChangesAsync();
            return nguoidung.TinhTrang;
        }
        [HttpGet("Thaydoitrangthai")]
        public string ThaydoitrangthaiJson(int id)
        {
            var result = Thaydoitrangthai(id);
            return JsonConvert.SerializeObject(result);
        }
    }
}
