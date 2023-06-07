using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VueApp.Context;
using VueApp.Models;

namespace VueApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsController : ControllerBase
    {

        private readonly IConfiguration _config;
        private readonly VueAppDbContext _vueAppDbContext;
        private readonly ILogger<HomeController> _log;
        private IOptions<AppSettingsModel> _settings;


        public NewsController(IConfiguration options, VueAppDbContext vueAppDbContext, ILogger<HomeController> log, IOptions<AppSettingsModel> settings)
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
            if (_vueAppDbContext.News == null)
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
            var news = await _vueAppDbContext.News.ToListAsync();


            return Ok(news.AsQueryable().ToArray());
        }

        [ActionName("Edit")]
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit([FromBody] News news)
        {
            if (_vueAppDbContext.News == null)
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
            var result = await _vueAppDbContext.News.FindAsync(news.Id);

            if (result != null)
            {
                result.Author = news.Author;
                result.Title = news.Title;
                result.Type = news.Type;
                result.Text = news.Text;
                result.Order = news.Order;
                result.Attachment = news.Attachment;
                result.ForLoggedUserOnly = news.ForLoggedUserOnly;
                result.PublishedOn = news.PublishedOn;
                result.PublishedTo = news.PublishedTo;
                result.CreatedOn = news.CreatedOn;

                await _vueAppDbContext.SaveChangesAsync();
            }

            return Ok(StatusCodes.Status200OK);

        }

        [ActionName("Delete")]
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (_vueAppDbContext.News == null)
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
            var news = await _vueAppDbContext.News.FindAsync(id);
            if (news != null)
            {
                _vueAppDbContext.News.Remove(news);
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
        public async Task<IActionResult> Add([FromBody] News News)
        {
            if (News != null)
            {
                try
                {
                    if (_vueAppDbContext.News == null)
                    {
                        return BadRequest(StatusCodes.Status400BadRequest);
                    }
                    await _vueAppDbContext.News.AddAsync(News);
                    await _vueAppDbContext.SaveChangesAsync();

                }
                catch (Exception e)
                {

                    throw e;
                }

                return Ok(StatusCodes.Status200OK + "done");
            }
            else
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
        }
    }
}