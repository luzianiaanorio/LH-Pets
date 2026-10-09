using LH_Pets.Models;
using Microsoft.AspNetCore.Mvc;

namespace LH_Pets.Controllers
{
    [ApiController]
    [Route("api/pets")]
    public class PetsController : ControllerBase
    {
        private static readonly List<Pet> pets = new List<Pet>();

        [HttpGet]
        public ActionResult<List<Pet>> Get()
        {
            return Ok(pets);
        }

        [HttpPost]
        public ActionResult<Pet> Post(Pet pet)
        {
            pet.Id = pets.Count + 1;
            pets.Add(pet);

            return Created("", pet);
        }

        [HttpGet("cliente/{clienteId}")]
        public ActionResult<List<Pet>> GetPorCliente(int clienteId)
        {
            var petsDoCliente = pets
                .Where(pet => pet.ClienteId == clienteId)
                .ToList();

            return Ok(petsDoCliente);
        }
    }
}
