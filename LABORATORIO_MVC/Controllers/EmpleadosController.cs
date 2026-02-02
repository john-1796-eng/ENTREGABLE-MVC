using LABORATORIO_MVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LABORATORIO_MVC.Controllers
{
    public class EmpleadosController : Controller
    {
        // Lista temporal
        private static List<Empleado> empleados = new List<Empleado>();

        // LISTADO
        public ActionResult Index()
        {
            return View("~/Views/Empleados_2/Index.cshtml", empleados);
        }

        // CREAR (GET)
        public ActionResult Crear()
        {
            return View("~/Views/Empleados_2/Crear.cshtml");
        }

        // CREAR (POST)
        [HttpPost]
        public ActionResult Crear(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                empleado.Id = empleados.Count + 1;
                empleados.Add(empleado);
                return RedirectToAction("Index");
            }

            // Volver a la vista correcta
            return View("~/Views/Empleados_2/Crear.cshtml", empleado);
        }
        public ActionResult Formulario()
        {
            return View("~/Views/Empleados_2/Formulario.cshtml");
        }

    }
}
