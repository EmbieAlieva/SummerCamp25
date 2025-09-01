using AppData;
using Microsoft.EntityFrameworkCore;
using Serilog;
using SistemaAPI.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agregar el contexto de base de datos
builder.Services.AddDbContext<ContextDB>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agregar servicio de Serilog
builder.Logging.AddSerilog();
// Configurar AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));
// CORS: permite solicitudes desde Angular (localhost:4200)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowAll");

// Seeding de datos de Incidence (con manejo de errores)
try
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<ContextDB>();
        // Solo aplica migraciones y seeding en desarrollo
        if (app.Environment.IsDevelopment())
        {
            context.Database.Migrate();
        }
        if (!context.Incidences.Any())
        {
            var incidencias = new List<Dominio.Incidence>();
            var nombres = new[] { "Juan Perez", "Ana García", "Carlos López", "Lucía Torres", "Pedro Sánchez" };
            var descripciones = new[]
            {
                "Problema con el acceso al sistema.",
                "Error en la generación de reportes.",
                "Solicitud de cambio de contraseña.",
                "Fallo en la impresión de documentos.",
                "Consulta sobre facturación."
            };
            var estados = Enum.GetValues(typeof(Dominio.IncidentStatus));
            var random = new Random();
            for (int i = 0; i < 50; i++)
            {
                incidencias.Add(new Dominio.Incidence
                {
                    NameClient = nombres[i % nombres.Length],
                    Description = descripciones[i % descripciones.Length],
                    ReportedAt = DateTime.Now.AddDays(-random.Next(0, 30)),
                    IsUrgent = random.Next(0, 2) == 0,
                    Status = (Dominio.IncidentStatus)estados.GetValue(random.Next(estados.Length))!
                });
            }
            context.Incidences.AddRange(incidencias);
            context.SaveChanges();
        }
    }
}
catch (Exception ex)
{
    // Loguea el error y permite que la app siga funcionando
    Log.Error(ex, "Error durante el seeding de datos");
}

app.Run();
