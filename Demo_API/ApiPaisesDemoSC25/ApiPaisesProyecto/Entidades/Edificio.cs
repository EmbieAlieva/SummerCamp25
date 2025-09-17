namespace ApiPaisesProyecto.Entidades
{
    public class Edificio
    {
        public int Id { get; internal set; }
        public string Nombre { get; internal set; }
        public string? Ciudad { get; internal set; }
        public string? Direccion { get; internal set; }
        public int? NumeroDePisos { get; internal set; }

        public Distrito Distrito { get; set; }
    }
}
