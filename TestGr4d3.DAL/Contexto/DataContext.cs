using Microsoft.EntityFrameworkCore;
using TestGr4d3.BOL;

namespace TestGr4d3.DAL.Contexto
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }


        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Calificacion> Calificaciones { get; set; }
        public DbSet<Examen> Examenes { get; set; }
    }
}
