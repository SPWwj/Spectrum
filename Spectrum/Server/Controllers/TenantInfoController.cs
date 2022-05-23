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
    [Route("[controller]")]
    public class TenantInfoController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<TenantInfoController> _logger;
        private readonly ApplicationDbContext _db;


        //constructor then
        
        public TenantInfoController(ILogger<TenantInfoController> logger,
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

        private string GetUserId()
        {
            return HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}