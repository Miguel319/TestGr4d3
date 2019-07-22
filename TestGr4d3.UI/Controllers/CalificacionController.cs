using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestGr4d3.BOL;
using TestGr4d3.DAL.IRepositorio;
using TestGr4d3.UI.ViewModels.CalificacionVM;

namespace TestGr4d3.UI.Controllers
{
    public class CalificacionController : Controller
    {
        private readonly ICalificacionRepo _repo;

        public CalificacionController(ICalificacionRepo repo) => _repo = repo;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var calificaciones = await _repo.ObtenerTodos();

            var calificacionModel = calificaciones.Select(x => new CalificacionVMIndex()
            {
                Id = x.Id,
                Descripcion = x.Descripcion,
                Feedback = x.Feedback
            });

            return View(calificacionModel);
        }

        [HttpGet]
        public IActionResult Agregar() => View();

        [HttpPost]
        public async Task<IActionResult> Agregar(CalificacionVMIndex calificacionVM)
        {
            if (ModelState.IsValid)
            {
                var calificacion = new Calificacion()
                {
                    Id = calificacionVM.Id,
                    Descripcion = calificacionVM.Descripcion,
                    Feedback = calificacionVM.Feedback
                };
                await _repo.Agregar(calificacion);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Actualizar(int id)
        {
                var calificacion = await _repo.Obtener(id);

                var calificacionVM = new CalificacionVMIndex()
                {
                    Id = calificacion.Id,
                    Descripcion = calificacion.Descripcion,
                    Feedback = calificacion.Feedback
                };
                
                return View(calificacionVM);
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar(CalificacionVMIndex calificacionVM)
        {
            if (ModelState.IsValid)
            {
                var calificacion = new Calificacion()
                {
                    Id = calificacionVM.Id,
                    Descripcion = calificacionVM.Descripcion,
                    Feedback = calificacionVM.Feedback
                };
                await _repo.Actualizar(calificacion);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await _repo.Eliminar(id);
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["ErrorCalificacion"] = "Esta calificación fue asignada a un examen. Desasígnela para poder eliminarla.";
                return RedirectToAction("Index");
            }
        }
    }
}