using ApiPaisesProyecto.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ApiPaisesProyecto.BaseDatos;

public class ContextoBaseDatos : DbContext {

    public ContextoBaseDatos(DbContextOptions<ContextoBaseDatos> options) : base(options) { }

    public DbSet<Apartamento> Apartamentos { get; set; }
    public DbSet<Edificio> Edificios { get; set; }
    public DbSet<Distrito> Distritos { get; set; }
}
