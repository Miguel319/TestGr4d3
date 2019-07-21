using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestGr4d3.BOL;
using TestGr4d3.DAL.Contexto;
using TestGr4d3.DAL.IRepositorio;

namespace TestGr4d3.BLL
{
    public class CalificacionRepo : BaseContext, ICalificacionRepo
    {
        public CalificacionRepo(DataContext context) : base(context) { }

        public async Task<IEnumerable<Calificacion>> ObtenerTodos()
            => await _context.Calificaciones.ToListAsync();

        public async Task<Calificacion> Obtener(int id)
            => await _context.Calificaciones.FindAsync(id);

        public async Task Agregar(Calificacion Calificacion)
        {
            await _context.Calificaciones.AddAsync(Calificacion);
            await _context.SaveChangesAsync();
        }

        public async Task Actualizar(Calificacion Calificacion)
        {
            _context.Calificaciones.Update(Calificacion);
            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            _context.Calificaciones.Remove(await Obtener(id));
            await _context.SaveChangesAsync();
        }
    }
}
