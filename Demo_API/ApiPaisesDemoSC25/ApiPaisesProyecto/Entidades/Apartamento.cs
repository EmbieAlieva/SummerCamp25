namespace ApiPaisesProyecto.Entidades;

public class Apartamento {
    public int Id { get; internal set; }
    public string Nombre { get; internal set; }
    public string Ciudad { get; internal set; }

    public Edificio Edificio { get; internal set; }
    public string Puerta { get; internal set; }
}
