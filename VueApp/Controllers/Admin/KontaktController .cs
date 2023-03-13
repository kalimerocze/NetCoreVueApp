using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VueApp.Context;
using VueApp.Models;

namespace VueApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KontaktController : ControllerBase
    {

        private readonly IConfiguration config;
        private readonly VueAppDbContext vueAppDbContext;

        private readonly ILogger<HomeController> _log;
        private IOptions<AppSettingsModel> settings;


        public KontaktController(IConfiguration options, VueAppDbContext vueAppDbContext, ILogger<HomeController> log, IOptions<AppSettingsModel> settings)
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
            
                var kontakty = await vueAppDbContext.Kontakt.ToListAsync();


                return Ok(kontakty.AsQueryable().ToArray()) ;
          
        }

        [ActionName("Edit")]
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit([FromBody] Kontakt _kontakt)
        {

            var result = await vueAppDbContext.Kontakt.FindAsync( _kontakt.Id);

            if (result != null)
            {
                result.Jmeno = _kontakt.Jmeno;
                result.Prijmeni = _kontakt.Prijmeni;
                result.Telefon = _kontakt.Telefon;
                result.Aktivni = _kontakt.Aktivni;
                result.Mesto = _kontakt.Mesto;

                await vueAppDbContext.SaveChangesAsync();
            }

            return Ok(StatusCodes.Status200OK );

        }

        [ActionName("Delete")]
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {

            var kontakt = await vueAppDbContext.Kontakt.FindAsync( id);
            vueAppDbContext.Kontakt.Remove(kontakt);
            await vueAppDbContext.SaveChangesAsync();


            return Ok();

        }

        [ActionName("Add")]
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Kontakt Kontakt)
        {
            if (Kontakt != null)
            {
                await vueAppDbContext.Kontakt.AddAsync(Kontakt);
                await vueAppDbContext.SaveChangesAsync();

                return Ok(StatusCodes.Status200OK +   "done");
            }
            else { return BadRequest(StatusCodes.Status400BadRequest); }
        }

     
    }
}