using System;

namespace TestGr4d3.BOL
{
    public class Examen
    {
        public int Id { get; set; }
        public string Tema { get; set; }
        public virtual Calificacion Calificacion { get; set; }
        public virtual Estudiante Estudiante { get; set; }
        public virtual Asignatura Asignatura { get; set; }
        public DateTime AgregadoEn { get; set; }
        public string Comentario { get; set; }


        public Examen()
        {
            Calificacion = new Calificacion();
            Estudiante = new Estudiante();
            Asignatura = new Asignatura();
        }
    }
}