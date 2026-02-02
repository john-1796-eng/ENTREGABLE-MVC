using LABORATORIO_MVC.Models;
using System;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace LABORATORIO_MVC.Controllers
{
    public class ContactoController : Controller
    {
        // Cadena de conexión tomada del Web.config
        private string cadena = System.Configuration.ConfigurationManager
            .ConnectionStrings["MiConexion"].ConnectionString;

        // Mostrar la vista de contacto
        public ActionResult Index()
        {
            return View();
        }

        // Recibir formulario y guardar en SQL
        [HttpPost]
        public ActionResult Enviar(string nombre, string correo, string mensaje)
        {
            using (SqlConnection con = new SqlConnection(cadena))
            {
                string sql = @"INSERT INTO Contacto (Nombre, Correo, Mensaje, FechaRegistro)
                               VALUES (@n, @c, @m, GETDATE())";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@n", nombre);
                cmd.Parameters.AddWithValue("@c", correo);
                cmd.Parameters.AddWithValue("@m", mensaje);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            TempData["ok"] = "Mensaje enviado correctamente. ¡¡Gracias!!";

            return RedirectToAction("Index");
        }
    }
}
