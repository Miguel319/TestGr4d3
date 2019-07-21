using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestGr4d3.BOL;
using TestGr4d3.DAL.Contexto;
using TestGr4d3.DAL.IRepositorio;

namespace TestGr4d3.BLL
{
    public class EstudianteRepo : BaseContext, IEstudianteRepo
    {
        public EstudianteRepo(DataContext context) : base(context) { }

        public async Task<IEnumerable<Estudiante>> ObtenerTodos()
            => await _context.Estudiantes.ToListAsync();

        public async Task<Estudiante> Obtener(int id)
            => await _context.Estudiantes.FindAsync(id);

        public async Task Agregar(Estudiante Estudiante)
        {
            Estudiante.FechaIngreso = DateTime.Now;
            await _context.Estudiantes.AddAsync(Estudiante);
            await _context.SaveChangesAsync();
        }

        public async Task Actualizar(Estudiante Estudiante)
        {
            _context.Estudiantes.Update(Estudiante);
            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            _context.Estudiantes.Remove(await Obtener(id));
            await _context.SaveChangesAsync();
        }
    }
}
