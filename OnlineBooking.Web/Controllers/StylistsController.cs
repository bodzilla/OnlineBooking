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
        public async Task<ActionResult<IEnumerable<Stylist>>> GetAllAsync()
        {
            var stylists = await _service.GetAllAsync().ConfigureAwait(false);
            return stylists.ToList();
        }

        [HttpGet("{id:length(24)}", Name = "GetStylist")]
        public async Task<ActionResult<Stylist>> GetAsync(string id)
        {
            var stylist = await _service.GetAsync(id).ConfigureAwait(false);
            return stylist != null ? (ActionResult<Stylist>)stylist : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Stylist>> CreateAsync(Stylist stylist)
        {
            await _service.CreateAsync(stylist).ConfigureAwait(false);
            return CreatedAtRoute("GetStylist", new { id = stylist.Id }, stylist);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateAsync(string id, Stylist stylist)
        {
            var exists = await _service.ExistsAsync(id).ConfigureAwait(false);
            if (!exists) return NotFound();
            var acknowledged = await _service.UpdateAsync(id, stylist).ConfigureAwait(false);
            return acknowledged ? NoContent() : new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var exists = await _service.ExistsAsync(id).ConfigureAwait(false);
            if (!exists) return NotFound();
            var acknowledged = await _service.DeleteAsync(id).ConfigureAwait(false);
            return acknowledged ? NoContent() : new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}
