using LH_Pets.Models;
using Microsoft.AspNetCore.Mvc;

namespace LH_Pets.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClientesController : ControllerBase
    {
        private static readonly List<Cliente> clientes = new List<Cliente>();

        [HttpGet]
        public ActionResult<List<Cliente>> Get()
        {
            return Ok(clientes);
        }

        [HttpPost]
        public ActionResult<Cliente> Post(Cliente cliente)
        {
            cliente.Id = clientes.Count + 1;
            clientes.Add(cliente);

            return Created("", cliente);
        }
    }
}