using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VueApp.Context;
using VueApp.Models;

namespace VueApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OdkazController : ControllerBase
    {

        private readonly IConfiguration config;
        private readonly VueAppDbContext vueAppDbContext;

        private readonly ILogger<HomeController> _log;
        private IOptions<AppSettingsModel> settings;


        public OdkazController(IConfiguration options, VueAppDbContext vueAppDbContext, ILogger<HomeController> log, IOptions<AppSettingsModel> settings)
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

            var odkazy = await vueAppDbContext.Odkaz.ToListAsync();


            return Ok(odkazy.AsQueryable().ToArray());

        }

        [ActionName("Edit")]
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit([FromBody] Odkaz _odkaz)
        {

            var result = await vueAppDbContext.Odkaz.FindAsync(_odkaz.Id);

            if (result != null)
            {
                result.Url = _odkaz.Url;
                result.Text = _odkaz.Text;
                result.Popis = _odkaz.Popis;
                result.TypOdkazu = _odkaz.TypOdkazu;
                result.SkupinaOdkazu = _odkaz.SkupinaOdkazu;
                result.BlokOdkazu = _odkaz.BlokOdkazu;
                result.Poradi = _odkaz.Poradi;
                result.Zverejnit = _odkaz.Zverejnit;
                result.NoveOkno = _odkaz.NoveOkno;
                result.ProPrihlasene = _odkaz.ProPrihlasene;

                await vueAppDbContext.SaveChangesAsync();
            }

            return Ok(StatusCodes.Status200OK);

        }

        [ActionName("Delete")]
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {

            var odkaz = await vueAppDbContext.Odkaz.FindAsync(id);
            vueAppDbContext.Odkaz.Remove(odkaz);
            await vueAppDbContext.SaveChangesAsync();


            return Ok();

        }

        [ActionName("Add")]
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Odkaz Odkaz)
        {
            if (Odkaz != null)
            {
                await vueAppDbContext.Odkaz.AddAsync(Odkaz);
                await vueAppDbContext.SaveChangesAsync();

                return Ok(StatusCodes.Status200OK + "done");
            }
            else { return BadRequest(StatusCodes.Status400BadRequest); }
        }


    }
}