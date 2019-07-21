using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TestGr4d3.BOL;
using TestGr4d3.DAL.IRepositorio;
using TestGr4d3.UI.ViewModels;
using TestGr4d3.UI.ViewModels.EstudianteVM;

namespace TestGr4d3.UI.Controllers
{
    public class EstudianteController : Controller
    {
        private readonly IEstudianteRepo _repo;

        public EstudianteController(IEstudianteRepo repo) => _repo = repo;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var estudiantes = await _repo.ObtenerTodos();

            var modelo = estudiantes.Select(x => new EstudianteIndexVM()
            {
                Id = x.Id,
                NombreCompleto = x.Nombre + " " + x.Apellido,
                ImagenURL = x.ImagenURL,
                Curso = x.Curso,
            });

            return View(modelo);
        }

        [HttpGet]
        public IActionResult Agregar() => View();

        [HttpPost]
        public async Task<IActionResult> Agregar(EstudianteFormularioVM estudianteFormulario)
        {
            if (ModelState.IsValid)
            {
                var estudiante = new Estudiante()
                {
                    Nombre = estudianteFormulario.Nombre,
                    Apellido = estudianteFormulario.Apellido,
                    Curso = estudianteFormulario.Curso,
                    Edad = estudianteFormulario.Edad,
                    ImagenURL = estudianteFormulario.ImagenURL
                };

                await _repo.Agregar(estudiante);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Actualizar(int id)
        {
            var estudiante = await _repo.Obtener(id);


            var estudianteModel = new EstudianteFormularioVM()
            {
                Id = estudiante.Id,
                Nombre = estudiante.Nombre,
                Apellido = estudiante.Apellido,
                Curso = estudiante.Curso,
                Edad = estudiante.Edad,
                ImagenURL = estudiante.ImagenURL
            };

            return View(estudianteModel);

        }

        [HttpPost]
        public async Task<IActionResult> Actualizar(EstudianteFormularioVM estudianteFormulario)
        {
            if (ModelState.IsValid)
            {
                var estudiante = new Estudiante()
                {
                    Id = estudianteFormulario.Id,
                    Nombre = estudianteFormulario.Nombre,
                    Apellido = estudianteFormulario.Apellido,
                    Curso = estudianteFormulario.Curso,
                    Edad = estudianteFormulario.Edad,
                    ImagenURL = estudianteFormulario.ImagenURL
                };

                await _repo.Actualizar(estudiante);
                return RedirectToAction("Index");
            }

            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> Detalles(int id)
        {
                var estudiante = await _repo.Obtener(id);

                var estudianteVMDetalles = new EstudianteVMDetalles()
                {
                    Id = estudiante.Id,
                    Nombre = estudiante.Nombre,
                    Apellido = estudiante.Apellido,
                    Curso = estudiante.Curso,
                    Edad = estudiante.Edad,
                    ImagenURL = estudiante.ImagenURL,
                    FechaIngreso = estudiante.FechaIngreso
                };

                return View(estudianteVMDetalles);
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
                TempData["ErrorEstudiante"] =
                    "Este estudiante está vinculado con un examen. Desvincúlelo para eliminarlo.";
                return RedirectToAction("Index");
            }

        }
    }
}