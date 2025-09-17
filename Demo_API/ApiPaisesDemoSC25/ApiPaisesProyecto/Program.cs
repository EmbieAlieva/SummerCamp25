using ApiPaisesProyecto.BaseDatos;
using ApiPaisesProyecto.Entidades;
using ApiPaisesProyecto.Servicios;
using Microsoft.EntityFrameworkCore;
using Bogus;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 3. Configurar la conexión a la base de datos. Al salir en rojo, se debe añadir los usings a EntityFrameworkCore y a ApiPaisesProyecto.BaseDatos
builder.Services.AddDbContext<ContextoBaseDatos>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Inyeccion de dependencias para el servicio de saludo
builder.Services.AddSingleton<ISaludo, SaludoRuso>(); // Registrar el servicio de saludo como singleton
//builder.Services.AddSingleton<ICodigoGenerador, CodigoGenerador>(); // Registrar el servicio de generador de códigos como singleton
builder.Services.AddScoped<ICodigoGenerador, CodigoGenerador>(); // Registrar el contexto de base de datos como scoped

var app = builder.Build();

// Seeding de datos de Apartamento
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ContextoBaseDatos>();

    if (!db.Apartamentos.Any())
    {
        db.Apartamentos.AddRange(
            new Apartamento { Nombre = "Apartamento 1", Ciudad = "Madrid" },
            new Apartamento { Nombre = "Apartamento 2", Ciudad = "Barcelona" },
            new Apartamento { Nombre = "Apartamento 3", Ciudad = "Valencia" }
        );
        db.SaveChanges();

        // 2. Crear 5 edificios, repartidos entre los distritos con Faker
    }
}


// Seeding de datos de Apartamento, Edificio y Distrito, y migración automática solo en desarrollo
//using (var scope = app.Services.CreateScope())
//{
//    var db = scope.ServiceProvider.GetRequiredService<ContextoBaseDatos>();
//    if (app.Environment.IsDevelopment())
//    {
//        db.Database.Migrate();
//    }
//    if (!db.Apartamentos.Any() && !db.Edificios.Any() && !db.Distritos.Any())
//    {
//        // 1. Crear 3 distritos
//        var distritos = new List<Distrito>
//        {
//            new Distrito { Nombre = "Distrito Norte" },
//            new Distrito { Nombre = "Distrito Centro" },
//            new Distrito { Nombre = "Distrito Sur" }
//        };
//        db.Distritos.AddRange(distritos);
//        db.SaveChanges();

//        // 2. Crear 5 edificios, repartidos entre los distritos
//        var edificioFaker = new Faker<Edificio>()
//            .RuleFor(e => e.Nombre, f => $"Edificio {f.UniqueIndex + 1}")
//            .RuleFor(e => e.Ciudad, f => f.Address.City())
//            .RuleFor(e => e.Direccion, f => f.Address.StreetAddress())
//            .RuleFor(e => e.NumeroDePisos, f => f.Random.Int(3, 15))
//            .RuleFor(e => e.Distrito, f => f.PickRandom(distritos));
//        var edificios = edificioFaker.Generate(5);
//        db.Edificios.AddRange(edificios);
//        db.SaveChanges();

//        // 3. Crear 250 apartamentos, asignando edificio aleatorio
//        var apartamentoFaker = new Faker<Apartamento>()
//            .RuleFor(a => a.Nombre, f => $"Apartamento {f.UniqueIndex + 1}")
//            .RuleFor(a => a.Ciudad, f => f.Address.City())
//            .RuleFor(a => a.Puerta, f => f.Random.AlphaNumeric(3).ToUpper())
//            .RuleFor(a => a.Edificio, f => f.PickRandom(edificios));
//        var apartamentos = apartamentoFaker.Generate(250);
//        db.Apartamentos.AddRange(apartamentos);
//        db.SaveChanges();
//    }
//}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


//app.MapGet("/", () => "¡Hola, mundo! Esta es una API de ejemplo para países y apartamentos."); // Modod más fácil de mostrar un mensaje de bienvenida. se debe comentar la línea de swagger

app.UseWelcomePage();

app.Run();

