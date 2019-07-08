using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OnlineBooking.Web.Interfaces;
using OnlineBooking.Web.Models;

namespace OnlineBooking.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StylistsController : ControllerBase
    {
        private readonly IStylistService _service;

        public StylistsController(IStylistService service) => _service = service;

        [HttpGet]
        public ActionResult<IEnumerable<Stylist>> GetAll() => _service.GetAll().ToList();

        [HttpGet("{id:length(24)}", Name = "GetStylist")]
        public ActionResult<Stylist> Get(string id)
        {
            var stylist = _service.Get(id);
            if (stylist == null) return NotFound();
            return stylist;
        }

        [HttpPost]
        public ActionResult<Stylist> Create(Stylist stylist)
        {
            _service.Create(stylist);
            return CreatedAtRoute("GetStylist", new { id = stylist.Id }, stylist);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Stylist stylist)
        {
            var dbStylist = _service.Get(id);
            if (dbStylist == null) return NotFound();
            _service.Update(id, stylist);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var stylist = _service.Get(id);
            if (stylist == null) return NotFound();
            _service.Remove(stylist.Id);
            return NoContent();
        }
    }
}
