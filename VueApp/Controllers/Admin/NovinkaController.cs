using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VueApp.Context;
using VueApp.Models;

namespace VueApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NovinkaController : ControllerBase
    {

        private readonly IConfiguration config;
        private readonly VueAppDbContext vueAppDbContext;

        private readonly ILogger<HomeController> _log;
        private IOptions<AppSettingsModel> settings;


        public NovinkaController(IConfiguration options, VueAppDbContext vueAppDbContext, ILogger<HomeController> log, IOptions<AppSettingsModel> settings)
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

            var novinky = await vueAppDbContext.Novinka.ToListAsync();


            return Ok(novinky.AsQueryable().ToArray());
        }

        [ActionName("Edit")]
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit([FromBody] Novinka _novinka)
        {

            var result = await vueAppDbContext.Novinka.FindAsync(_novinka.Id);

            if (result != null)
            {
                result.Autor = _novinka.Autor;
                result.Nadpis = _novinka.Nadpis;
                result.TypClanku = _novinka.TypClanku;
                result.Text = _novinka.Text;
                result.Poradi = _novinka.Poradi;
                result.Priloha = _novinka.Priloha;
                result.ProPrihlasene = _novinka.ProPrihlasene;
                result.PublikovanoDne = _novinka.PublikovanoDne;
                result.PublikovanoDo = _novinka.PublikovanoDo;
                result.VytvorenoDne = _novinka.VytvorenoDne;

                await vueAppDbContext.SaveChangesAsync();
            }

            return Ok(StatusCodes.Status200OK );

        }

        [ActionName("Delete")]
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {

            var clanek = await vueAppDbContext.Novinka.FindAsync(id);
            vueAppDbContext.Novinka.Remove(clanek);
            await vueAppDbContext.SaveChangesAsync();


            return Ok();

        }

        [ActionName("Add")]
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Novinka Novinka)
        {
            if (Novinka != null)
            {
                await vueAppDbContext.Novinka.AddAsync(Novinka);
                await vueAppDbContext.SaveChangesAsync();

                return Ok(StatusCodes.Status200OK + "done");
            }
            else { return BadRequest(StatusCodes.Status400BadRequest); }
        }


    }
}