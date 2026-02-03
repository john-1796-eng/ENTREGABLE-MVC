using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace LABORATORIO_MVC.EmpleadosWebForm
{
    public partial class Empleados : System.Web.UI.Page
    {
        string conexion = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEmpleados();
            }
        }

        // ============================================================
        // 🚀 CARGAR EMPLEADOS SIN DUPLICAR
        // ============================================================
        private void CargarEmpleados()
        {
            // ✔️ Limpia el GridView ANTES de cargar datos
            grid_empleados.DataSource = null;
            grid_empleados.DataBind();

            using (SqlConnection cn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("spEmpleadoListar", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                cn.Open();
                da.Fill(dt);

                // ✔️ Cargar datos reales sin duplicar
                grid_empleados.DataSource = dt;
                grid_empleados.DataBind();
            }
        }

        // ============================================================
        // 🚀 OBTENER ID SELECCIONADO DEL GRIDVIEW
        // ============================================================
        protected void grid_empleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ✔️ Obtiene el ID (columna 1) de la fila seleccionada
            string id = grid_empleados.SelectedRow.Cells[1].Text;

            // ✔️ Guardamos ID en sesión para usar en actualizar/borrar
            Session["IDEmpleado"] = id;
        }

        // ============================================================
        // 🚀 CREAR EMPLEADO
        // ============================================================
        protected void btn_crear_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("spEmpleadoInsertar", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombres", txt_nombres.Text);
                cmd.Parameters.AddWithValue("@Apellidos", txt_apellidos.Text);
                cmd.Parameters.AddWithValue("@Direccion", txt_direccion.Text);
                cmd.Parameters.AddWithValue("@Telefono", txt_telefono.Text);
                cmd.Parameters.AddWithValue("@FechaNacimiento", txt_fn.Text);
                cmd.Parameters.AddWithValue("@Puesto", txt_puesto.Text);

                cn.Open();
                cmd.ExecuteNonQuery();
            }

            LimpiarFormulario();
            CargarEmpleados();
        }

        // ============================================================
        // 🚀 ACTUALIZAR EMPLEADO (usando Session["IDEmpleado"])
        // ============================================================
        protected void btn_actualizar_Click(object sender, EventArgs e)
        {
            if (Session["IDEmpleado"] == null)
                return; // ❌ No hay ID seleccionado

            using (SqlConnection cn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("spEmpleadoActualizar", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", Session["IDEmpleado"]);
                cmd.Parameters.AddWithValue("@Nombres", txt_nombres.Text);
                cmd.Parameters.AddWithValue("@Apellidos", txt_apellidos.Text);
                cmd.Parameters.AddWithValue("@Direccion", txt_direccion.Text);
                cmd.Parameters.AddWithValue("@Telefono", txt_telefono.Text);
                cmd.Parameters.AddWithValue("@FechaNacimiento", txt_fn.Text);
                cmd.Parameters.AddWithValue("@Puesto", txt_puesto.Text);

                cn.Open();
                cmd.ExecuteNonQuery();
            }

            LimpiarFormulario();
            CargarEmpleados();
        }

        // ============================================================
        // 🚀 BORRAR EMPLEADO (soft delete o delete real)
        // ============================================================
        protected void btn_borrar_Click(object sender, EventArgs e)
        {
            if (Session["IDEmpleado"] == null)
                return; // ❌ No hay ID seleccionado

            using (SqlConnection cn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("spEmpleadoEliminar", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Session["IDEmpleado"]);

                cn.Open();
                cmd.ExecuteNonQuery();
            }

            LimpiarFormulario();
            CargarEmpleados();
        }

        // ============================================================
        // 🚀 LIMPIAR FORMULARIO
        // ============================================================
        private void LimpiarFormulario()
        {
            txt_nombres.Text = "";
            txt_apellidos.Text = "";
            txt_direccion.Text = "";
            txt_telefono.Text = "";
            txt_fn.Text = "";
            txt_puesto.Text = "";

            // ✔️ Limpia el ID seleccionado para evitar errores
            Session["IDEmpleado"] = null;
        }
    }
}
