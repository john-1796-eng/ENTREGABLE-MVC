using LABORATORIO_MVC.Models;
using LABORATORIO_MVC.Repositories;
using System.Web.Mvc;

namespace LABORATORIO_MVC.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly IEmpleadoRepository _repository;

        public EmpleadosController()
        {
            _repository = new EmpleadoRepository();
        }

        // ==========================
        // LISTADO
        // ==========================
        public ActionResult Index()
        {
            var empleados = _repository.ObtenerTodos();
            return View("~/Views/Empleados_2/Index.cshtml", empleados);
        }

        // ==========================
        // CREAR (GET)
        // ==========================
        public ActionResult Crear()
        {
            return View("~/Views/Empleados_2/Crear.cshtml");
        }

        // ==========================
        // CREAR (POST)
        // ==========================
        [HttpPost]
        public ActionResult Crear(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _repository.Insertar(empleado);
                return RedirectToAction("Index");
            }

            return View("~/Views/Empleados_2/Crear.cshtml", empleado);
        }

        // ==========================
        // EDITAR (GET)
        // ==========================
        public ActionResult Editar(int id)
        {
            var empleado = _repository.ObtenerPorId(id);

            if (empleado == null)
            {
                return HttpNotFound();
            }

            return View("~/Views/Empleados_2/Editar.cshtml", empleado);
        }

        // ==========================
        // EDITAR (POST)
        // ==========================
        [HttpPost]
        public ActionResult Editar(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _repository.Actualizar(empleado);
                return RedirectToAction("Index");
            }

            return View("~/Views/Empleados_2/Editar.cshtml", empleado);
        }

        // ==========================
        // ELIMINAR (GET)
        // ==========================
        public ActionResult Eliminar(int id)
        {
            var empleado = _repository.ObtenerPorId(id);

            if (empleado == null)
            {
                return HttpNotFound();
            }

            return View("~/Views/Empleados_2/Eliminar.cshtml", empleado);
        }

        // ==========================
        // ELIMINAR (POST)
        // ==========================
        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmado(int id)
        {
            _repository.Eliminar(id);
            return RedirectToAction("Index");
        }

        // ==========================
        // FORMULARIO (Tu WebForm embebido)
        // ==========================
        public ActionResult Formulario()
        {
            return View("~/Views/Empleados_2/Formulario.cshtml");
        }
    }
}
