using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Spectrum.Server.Data;
using Spectrum.Shared.Models;
using Spectrum.Shared;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Spectrum.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PortalController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<PortalController> _logger;
        private readonly ApplicationDbContext _db;


        //constructor then
        
        public PortalController(ILogger<PortalController> logger,
            ApplicationDbContext db)
        {
            _db = db;
            _logger = logger;
        }
        
        [HttpGet]
        public async Task<ActionResult<ApplicationUser>> Get()
        {
            try
            {
                string userId = GetUserId();
                var user = await _db.Users.Where(x => x.Id == userId).Include(x => x.SpectrumPortal)
                    .FirstOrDefaultAsync();
                return Ok(user);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult<string>> CreatePortal(SpectrumPortal spectrumPortal)
        {
            try
            {
                string userId = GetUserId();
                spectrumPortal.ApplicationUserId = userId;
                spectrumPortal.Id = Guid.NewGuid().ToString();
                
                await _db.SpectrumPortal.AddAsync(spectrumPortal);
                await _db.SaveChangesAsync();

                return Ok(spectrumPortal.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("{portalId}")]
        public async Task<IActionResult> DeletePortal(string portalId)
        {
            try
            {
                 _db.SpectrumPortal.Remove(new SpectrumPortal() { Id = portalId} );
                await _db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdatePortal(SpectrumPortal spectrumPortal)
        {
            try
            {
                _db.SpectrumPortal.Update(spectrumPortal);
                await _db.SaveChangesAsync();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private string GetUserId()
        {
            return HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}