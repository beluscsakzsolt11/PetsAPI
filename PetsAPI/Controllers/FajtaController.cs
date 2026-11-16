using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetsAPI.Models;

namespace PetsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FajtaController : ControllerBase
    {
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                using (PetsContext _context = new PetsContext())
                {
                    List<Fajtum> result = _context.Fajta.ToList();
                    return Ok(result);
                }
            }
            catch(Exception ex)
            {
                return StatusCode(400, "Hiba történt: " + ex.Message);
            }
        }
    }
}
