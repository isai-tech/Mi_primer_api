using Mi_primer_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace Mi_primer_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly BdEmpresaContext _context;

        public EmpleadosController(BdEmpresaContext ctx)
        {
            _context = ctx;
        }

        [HttpGet("ListarEmpleados")]
        public ActionResult<List<Empleado>> ListarEmpleados()
        {
            return _context.Empleados.ToList();
        }

        [HttpGet("BuscarEmpleado/{id}")]
        public ActionResult<Empleado> ObtenerEmpleado(int id)
        {  
        return _context.Empleados.FirstOrDefault(e => e.IdEmpleados == id);
        }

        [HttpPost("CrearEmpleado")]
        public ActionResult<Empleado> CrearEmpleado(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ObtenerEmpleado), new { id = empleado.IdEmpleados }, empleado);
        }

        [HttpPut("ActualizarEmpleado/{id}")]
        public ActionResult ActualizarEmpleado(int id, Empleado empleado)
        {
            if (id != empleado.IdEmpleados)
                return BadRequest("El id de la URL no coincide con el del cuerpo.");

            var existente = _context.Empleados.Find(id);
            if (existente == null)
                return NotFound();

            _context.Entry(existente).CurrentValues.SetValues(empleado);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
