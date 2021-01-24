using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DoanRapphim.Areas.Admin.Models;
using DoanRapphim.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoanRapphim.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiSuatChieuAPIController : ControllerBase
    {


        private readonly DPContext _context;

        public LoaiSuatChieuAPIController(DPContext context)
        {
            _context = context;
        }
        // GET: api/<LoaiSuatChieuAPIController>
        [HttpGet]
        public string Get()
        {
            var lsc = from m in _context.LoaiSuatChieu
                      select m;
            return JsonConvert.SerializeObject(lsc);
        }
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var lsc = from m in _context.LoaiSuatChieu
                      where m.Id == id
                      select m;
            return JsonConvert.SerializeObject(lsc);
        }
    }
}
