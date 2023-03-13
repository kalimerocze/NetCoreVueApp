using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VueApp.Context;
using VueApp.Models;

namespace VueApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KategorieController : ControllerBase
    {

        private readonly IConfiguration config;
        private readonly VueAppDbContext vueAppDbContext;

        private readonly ILogger<HomeController> _log;
        private IOptions<AppSettingsModel> settings;


        public KategorieController(IConfiguration options, VueAppDbContext vueAppDbContext, ILogger<HomeController> log, IOptions<AppSettingsModel> settings)
        {
            this.settings = settings;
            _log = log;
            config = options;
            this.vueAppDbContext = vueAppDbContext;
        }
        [ActionName("Api")]
        [HttpGet("Api")]
        public IActionResult Api()
        {
            return Ok("test");
        }

        [ActionName("Prehled")]
        [HttpGet("Prehled")]
        public async Task<IActionResult> Prehled()
        {
            
                var kategorie = await vueAppDbContext.Kategorie.ToListAsync();


                return Ok(kategorie.AsQueryable().ToArray()) ;
          
        }

        [ActionName("Edit")]
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit([FromBody] Kategorie _kategorie)
        {

            var result = await vueAppDbContext.Kategorie.FindAsync( _kategorie.Id);

            if (result != null)
            {
                result.Popis = _kategorie.Popis;
                result.Nadpis = _kategorie.Nadpis;

                await vueAppDbContext.SaveChangesAsync();
            }

            return Ok(StatusCodes.Status200OK );

        }

        [ActionName("Delete")]
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {

            var clanek = await vueAppDbContext.Kategorie.FindAsync( id);
            vueAppDbContext.Kategorie.Remove(clanek);
            await vueAppDbContext.SaveChangesAsync();


            return Ok();

        }

        [ActionName("Add")]
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Kategorie Kategorie)
        {
            if (Kategorie != null)
            {
                await vueAppDbContext.Kategorie.AddAsync(Kategorie);
                await vueAppDbContext.SaveChangesAsync();

                return Ok(StatusCodes.Status200OK +   "done");
            }
            else { return BadRequest(StatusCodes.Status400BadRequest); }
        }

    
    }
}