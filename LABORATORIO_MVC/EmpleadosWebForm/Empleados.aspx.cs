
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LABORATORIO_MVC.EmpleadosWebForm
{


    public partial class Empleados : System.Web.UI.Page
    {
        //  Web.config "Mi Conexion" apuntando a (localdb)\MSSQLLocalDB y la BD ProyectoWeb

        string conexion = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEmpleados();
            }
        }

        private void CargarEmpleados()
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("spEmpleadoListar", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                cn.Open();
                da.Fill(dt);

                grid_empleados.DataSource = dt;
                grid_empleados.DataBind();
            }
        }

        // ============================================================
        //          SELECCIONAR Y RELLENAR FORMULARIO 
        // ============================================================
        protected void grid_empleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = grid_empleados.SelectedRow.Cells[1].Text;
            Session["IDEmpleado"] = id;

            txt_nombres.Text = HttpUtility.HtmlDecode(grid_empleados.SelectedRow.Cells[2].Text);
            txt_apellidos.Text = HttpUtility.HtmlDecode(grid_empleados.SelectedRow.Cells[3].Text);
            txt_direccion.Text = HttpUtility.HtmlDecode(grid_empleados.SelectedRow.Cells[4].Text);
            txt_telefono.Text = HttpUtility.HtmlDecode(grid_empleados.SelectedRow.Cells[5].Text);

            
            string fechaTexto = HttpUtility.HtmlDecode(grid_empleados.SelectedRow.Cells[6].Text);
            DateTime fechaConvertida;

            if (DateTime.TryParse(fechaTexto, out fechaConvertida))
            {
                // Esto lo convierte al formato que el input HTML5 entiende (AAAA-MM-DD)
                txt_fn.Text = fechaConvertida.ToString("yyyy-MM-dd");
            }
            else
            {
                txt_fn.Text = fechaTexto; // 
            }
            // --------------------------------

            txt_puesto.Text = HttpUtility.HtmlDecode(grid_empleados.SelectedRow.Cells[7].Text);
        }

       


        private bool ValidarCamposTexto()
        {
            if (string.IsNullOrWhiteSpace(txt_nombres.Text) || string.IsNullOrWhiteSpace(txt_apellidos.Text) ||
                string.IsNullOrWhiteSpace(txt_direccion.Text) || string.IsNullOrWhiteSpace(txt_telefono.Text) ||
                string.IsNullOrWhiteSpace(txt_fn.Text) || string.IsNullOrWhiteSpace(txt_puesto.Text))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Tiene Campos Sin Diligenciar.');", true);
                return false;
            }
            return true;
        }
        protected void btn_crear_Click(object sender, EventArgs e)
        {
            // Antes de insertar, verificamos que los TXT no estén vacíos


            if (ValidarCamposTexto())
            {
                EjecutarComando("spEmpleadoInsertar", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Datos Almacenados Correctamente');", true);

                LimpiarFormulario();
                CargarEmpleados();
            }
        }

        protected void btn_actualizar_Click(object sender, EventArgs e)
        {
            if (Session["IDEmpleado"] != null && ValidarCamposTexto())
            {
                EjecutarComando("spEmpleadoActualizar", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Datos Actualizados Exitosamente');", true);

                LimpiarFormulario();
                CargarEmpleados();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Error: Seleccione un empleado de la tabla primero.');", true);
            }
        }
        protected void btn_borrar_Click(object sender, EventArgs e)
        {
            if (Session["IDEmpleado"] != null)
            {
                // Todo el proceso de borrado debe ocurrir dentro de este bloque

                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = new SqlCommand("spEmpleadoEliminar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Session["IDEmpleado"]);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Empleado Borrado Exitosamente');", true);

               
                LimpiarFormulario();
                CargarEmpleados();
            }
            else
            {
                
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Error: Seleccione un empleado de la tabla primero.');", true);
            }
        }
       

        

        // Método auxiliar para evitar repetir código en Crear y Actualizar

        private void EjecutarComando(string procedimiento, bool esActualizacion)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand(procedimiento, cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                if (esActualizacion)
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

        private void LimpiarFormulario()
        {
            txt_nombres.Text = "";
            txt_apellidos.Text = "";
            txt_direccion.Text = "";
            txt_telefono.Text = "";
            txt_fn.Text = "";
            txt_puesto.Text = "";
            Session["IDEmpleado"] = null;
        }
    }
}
