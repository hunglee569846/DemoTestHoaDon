using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoTestHoaDon.Models;
using DemoTestHoaDon.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoTestHoaDon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        [AcceptVerbs("GET")]
        public IEnumerable<HoaDons> SelectAll_HoaDon()
        {
            return HoaDonServices.GetHoaDon();
        }

        [Route("{id}"),AcceptVerbs("GET")]
        public HoaDons SelectByID_HoaDon(string id)
        {
            return HoaDonServices.GetHoaDonByID(id);
        }

        public IActionResult HoaDon_Insert([FromBody] HoaDons getmeta)
        {
            var KQ = HoaDonServices.AddHoaDon(getmeta);
            if (KQ < 0) return BadRequest("Them loi");
            return Ok("Thanh cong");
        }
    }
}
