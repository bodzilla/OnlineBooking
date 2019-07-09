using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineBooking.Web.Interfaces;
using OnlineBooking.Web.Models;

namespace OnlineBooking.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StylistsController : ControllerBase
    {
        private readonly ILogger<StylistsController> _logger;
        private readonly IStylistService _service;

        public StylistsController(ILogger<StylistsController> logger, IStylistService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stylist>>> GetAllAsync()
        {
            IEnumerable<Stylist> stylists;
            try
            {
                stylists = await _service.GetAllAsync();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex, "Could not retrieve data.");
            }
            return stylists != null && stylists.Any() ? (ActionResult<IEnumerable<Stylist>>)Ok(stylists) : NotFound();
        }

        [HttpGet("{id:length(24)}", Name = "GetStylist")]
        public async Task<ActionResult<Stylist>> GetAsync(string id)
        {
            Stylist stylist;
            try
            {
                stylist = await _service.GetAsync(id);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex, "Could not retrieve data. Id: {id}", id);
            }
            return stylist != null ? (ActionResult<Stylist>)Ok(stylist) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Stylist>> CreateAsync(Stylist stylist)
        {
            try
            {
                await _service.CreateAsync(stylist);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex, "Could not create. Stylist: {stylist}", stylist);
            }
            return CreatedAtRoute("GetStylist", new { id = stylist.Id }, stylist);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateAsync(string id, Stylist stylist)
        {
            var exists = await _service.ExistsAsync(id);
            if (!exists) return NotFound();
            bool acknowledged;
            try
            {
                acknowledged = await _service.UpdateAsync(id, stylist);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex, "Update not acknowledged. Id: {id}, Stylist: {stylist}", id, stylist);
            }
            return acknowledged ? NoContent() : new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var exists = await _service.ExistsAsync(id);
            if (!exists) return NotFound();
            bool acknowledged;
            try
            {
                acknowledged = await _service.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex, "Delete not acknowledged. Id: {id}", id);
            }
            return acknowledged ? NoContent() : new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

        private StatusCodeResult InternalServerError(Exception ex, string message, params Object[] args)
        {
            _logger.LogError(ex, message, args);
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}
