namespace ApiPaisesProyecto.Models;

public class ApartamentoDto
{
  

    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Ciudad { get; set; }

    public ApartamentoDto() { }

    public ApartamentoDto(int id, string nombre, string ciudad)
    {
        Id = id;
        Nombre = nombre;
        Ciudad = ciudad;
    }
}
