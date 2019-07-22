using System.ComponentModel;

namespace TestGr4d3.UI.ViewModels.CalificacionVM
{
    public class CalificacionVMIndex
    {
        public int Id { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public string Feedback { get; set; }
    }
}
