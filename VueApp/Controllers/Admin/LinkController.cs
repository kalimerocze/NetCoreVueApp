using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VueApp.Context;
using VueApp.Models;

namespace VueApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LinkController : ControllerBase
    {

        private readonly IConfiguration _config;
        private readonly VueAppDbContext _vueAppDbContext;
        private readonly ILogger<HomeController> _log;
        private IOptions<AppSettingsModel> _settings;


        public LinkController(IConfiguration options, VueAppDbContext vueAppDbContext, ILogger<HomeController> log, IOptions<AppSettingsModel> settings)
        {
            _settings = settings;
            _log = log;
            _config = options;
            _vueAppDbContext = vueAppDbContext;
        }

        [ActionName("Api")]
        [HttpGet("Api")]
        public IActionResult Api()
        {
            return Ok("test");
        }

        [ActionName("Summary")]
        [HttpGet("Summary")]
        public async Task<IActionResult> Summary()
        {
            if (_vueAppDbContext.Link == null)
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
            var links = await _vueAppDbContext.Link.ToListAsync();


            return Ok(links.AsQueryable().ToArray());

        }

        [ActionName("Edit")]
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit([FromBody] Link link)
        {
            if (_vueAppDbContext.Link == null)
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
            var result = await _vueAppDbContext.Link.FindAsync(link.Id);

            if (result != null)
            {
                result.Url = link.Url;
                result.Text = link.Text;
                result.Description = link.Description;
                result.Type = link.Type;
                result.GrouOfLinks = link.GrouOfLinks;
                result.BlockOfLinks = link.BlockOfLinks;
                result.Order = link.Order;
                result.Published = link.Published;
                result.OpenToNewWindow = link.OpenToNewWindow;
                result.ForLoggedUserOnly = link.ForLoggedUserOnly;

                await _vueAppDbContext.SaveChangesAsync();
            }

            return Ok(StatusCodes.Status200OK);

        }

        [ActionName("Delete")]
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (_vueAppDbContext.Link == null)
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
            var link = await _vueAppDbContext.Link.FindAsync(id);
            if (link != null)
            {
                _vueAppDbContext.Link.Remove(link);
                await _vueAppDbContext.SaveChangesAsync();


                return Ok(StatusCodes.Status200OK);
            }
            else
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
        }

        [ActionName("Add")]
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Link Link)
        {
            if (Link != null)
            {
                if (_vueAppDbContext.Link == null)
                {
                    return BadRequest(StatusCodes.Status400BadRequest);
                }
                await _vueAppDbContext.Link.AddAsync(Link);
                await _vueAppDbContext.SaveChangesAsync();

                return Ok(StatusCodes.Status200OK + "done");
            }
            else
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
        }
    }
}