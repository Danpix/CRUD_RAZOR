using Microsoft.EntityFrameworkCore;
using CrudRazorCore.Models;


namespace CrudRazorCore.Models
{
    public class DualDBContext : DbContext
    {
        public DualDBContext(DbContextOptions<DualDBContext> options) : base(options)
        {

        }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Asesor> Asesores { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Asignacion> Asignaciones { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}