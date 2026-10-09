using Mi_primer_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mi_primer_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly BdEmpresaContext _context;
        public ClientesController(BdEmpresaContext ctx)
        {
            _context = ctx;
        }

        [HttpGet("ListarUsuarios")]
        public ActionResult <List<Cliente>> ListarClientes()
        {
            return _context.Clientes.ToList();
        }

        [HttpGet("BuscarUsuario/{id}")]
        public ActionResult<Cliente> ObtenerUsuario(int id)
        {
            return _context.Clientes.FirstOrDefault(e => e.Idclientes == id);
        }
        [HttpPost("AgregarUsuario")]
        public ActionResult<Cliente> AgregarUsuario(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ObtenerUsuario), new { id = cliente.Idclientes }, cliente);
        }
        [HttpPut("ActualizarUsuario/{id}")]
        public ActionResult ActualizarUsuario(int id, Cliente cliente)
        {
            if (id != cliente.Idclientes)
                return BadRequest("El ID del cliente no coincide.");

            var existente= _context.Clientes.Find(id);
            if (existente == null)
            {
                return NotFound();
            }

            _context.Entry(existente).CurrentValues.SetValues(cliente);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
    