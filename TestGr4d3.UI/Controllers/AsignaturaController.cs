using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TestGr4d3.BOL;
using TestGr4d3.DAL.IRepositorio;
using TestGr4d3.UI.ViewModels.AsignaturaVM;

namespace TestGr4d3.UI.Controllers
{
    public class AsignaturaController : Controller
    {
        private readonly IAsignaturaRepo _repo;

        public AsignaturaController(IAsignaturaRepo repo) => _repo = repo;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var asignaturas = await _repo.ObtenerTodos();

            var asignaturaModel = asignaturas.Select(x => new AsignaturaIndexVM()
            {
                Id = x.Id,
                Nombre = x.Nombre,
                ImagenURL = x.ImagenURL
            });
            return View(asignaturaModel);
        }

        [HttpGet]
        public IActionResult Agregar() => View();

        [HttpPost]
        public async Task<IActionResult> Agregar(AsignaturaIndexVM asignaturaVM)
        {
            if (ModelState.IsValid)
            {
                var asignatura = new Asignatura()
                {
                    Id = asignaturaVM.Id,
                    Nombre = asignaturaVM.Nombre,
                    ImagenURL = asignaturaVM.ImagenURL
                };
                await _repo.Agregar(asignatura);
                return RedirectToAction("Index");
            }
            return View(asignaturaVM);
        }

        [HttpGet]
        public async Task<IActionResult> Actualizar(int id)
        {
            var asignatura = await _repo.Obtener(id);

            var asignaturaVM = new AsignaturaIndexVM()
            {
                Id = asignatura.Id,
                Nombre = asignatura.Nombre,
                ImagenURL = asignatura.ImagenURL
            };

            return View(asignaturaVM);
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar(AsignaturaIndexVM asignaturaVM)
        {
            if (ModelState.IsValid)
            {
                var asignatura = new Asignatura()
                {
                    Id = asignaturaVM.Id,
                    Nombre = asignaturaVM.Nombre,
                    ImagenURL = asignaturaVM.ImagenURL
                };
                await _repo.Actualizar(asignatura);
                return RedirectToAction("Index");
            }

            return View(asignaturaVM);
        }

        [HttpGet]
        public async Task<IActionResult> Detalles(int id)
        {
            var asignatura = await _repo.Obtener(id);

            var asignaturaVM = new AsignaturaVMDetalles()
            {
                Id = asignatura.Id,
                Nombre = asignatura.Nombre,
                ImagenURL = asignatura.ImagenURL
            };
            return View(asignaturaVM);
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
                TempData["ErrorAsignatura"] =
                    "Esta asignatura está vinculada con un examen. Desvincúlela para poder eliminarla.";
                return RedirectToAction("Index");
            }
        }
    }
}