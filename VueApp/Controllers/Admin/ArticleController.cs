using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VueApp.Context;
using VueApp.Models;

namespace VueApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {

        private readonly IConfiguration _config;
        private readonly VueAppDbContext _vueAppDbContext;
        private readonly ILogger<HomeController> _log;
        private IOptions<AppSettingsModel> _settings;
        private IHttpContextAccessor _httpContextAccessor;

     
        public ArticleController(IConfiguration options, VueAppDbContext vueAppDbContext, ILogger<HomeController> log, IOptions<AppSettingsModel> settings, IHttpContextAccessor httpContextAccessor)
        {
            _settings = settings;
            _log = log;
            _config = options;
            _vueAppDbContext = vueAppDbContext;
            _httpContextAccessor = httpContextAccessor;
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
            var user = _httpContextAccessor.HttpContext?.User;


            if (_vueAppDbContext.Article == null)
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
            var clanky = await _vueAppDbContext.Article.ToListAsync();

            return Ok(clanky.AsQueryable().ToArray());
        }

        [ActionName("Edit")]
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit([FromBody] Article article)
        {
            if (_vueAppDbContext.Article == null)
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
            var result = await _vueAppDbContext.Article.FindAsync(article.Id);

            if (result != null)
            {
                result.Author = article.Author;
                result.Title = article.Title;
                result.Type = article.Type;
                result.Text = article.Text;
                result.Order = article.Order;
                result.Attachment = article.Attachment;
                result.ForLoggedUserOnly = article.ForLoggedUserOnly;
                result.PublishedOn = article.PublishedOn;
                result.PublishedOn = article.PublishedOn;
                result.CreatedOn = article.CreatedOn;

                await _vueAppDbContext.SaveChangesAsync();
            }

            return Ok(StatusCodes.Status200OK);

        }

        [ActionName("Delete")]
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (_vueAppDbContext.Article == null)
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
            var article = await _vueAppDbContext.Article.FindAsync(id);
            if (article != null)
            {
                _vueAppDbContext.Article.Remove(article);
                await _vueAppDbContext.SaveChangesAsync();


                return Ok(StatusCodes.Status200OK);
            }
            else { 
                return BadRequest(StatusCodes.Status400BadRequest); 
            }
        }

        [ActionName("Add")]
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Article Article)
        {
            if (Article != null)
            {
                if (_vueAppDbContext.Article == null)
                {
                    return BadRequest();
                }
                await _vueAppDbContext.Article.AddAsync(Article);
                await _vueAppDbContext.SaveChangesAsync();

                return Ok(StatusCodes.Status200OK + "done");
            }
            else {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
        }
    }
}