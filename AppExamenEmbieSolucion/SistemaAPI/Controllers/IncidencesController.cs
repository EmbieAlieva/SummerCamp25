using Microsoft.AspNetCore.Mvc;
using Dominio;
using DTOs;
using AppData;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace SistemaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncidencesController : ControllerBase
    {
        private readonly ContextDB _context;
        private readonly IMapper _mapper;
        private readonly ILogger<IncidencesController> _logger;

        public IncidencesController(ContextDB context, IMapper mapper, ILogger<IncidencesController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/Incidences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncidenciaDto>>> GetIncidences(
            int page = 1, int pageSize = 10, string? nameClient = null)
        {
            try
            {
                if (page < 1) page = 1;
                if (pageSize < 1) pageSize = 10;

                var query = _context.Incidences.AsQueryable();
                if (!string.IsNullOrWhiteSpace(nameClient))
                {
                    query = query.Where(i => i.NameClient.Contains(nameClient));
                }

                var total = await query.CountAsync();

                var paged = query.OrderBy(i => i.Id)
                                 .Skip((page - 1) * pageSize)
                                 .Take(pageSize);

                var incidences = await paged.ToListAsync();
                return Ok(new {
                    data = _mapper.Map<IEnumerable<IncidenciaDto>>(incidences),
                    total
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener incidencias");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        // GET: api/Incidences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IncidenciaDto>> GetIncidence(int id)
        {
            try
            {
                var incidence = await _context.Incidences.FindAsync(id);
                if (incidence == null)
                    return NotFound();
                return Ok(_mapper.Map<IncidenciaDto>(incidence));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener la incidencia con id {id}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        // POST: api/Incidences
        [HttpPost]
        public async Task<ActionResult<IncidenciaDto>> PostIncidence(IncidenciaDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest("Datos inv�lidos");
                }
                var incidence = new Incidence
                {
                    NameClient = dto.NameClient,
                    Description = dto.Description,
                    ReportedAt = DateTime.TryParse(dto.ReportedAt, out var date) ? date : DateTime.Now,
                    IsUrgent = dto.IsUrgent,
                    Status = Enum.TryParse<IncidentStatus>(dto.Status, out var status) ? status : IncidentStatus.Reported
                };
                _context.Incidences.Add(incidence);
                await _context.SaveChangesAsync();
                var resultDto = _mapper.Map<IncidenciaDto>(incidence);
                return CreatedAtAction(nameof(GetIncidence), new { id = incidence.Id }, resultDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear la incidencia");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        // PUT: api/Incidences/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncidence(int id, IncidenciaDto dto)
        {
            try
            {
                var incidence = await _context.Incidences.FindAsync(id);
                if (incidence == null)
                    return NotFound();
                incidence.NameClient = dto.NameClient;
                incidence.Description = dto.Description;
                incidence.ReportedAt = DateTime.TryParse(dto.ReportedAt, out var date) ? date : incidence.ReportedAt;
                incidence.IsUrgent = dto.IsUrgent;
                incidence.Status = Enum.TryParse<IncidentStatus>(dto.Status, out var status) ? status : incidence.Status;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar la incidencia con id {id}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        // DELETE: api/Incidences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncidence(int id)
        {
            try
            {
                var incidence = await _context.Incidences.FindAsync(id);
                if (incidence == null)
                    return NotFound();
                _context.Incidences.Remove(incidence);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar la incidencia con id {id}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
