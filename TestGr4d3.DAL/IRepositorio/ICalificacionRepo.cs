using System.Collections.Generic;
using System.Threading.Tasks;
using TestGr4d3.BOL;

namespace TestGr4d3.DAL.IRepositorio
{
    public interface ICalificacionRepo
    {
        Task<IEnumerable<Calificacion>> ObtenerTodos();
        Task<Calificacion> Obtener(int id);
        Task Agregar(Calificacion Calificacion);
        Task Actualizar(Calificacion Calificacion);
        Task Eliminar(int id);
    }
}
