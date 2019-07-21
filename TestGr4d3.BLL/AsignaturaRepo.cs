using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestGr4d3.BOL;
using TestGr4d3.DAL.Contexto;
using TestGr4d3.DAL.IRepositorio;

namespace TestGr4d3.BLL
{
    public class AsignaturaRepo : BaseContext, IAsignaturaRepo
    {
        public AsignaturaRepo(DataContext context) : base(context) { }

        public async Task<IEnumerable<Asignatura>> ObtenerTodos()
            => await _context.Asignaturas.ToListAsync();

        public async Task<Asignatura> Obtener(int id)
            => await _context.Asignaturas.FindAsync(id);

        public async Task Agregar(Asignatura Asignatura)
        {
            await _context.Asignaturas.AddAsync(Asignatura);
            await _context.SaveChangesAsync();
        }

        public async Task Actualizar(Asignatura Asignatura)
        {
            _context.Asignaturas.Update(Asignatura);
            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            _context.Asignaturas.Remove(await Obtener(id));
            await _context.SaveChangesAsync();
        }
    }
}
