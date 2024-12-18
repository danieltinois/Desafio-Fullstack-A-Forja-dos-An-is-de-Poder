using Microsoft.EntityFrameworkCore;
using AnelPowerAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Usar SQLite em vez de SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5152") // Substitua pelo URL do seu frontend
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Adicionar middleware de CORS
app.UseCors("AllowFrontend");

app.UseHttpsRedirection();
app.UseRouting();

app.MapControllers();

app.Run();
