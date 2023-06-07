using Microsoft.AspNetCore.Mvc;

namespace VueApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        //private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration _config;
        public HomeController(IConfiguration options)
        {
            _config = options;
        }

        [ActionName("Api")]
        [HttpGet("Api")]
        public IActionResult Api()
        {
            return Ok("test");
        }

        [ActionName("Upload")]
        [HttpPost("Upload")]
        public IActionResult Upload(IFormFile formFiles)
        {
            return Ok(StatusCodes.Status200OK);
        }

        /// <summary>
        ///Zkontroluje zda nechybí některý důležitý adresář nebo soubor pro logování
        /// </summary>
        /// <returns>The value of boolean</returns>
        private static bool CheckFoldersExist(IConfiguration config, out string parametr)
        {
            if (!Directory.Exists(config["CTC:Folder"])) { parametr = config["CTC:Folder"]; return false; }
            if (!System.IO.File.Exists(config["CTC:ErrorLog"])) { parametr = config["CTC:ErrorLog"]; return false; }
            parametr = "";
            return true;
        }

        /// <summary>
        ///Zkontroluje zda nechybí některý důležitý údaj v konfiguraci appsettings.json.Pokud ano vrátí false 
        /// </summary>
        /// <returns>The value of boolean</returns>
        private static bool CheckConfiguration(IConfiguration config, out string parametr)
        {
            if (config["CTC:Sender"] == "") { parametr = "CTC:Sender"; return false; }
            parametr = "";
            return true;
        }
    }
}
