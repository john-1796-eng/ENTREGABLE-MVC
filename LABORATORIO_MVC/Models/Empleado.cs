using System;

namespace LABORATORIO_MVC.Models
{
    public class Empleado
    {
        // Identificador único que se genera automáticamente
        public int Id { get; set; }

        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Puesto { get; set; }
    }
}

