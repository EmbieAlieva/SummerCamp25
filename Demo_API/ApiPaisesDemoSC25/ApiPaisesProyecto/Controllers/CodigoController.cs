using ApiPaisesProyecto.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPaisesProyecto.Controllers;

//[Route("api/[controller]")]
[Route("api/codigo")]
[ApiController]
public class CodigoController : ControllerBase {

    private ICodigoGenerador _codigoGenerador;

    public CodigoController() {
        _codigoGenerador = new CodigoGenerador();
    }
    // GET: api/codigo/{prefijo}

    [HttpGet("{prefijo}")]
    public IActionResult Get(string prefijo) {

        if (string.IsNullOrEmpty(prefijo)) {
            return BadRequest("El prefijo no puede estar vacío.");
        }
        if (prefijo.Length > 3) {  prefijo = prefijo.Substring(0, 3); }
        return Ok(_codigoGenerador.GenerarCodigo($"{prefijo}"));
    }
}

