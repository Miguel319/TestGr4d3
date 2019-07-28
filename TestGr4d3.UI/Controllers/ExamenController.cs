using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TestGr4d3.BOL;
using TestGr4d3.DAL.IRepositorio;
using TestGr4d3.UI.ViewModels.ExamenVM;

namespace TestGr4d3.UI.Controllers
{
    public class ExamenController : Controller
    {
        private readonly IExamenRepo _repo;
        private readonly IAsignaturaRepo _asignaturaRepo;
        private readonly ICalificacionRepo _calificacionRepo;
        private readonly IEstudianteRepo _estudianteRepo;

        public ExamenController(IExamenRepo repo, IAsignaturaRepo asignaturaRepo, 
            ICalificacionRepo calificacionRepo, IEstudianteRepo estudianteRepo)
        {
            _repo = repo;
            _asignaturaRepo = asignaturaRepo;
            _calificacionRepo = calificacionRepo;
            _estudianteRepo = estudianteRepo;
        }

        public async Task<IActionResult> Index()
        {
            var examenes = await _repo.ObtenerTodos();

            var examenVM = examenes.Select(x => new ExamenIndexVM()
            {
                Id = x.Id,
                Estudiante = x.Estudiante.Nombre + " " + x.Estudiante.Apellido,
                Asignatura = x.Asignatura.Nombre,
                Calificacion = x.Calificacion.Descripcion,
                Comentario = x.Comentario
            });

            return View(examenVM);
        }

        [HttpGet]
        public async Task<IActionResult> Agregar()
        {
            var formulario = new ExamenFormularioVM()
            {
                Asignaturas = await _asignaturaRepo.ObtenerTodos(),
                Estudiantes = await _estudianteRepo.ObtenerTodos(),
                Calificaciones = await _calificacionRepo.ObtenerTodos()
            };

            return View(formulario);
        } 

        [HttpPost]
        public async Task<IActionResult> Agregar(ExamenFormularioVM examenVM)
        {
            if (ModelState.IsValid)
            {
                examenVM.Asignaturas = await _asignaturaRepo.ObtenerTodos();
                examenVM.Estudiantes = await _estudianteRepo.ObtenerTodos();
                examenVM.Calificaciones = await _calificacionRepo.ObtenerTodos();

                var examen = new Examen()
                {
                    Estudiante = await _estudianteRepo.Obtener(examenVM.EstudianteId),
                    Asignatura = await  _asignaturaRepo.Obtener(examenVM.AsignaturaId),
                    Calificacion = await _calificacionRepo.Obtener(examenVM.CalificacionId),
                    Comentario = examenVM.Comentario
                };
                await _repo.Agregar(examen);
                return RedirectToAction("Index");
            }
            return View(examenVM);
        }

        [HttpGet]
        public async Task<IActionResult> Actualizar(int id)
        {
            var examenFormulario = new ExamenFormularioVM()
            {
                Asignaturas = await _asignaturaRepo.ObtenerTodos(),
                Calificaciones = await _calificacionRepo.ObtenerTodos(),
                Estudiantes = await _estudianteRepo.ObtenerTodos()
            };

            return View(examenFormulario);
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar(ExamenFormularioVM examenFormulario)
        {
            if (ModelState.IsValid)
            {
                var examen = new Examen()
                {
                    Id = examenFormulario.Id,
                    Estudiante = examenFormulario.Estudiantes.FirstOrDefault(x => x.Id == examenFormulario.EstudianteId),
                    Asignatura = examenFormulario.Asignaturas.FirstOrDefault(x => x.Id == examenFormulario.AsignaturaId),
                    Calificacion = examenFormulario.Calificaciones.FirstOrDefault(x => x.Id == examenFormulario.CalificacionId)
                };

                await _repo.Actualizar(examen);
                return RedirectToAction("Index");
            }

            return View(examenFormulario);
        }

        [HttpGet]
        public async Task<IActionResult> Detalles(int id)
        {
            var examen = await _repo.Obtener(id);

            var examenDetallesVM = new ExamenDetallesVM()
            {
                Id = examen.Id,
                Asignatura = examen.Asignatura.Nombre,
                Estudiante = examen.Estudiante.Nombre + " " + examen.Estudiante.Apellido,
                Calificacion = examen.Calificacion.Descripcion,
                Comentario = examen.Comentario,
                AgregadoEn = examen.AgregadoEn
            };

            return View(examenDetallesVM);
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
                TempData["ErrorExamen"] = "Error al eliminar el examen. Vuelva a intentarlo.";
                return RedirectToAction("Index");
            }
        }
    }
}