using ApiPaisesProyecto.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPaisesProyecto.Controllers
{
    //[Route("api/[controller]")] // Route for the controller: api/apartamentos
    [Route("api/apartamentos")] // Route for the controller: api/apartamentos
    [ApiController]
    public class ApartamentosController : ControllerBase  {
        // GET: /api/apartamentos
        [HttpGet] // This method responds to GET requests
        public IActionResult Get() {

            // Crear una lista de apartamentos (simulada) (actualmente vacía)
            var apartamentos = new List<string>
            {
                "Apartamento 1",
                "Apartamento 2",
                "Apartamento 3"
            };

            var apartamentosDto = new List<ApartamentoDto> {
                new ApartamentoDto { Id = 1, Nombre = "Apartamento 1", Ciudad = "Ciudad A"},
                new ApartamentoDto { Id = 2, Nombre = "Apartamento 2", Ciudad = "Ciudad B"},
                new ApartamentoDto { Id = 3, Nombre = "Apartamento 3", Ciudad = "Ciudad C"}
            };
            //return Ok("Hello from ApartamentosController");
            //return Ok(apartamentos);
            return Ok(apartamentosDto);
        }
    }
}
