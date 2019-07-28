using System.Collections.Generic;
using TestGr4d3.BOL;

namespace TestGr4d3.UI.ViewModels.ExamenVM
{
    public class ExamenFormularioVM
    {
        public int Id { get; set; }
        public IEnumerable<Estudiante> Estudiantes { get; set; }
        public int EstudianteId { get; set; }
        public IEnumerable<Calificacion> Calificaciones { get; set; }
        public int CalificacionId { get; set; }
        public IEnumerable<Asignatura> Asignaturas { get; set; }
        public int AsignaturaId { get; set; }
        public string Comentario { get; set; }
    }
}