using System.Collections.Generic;
using System.Threading.Tasks;
using TestGr4d3.BOL;

namespace TestGr4d3.DAL.IRepositorio
{
    public interface IExamenRepo
    {
        Task<IEnumerable<Examen>> ObtenerTodos();
        Task<Examen> Obtener(int id);
        Task Agregar(Examen Examen);
        Task Actualizar(Examen Examen);
        Task Eliminar(int id);
    }
}
