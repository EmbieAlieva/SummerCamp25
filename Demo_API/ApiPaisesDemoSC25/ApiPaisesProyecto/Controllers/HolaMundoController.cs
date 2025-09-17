using ApiPaisesProyecto.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPaisesProyecto.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/holamundo")]
    [ApiController]
    public class HolaMundoController : ControllerBase {

        private ISaludo _saludo;
   
        public HolaMundoController() {
            _saludo = new SaludoRuso();
        }

        // GET: api/holamundo
        [HttpGet]
        public IActionResult Get() {
            //var saludo = new Saludo();
            //Greeting greeting = new Greeting();
            ISaludo saludoEn = new SaludoIngles();
            ISaludo saludoFr = new SaludoFrances();

            return Ok(_saludo.Saludar("Juan"));
        }

        [HttpGet("{nombre}")]
        public IActionResult Get(string nombre) {
            //if (string.IsNullOrEmpty(nombre)) {
            //    return BadRequest("El nombre no puede estar vacío.");
            //}

            return Ok(_saludo.Saludar(nombre));
        }
    }
}
