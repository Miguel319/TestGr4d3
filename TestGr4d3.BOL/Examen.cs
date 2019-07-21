using System;

namespace TestGr4d3.BOL
{
    public class Examen
    {
        public int Id { get; set; }
        public Estudiante Estudiante { get; set; }
        public Calificacion Calificacion { get; set; }
        public Asignatura Asignatura { get; set; }
        public DateTime AgregadoEn { get; set; }
    }
}