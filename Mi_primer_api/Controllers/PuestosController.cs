using Mi_primer_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mi_primer_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PuestosController : ControllerBase
    {
        private readonly BdEmpresaContext _context;

        public PuestosController(BdEmpresaContext ctx)
        {
            _context = ctx;
        }

        [HttpGet("ListarPuestos")]
        public ActionResult<List<Puesto>> ListarPuestos()
        {
            return _context.Puestos.ToList();
        }

        [HttpGet("BuscarPuesto/{id}")]
        public ActionResult<Puesto> ObtenerPuesto(int id)
        {
            return _context.Puestos.FirstOrDefault(p => p.IdPuestos == id);
        }
        [HttpPost("CrearPuesto")]
        public ActionResult<Puesto> CrearPuesto(Puesto puesto)
        {
            _context.Puestos.Add(puesto);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ObtenerPuesto), new { id = puesto.IdPuestos }, puesto);
        }

        [HttpPut("ActualizarPuesto/{id}")]
        public ActionResult ActualizarPuesto(int id, Puesto puesto)
        {
            if (id != puesto.IdPuestos)
            {
                return BadRequest("El ID del puesto no coincide.");
            }

            var existente = _context.Puestos.Find(id);
            if (existente == null)
            {
                return NotFound();
            }

            _context.Entry(existente).CurrentValues.SetValues(puesto);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
