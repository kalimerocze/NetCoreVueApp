using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            Soubor s = new Soubor() { NazevSouboru = file.FileName,
                SlozkaSouboru = "uploads"
        };
          await  vueAppDbContext.Soubor.AddAsync(s);
           await vueAppDbContext.SaveChangesAsync();

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
        [ActionName("Soubory")]
        [HttpGet("Soubory")]
        public async Task<IActionResult> Soubory()
        {

            var soubory = await vueAppDbContext.Soubor.ToListAsync();


            return Ok(soubory.AsQueryable());

        }

            static readonly string rootFolder = @"~/uploads";
        [ActionName("DeleteSoubor")]
        [HttpDelete("DeleteSoubor/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var soubor = await vueAppDbContext.Soubor.FindAsync(id);
            try
            {
                var test = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", soubor.NazevSouboru);

                // Check if file exists with its full path    
                if (System.IO.File.Exists(Path.Combine(_hostingEnvironment.WebRootPath,"uploads", soubor.NazevSouboru)))
                {
                    // If file found, delete it    
                    System.IO.File.Delete(Path.Combine(_hostingEnvironment.WebRootPath, "uploads", soubor.NazevSouboru));
                    Console.WriteLine("File deleted.");
                }
                else Console.WriteLine("File not found");
            }
            catch (IOException ioExp)
            {
                Console.WriteLine(ioExp.Message);
            }

            vueAppDbContext.Soubor.Remove(soubor);
            await vueAppDbContext.SaveChangesAsync();


            return Ok();

        }


    }
}