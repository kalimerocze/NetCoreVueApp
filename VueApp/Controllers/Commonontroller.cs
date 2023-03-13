using Microsoft.AspNetCore.Mvc;
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
        private IWebHostEnvironment _hostingEnvironment;
        private readonly ILogger<HomeController> _log;
        private IOptions<AppSettingsModel> settings;


        public CommonController(IConfiguration options, VueAppDbContext vueAppDbContext, ILogger<HomeController> log, IOptions<AppSettingsModel> settings, IWebHostEnvironment environment)
        {
            _hostingEnvironment = environment;
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
        public async Task<IActionResult> Upload(IFormFile file)
        {


            if (file != null)
            {
                string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
               
                    if (file.Length > 0)
                    {
                        string filePath = Path.Combine(uploads, file.FileName);
                        using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }
                    }
        

                return Ok("done");
            }
            else { return BadRequest(); }
        }

       
    }
}