using System;

namespace LABORATORIO_MVC.Models
{
    public class Contacto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Mensaje { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
