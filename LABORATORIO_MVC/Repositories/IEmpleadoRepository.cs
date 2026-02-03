using System.Collections.Generic;
using LABORATORIO_MVC.Models;

namespace LABORATORIO_MVC.Repositories
{
    public interface IEmpleadoRepository
    {
        IEnumerable<Empleado> ObtenerTodos();
        Empleado ObtenerPorId(int id);
        bool Insertar(Empleado empleado);
        bool Actualizar(Empleado empleado);
        bool Eliminar(int id);
    }
}
