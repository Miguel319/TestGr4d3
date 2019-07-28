using System;
using System.ComponentModel;

namespace TestGr4d3.UI.ViewModels.ExamenVM
{
    public class ExamenDetallesVM
    {
        public int Id { get; set; }
        [DisplayName("Calificación")]
        public string Calificacion { get; set; }
        public string Estudiante { get; set; }
        public string Asignatura { get; set; }
        [DisplayName("Agregado en")]
        public DateTime AgregadoEn { get; set; }
        public string Comentario { get; set; }
    }
}
