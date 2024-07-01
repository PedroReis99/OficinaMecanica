using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OficinaMecanica.Context;
using OficinaMecanica.Models;

namespace OficinaMecanica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OficinaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OficinaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Oficina>> Get() 
        {
            try
            {
                var oficina = _context.Oficinas.ToList();

                if(oficina is not null || oficina?.Count > 0)
                    return Ok(oficina);

                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "" +
                    "Ocorreu um erro ao processar sua solicitação...");
            }
        }
    }
}
