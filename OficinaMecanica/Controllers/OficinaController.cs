using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet("ListarOficinas")]
        public ActionResult<IEnumerable<Oficina>> GetOficinas() 
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

        [HttpGet("{id:int}", Name = "Oficina")]
        public ActionResult GetOficina(int id)
        {
            try
            {
                if (id > 0)
                {
                    var oficina = _context?.Oficinas.Where(w => w.IdOficina == id).AsNoTracking().FirstOrDefault();

                    if (oficina is not null)
                        return Ok(oficina);

                    return BadRequest("Não foram encontradas oficinas.");
                }

                throw new Exception();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "" +
                    "Ocorreu um erro ao processar sua solicitação...");
            }
        }
    }
}
