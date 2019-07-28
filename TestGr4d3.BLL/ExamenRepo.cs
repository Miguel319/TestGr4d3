using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestGr4d3.BOL;
using TestGr4d3.DAL.Contexto;
using TestGr4d3.DAL.IRepositorio;

namespace TestGr4d3.BLL
{
    public class ExamenRepo : BaseContext, IExamenRepo
    {
        public ExamenRepo(DataContext context) : base(context) { }

        public async Task<IEnumerable<Examen>> ObtenerTodos()
            => await _context.Examenes
                .Include(x => x.Calificacion)
                .Include(x => x.Asignatura)
                .Include(x => x.Estudiante)
                .ToListAsync();

        public async Task<Examen> Obtener(int id)
            => await _context.Examenes
                .Include(x => x.Calificacion)
                .Include(x => x.Asignatura)
                .Include(x => x.Estudiante)
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task Agregar(Examen Examen)
        {
            Examen.AgregadoEn = DateTime.Now;
            await _context.Examenes.AddAsync(Examen);
            await _context.SaveChangesAsync();
        }

        public async Task Actualizar(Examen Examen)
        {
            _context.Examenes.Update(Examen);
            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            _context.Examenes.Remove(await Obtener(id));
            await _context.SaveChangesAsync();
        }
    }
}
