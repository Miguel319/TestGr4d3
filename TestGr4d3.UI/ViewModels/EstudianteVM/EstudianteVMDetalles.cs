﻿using System;

namespace TestGr4d3.UI.ViewModels.EstudianteVM
{
    public class EstudianteVMDetalles
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Curso { get; set; }
        public string ImagenURL { get; set; }
        public DateTime FechaIngreso { get; set; }
    }
}