using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoanRapphim.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoanRapphim.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DangKyAPIController : ControllerBase
    {

        private readonly DPContext _context;

        public DangKyAPIController(DPContext context)
        {
            _context = context;
        }

        // GET: api/<DangKyController>
        [HttpGet]
        [HttpGet("KiemTra")]
        public bool Get(string Ten)
        {
            bool KQ;
            var r = _context.NguoiDung.Where(d => (d.TaiKhoan == Ten)).ToList();
            if (r.Count == 0)
            {
                return KQ = true;
            }
            else
            {
                return KQ = false;
            }
        }

        // GET api/<DangKyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DangKyController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DangKyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DangKyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
