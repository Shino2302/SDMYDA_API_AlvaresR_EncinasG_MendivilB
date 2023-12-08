using DB;
using Microsoft.EntityFrameworkCore;
using SDMYDA_API_AlvaresR_EncinasG_MendivilB.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SDMYDAContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaDeConeccion"));
});


//Añadir Servicios:
builder.Services.AddTransient<UsuarioService>();
builder.Services.AddTransient<MascotaService>();
builder.Services.AddTransient<DetalleMascotaHoraProgramadaService>();
builder.Services.AddTransient<HoraProgramadaService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<SDMYDAContext>();
    dataContext.Database.Migrate();
}

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

app.UseAuthorization();

app.MapControllers();

app.Run();
