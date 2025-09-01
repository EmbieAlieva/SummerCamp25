using Dominio;
using Microsoft.EntityFrameworkCore;

namespace AppData;

public class ContextDB : DbContext
{
    public ContextDB(DbContextOptions<ContextDB> options) : base(options) { }

    public DbSet<Incidence> Incidences { get; set; } = null!;
}
