using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using VueApp.Context;
using VueApp.Models;

namespace VueApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {

        private readonly IConfiguration _config;
        private readonly VueAppDbContext _vueAppDbContext;
        private IWebHostEnvironment _hostingEnvironment;
        private readonly ILogger<HomeController> _log;
        private IOptions<AppSettingsModel> _settings;


        public FileController(IConfiguration options, VueAppDbContext vueAppDbContext, ILogger<HomeController> log, IOptions<AppSettingsModel> settings, IWebHostEnvironment environment)
        {
            _hostingEnvironment = environment;
            _settings = settings;
            _log = log;
            _config = options;
            _vueAppDbContext = vueAppDbContext;
        }



        [ActionName("Upload")]
        [HttpPost("Upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            Models.File s = new Models.File()
            {
                FileName = file.FileName,
                Folder = "uploads"
            };
            if (_vueAppDbContext.File == null)
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
            await _vueAppDbContext.File.AddAsync(s);
            await _vueAppDbContext.SaveChangesAsync();

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

                return Ok(StatusCodes.Status200OK + "done");
            }
            else
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
        }
        [ActionName("GetFiles")]
        [HttpGet("GetFiles")]
        public async Task<IActionResult> GetFiles()
        {
            if (_vueAppDbContext.File == null)
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
            var files = await _vueAppDbContext.File.ToListAsync();

            return Ok(files.AsQueryable());
        }

        //static readonly string rootFolder = @"~/uploads";
        [ActionName("DeleteFile")]
        [HttpDelete("DeleteFile/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (_vueAppDbContext.File == null)
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
            var file = await _vueAppDbContext.File.FindAsync(id);
            try
            {
                if (file == null || file.FileName == null || file.FileName == "") { return BadRequest(); }
                var test = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", file.FileName);

                // Check if file exists with its full path    
                if (System.IO.File.Exists(Path.Combine(_hostingEnvironment.WebRootPath, "uploads", file.FileName)))
                {
                    // If file found, delete it    
                    System.IO.File.Delete(Path.Combine(_hostingEnvironment.WebRootPath, "uploads", file.FileName));
                    Console.WriteLine("File deleted.");
                }
                else Console.WriteLine("File not found");
            }
            catch (IOException ioExp)
            {
                Console.WriteLine(ioExp.Message);
            }

            _vueAppDbContext.File.Remove(file);
            await _vueAppDbContext.SaveChangesAsync();

            return Ok();
        }
    }
}