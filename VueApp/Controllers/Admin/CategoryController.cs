using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VueApp.Context;
using VueApp.Models;

namespace VueApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {

        private readonly IConfiguration _config;
        private readonly VueAppDbContext _vueAppDbContext;

        private readonly ILogger<HomeController> _log;
        private IOptions<AppSettingsModel> _settings;


        public CategoryController(IConfiguration options, VueAppDbContext vueAppDbContext, ILogger<HomeController> log, IOptions<AppSettingsModel> settings)
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
            if (_vueAppDbContext.Category == null)
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
            var category = await _vueAppDbContext.Category.ToListAsync();

            return Ok(category.AsQueryable().ToArray());

        }

        [ActionName("Edit")]
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit([FromBody] Category category)
        {
            if (_vueAppDbContext.Category == null)
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
            var result = await _vueAppDbContext.Category.FindAsync(category.Id);

            if (result != null)
            {
                result.Description = category.Description;
                result.Title = category.Title;

                await _vueAppDbContext.SaveChangesAsync();
            }

            return Ok(StatusCodes.Status200OK);

        }

        [ActionName("Delete")]
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (_vueAppDbContext.Category == null)
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
            var article = await _vueAppDbContext.Category.FindAsync(id);
            if (article != null)
            {
                _vueAppDbContext.Category.Remove(article);
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
        public async Task<IActionResult> Add([FromBody] Category Category)
        {
            if (Category != null)
            {
                if (_vueAppDbContext.Category == null)
                {
                    return BadRequest(StatusCodes.Status400BadRequest);
                }
                await _vueAppDbContext.Category.AddAsync(Category);
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