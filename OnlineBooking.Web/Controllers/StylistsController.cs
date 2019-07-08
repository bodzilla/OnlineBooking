using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<IEnumerable<Stylist>>> GetAll()
        {
            var stylists = await _service.GetAll().ConfigureAwait(false);
            return stylists.ToList();
        }

        [HttpGet("{id:length(24)}", Name = "GetStylist")]
        public async Task<ActionResult<Stylist>> Get(string id)
        {
            var stylist = await _service.Get(id).ConfigureAwait(false);
            if (stylist == null) return NotFound();
            return stylist;
        }

        [HttpPost]
        public async Task<ActionResult<Stylist>> Create(Stylist stylist)
        {
            await _service.Create(stylist).ConfigureAwait(false);
            return CreatedAtRoute("GetStylist", new { id = stylist.Id }, stylist);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Stylist stylist)
        {
            var exists = await _service.Exists(id).ConfigureAwait(false);
            if (!exists) return NotFound();
            var acknowledged = await _service.Update(id, stylist).ConfigureAwait(false);
            return acknowledged ? NoContent() : new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var exists = await _service.Exists(id).ConfigureAwait(false);
            if (!exists) return NotFound();
            var acknowledged = await _service.Remove(id).ConfigureAwait(false);
            return acknowledged ? NoContent() : new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}
