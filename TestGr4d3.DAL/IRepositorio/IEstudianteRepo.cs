using System.Collections.Generic;
using System.Threading.Tasks;
using TestGr4d3.BOL;

namespace TestGr4d3.DAL.IRepositorio
{
    public interface IEstudianteRepo
    {
        Task<IEnumerable<Estudiante>> ObtenerTodos();
        Task<Estudiante> Obtener(int id);
        Task Agregar(Estudiante Estudiante);
        Task Actualizar(Estudiante Estudiante);
        Task Eliminar(int id);
    }
}
