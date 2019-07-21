using System.Collections.Generic;
using System.Threading.Tasks;
using TestGr4d3.BOL;

namespace TestGr4d3.DAL.IRepositorio
{
    public interface IAsignaturaRepo
    {
        Task<IEnumerable<Asignatura>> ObtenerTodos();
        Task<Asignatura> Obtener(int id);
        Task Agregar(Asignatura asignatura);
        Task Actualizar(Asignatura asignatura);
        Task Eliminar(int id);
    }
}
