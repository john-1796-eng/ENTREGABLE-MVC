using System;
using System.Data;

namespace LABORATORIO_MVC.EmpleadosWebForm

{
    public partial class Empleados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEmpleados();
            }
        }

        private void CargarEmpleados()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("codigo");
            dt.Columns.Add("nombres");
            dt.Columns.Add("apellidos");
            dt.Columns.Add("direccion");
            dt.Columns.Add("telefono");
            dt.Columns.Add("fecha_nacimiento");
            dt.Columns.Add("puesto");

            // Fila de prueba
            dt.Rows.Add(
                "1",
                "Juan",
                "Pérez",
                "Calle 123",
                "5552222",
                "1990-01-01",
                "Administrador"
            );

            grid_empleados.DataSource = dt;
            grid_empleados.DataBind();
        }
    }
}
