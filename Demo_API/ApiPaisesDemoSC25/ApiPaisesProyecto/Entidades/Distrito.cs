using System.ComponentModel.DataAnnotations;

namespace ApiPaisesProyecto.Entidades;

public class Distrito {
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "El nombre del distrito es obligatorio.")]
    public string Nombre { get; set; }

    public string? DireccionJuntaDistrital { get; set; }
    public string? Responsable { get; set; }
    public DateTime FechaFundacion { get; set; } = DateTime.Now;
}