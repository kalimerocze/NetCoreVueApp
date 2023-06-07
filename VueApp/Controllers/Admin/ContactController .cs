using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VueApp.Context;
using VueApp.Models;

namespace VueApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {

        private readonly IConfiguration _config;
        private readonly VueAppDbContext _vueAppDbContext;
        private readonly ILogger<HomeController> _log;
        private IOptions<AppSettingsModel> _settings;


        public ContactController(IConfiguration options, VueAppDbContext vueAppDbContext, ILogger<HomeController> log, IOptions<AppSettingsModel> settings)
        {
            _settings = settings;
            _log = log;
            _config = options;
            _vueAppDbContext = vueAppDbContext;
        }

        [ActionName("Api")]
        [HttpGet("Api")]
        public IActionResult Api()
        {
            return Ok("test");
        }

        [ActionName("Summary")]
        [HttpGet("Summary")]
        public async Task<IActionResult> Summary()
        {
            if (_vueAppDbContext.Contact == null)
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
            var contacts = await _vueAppDbContext.Contact.ToListAsync();


            return Ok(contacts.AsQueryable().ToArray());

        }

        [ActionName("Edit")]
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit([FromBody] Contact contact)
        {
            if (_vueAppDbContext.Contact == null)
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
            var result = await _vueAppDbContext.Contact.FindAsync(contact.Id);

            if (result != null)
            {
                result.Name = contact.Name;
                result.Surname = contact.Surname;
                result.Phone = contact.Phone;
                result.Active = contact.Active;
                result.City = contact.City;

                await _vueAppDbContext.SaveChangesAsync();
            }

            return Ok(StatusCodes.Status200OK);

        }

        [ActionName("Delete")]
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (_vueAppDbContext.Contact == null)
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
            var contact = await _vueAppDbContext.Contact.FindAsync(id);
            if (contact != null)
            {

                _vueAppDbContext.Contact.Remove(contact);
                await _vueAppDbContext.SaveChangesAsync();


                return Ok(StatusCodes.Status200OK);
            }
            else
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
        }

        [ActionName("Add")]
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Contact Contact)
        {
            if (Contact != null)
            {
                if (_vueAppDbContext.Contact == null)
                {
                    return BadRequest();
                }
                await _vueAppDbContext.Contact.AddAsync(Contact);
                await _vueAppDbContext.SaveChangesAsync();

                return Ok(StatusCodes.Status200OK + "done");
            }
            else
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
        }
    }
}