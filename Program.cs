using Microsoft.EntityFrameworkCore;
using CrudRazorCore.Models;

var builder = WebApplication.CreateBuilder(args);

// Cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DualDBContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// ❌ QUITADO: app.UseAuthentication();
// ❌ QUITADO: app.UseAuthorization();

// ❌ QUITADO middleware que siempre redirige al login
// Ese era el que te bloqueaba todas las rutas

// Ruta por defecto → Login
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
