using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetsAPI.Models;
using PetsAPI.DTOs;

namespace PetsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KutyaController : ControllerBase
    {
        [HttpGet("GetById/id={id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                using (PetsContext _context = new PetsContext())
                {
                    var result = _context.Kutyas.FirstOrDefault(k => k.Id == id);
                    if (id == null)
                    {
                        return StatusCode(404, "Nincs ilyen azonosítójú kutya.");
                    }
                    return Ok(result);
                }   
            }
            catch(Exception ex)
            {
                return StatusCode(400, "Hiba");
            }
        }

        [HttpDelete("DeleteById")]
        public IActionResult DeleteById(int id)
        {
            try
            {
                using (PetsContext _context = new PetsContext())
                {
                    var result = _context.Kutyas.FirstOrDefault(k => k.Id == id); //valahova Remove() kellene de nem tudom hova :ccc
                    if (id == null)
                    {
                        return StatusCode(404, "Nincs ilyen azonosítójú kutya.");
                    }
                    return Ok("Sikeres törlés(nem!)");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(400,ex.Message);
            }
            
        }

        [HttpGet("GetAllDTO")]
        public IActionResult GetAllDTO()
        {
            try
            {
                //using (PetsContext _context = new PetsContext)
                //{
                //    List<KutyaDTO> result = _context.KutyaDTOs.ToList();
                //}
                return Ok("Siker");
            }
            catch(Exception ex)
            {
                return StatusCode(400, "Hiba" + ex.Message);
            }
            
        }


    }
}
