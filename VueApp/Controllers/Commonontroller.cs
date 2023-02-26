﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using VueApp.Context;
using VueApp.Models;

namespace VueApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommonController : ControllerBase
    {

        private readonly IConfiguration config;
        private readonly VueAppDbContext vueAppDbContext;

        private readonly ILogger<HomeController> _log;
        private IOptions<AppSettingsModel> settings;


        public CommonController(IConfiguration options, VueAppDbContext vueAppDbContext, ILogger<HomeController> log, IOptions<AppSettingsModel> settings)
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
        [ActionName("Upload")]
        [HttpPost("Upload")]
        public async Task<IActionResult> Upload([FromBody] Clanek Clanek)
        {
            if (Clanek != null)
            {
                await vueAppDbContext.Clanek.AddAsync(Clanek);
                await vueAppDbContext.SaveChangesAsync();

                return Ok("done");
            }
            else { return BadRequest(); }
        }

        [ActionName("Odkaz")]
        [HttpPost("Odkaz")]
        public IActionResult Odkaz([FromBody] Odkaz Odkaz)
        {
            return Ok("done");
        }
    }
}