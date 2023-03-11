using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VueApp.Context;
using VueApp.Models;

namespace VueApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClanekController : ControllerBase
    {

        private readonly IConfiguration config;
        private readonly VueAppDbContext vueAppDbContext;

        private readonly ILogger<HomeController> _log;
        private IOptions<AppSettingsModel> settings;


        public ClanekController(IConfiguration options, VueAppDbContext vueAppDbContext, ILogger<HomeController> log, IOptions<AppSettingsModel> settings)
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
            
                var clanky = await vueAppDbContext.Clanek.ToListAsync();


                return Ok(clanky.AsQueryable()) ;
          
        }

        [ActionName("Edit")]
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit([FromBody] Clanek _clanek)
        {

            var result = await vueAppDbContext.Clanek.FindAsync( _clanek.Id);

            if (result != null)
            {
                result.Autor = _clanek.Autor;
                result.Nadpis = _clanek.Nadpis;
                result.TypClanku = _clanek.TypClanku;
                result.Text = _clanek.Text;
                result.Poradi = _clanek.Poradi; 
                result.Priloha = _clanek.Priloha; 
                result.ProPrihlasene = _clanek.ProPrihlasene; 
                result.PublikovanoDne = _clanek.PublikovanoDne; 
                result.PublikovanoDo = _clanek.PublikovanoDo; 
                result.VytvorenoDne = _clanek.VytvorenoDne; 

                await vueAppDbContext.SaveChangesAsync();
            }

            return Ok(StatusCodes.Status200OK );

        }

        [ActionName("Delete")]
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {

            var clanek = await vueAppDbContext.Clanek.FindAsync( id);
            vueAppDbContext.Clanek.Remove(clanek);
            await vueAppDbContext.SaveChangesAsync();


            return Ok();

        }

        [ActionName("Add")]
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Clanek Clanek)
        {
            if (Clanek != null)
            {
                await vueAppDbContext.Clanek.AddAsync(Clanek);
                await vueAppDbContext.SaveChangesAsync();

                return Ok(StatusCodes.Status200OK +   "done");
            }
            else { return BadRequest(StatusCodes.Status400BadRequest); }
        }

        [ActionName("Odkaz")]
        [HttpPost("Odkaz")]
        public IActionResult Odkaz([FromBody] Odkaz Odkaz)
        {
            return Ok("done");
        }
    }
}