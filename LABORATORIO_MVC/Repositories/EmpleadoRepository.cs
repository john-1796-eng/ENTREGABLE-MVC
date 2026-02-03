using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using LABORATORIO_MVC.Models;

namespace LABORATORIO_MVC.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly string _connectionString;

        public EmpleadoRepository()
        {
            _connectionString = System.Configuration.ConfigurationManager
                .ConnectionStrings["MiConexion"]
                .ConnectionString;
        }

        // ============================================================
        // LISTAR EMPLEADOS (spEmpleadoListar)
        // ============================================================
        public IEnumerable<Empleado> ObtenerTodos()
        {
            var lista = new List<Empleado>();

            using (SqlConnection cn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("spEmpleadoListar", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Empleado
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Nombres = dr["Nombres"].ToString(),
                        Apellidos = dr["Apellidos"].ToString(),
                        Direccion = dr["Direccion"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]),
                        Puesto = dr["Puesto"].ToString(),
                    });
                }
            }

            return lista;
        }

        // ============================================================
        // OBTENER EMPLEADO POR ID (spEmpleadoObtener)
        // ============================================================
        public Empleado ObtenerPorId(int id)
        {
            Empleado empleado = null;

            using (SqlConnection cn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("spEmpleadoObtener", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    empleado = new Empleado
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Nombres = dr["Nombres"].ToString(),
                        Apellidos = dr["Apellidos"].ToString(),
                        Direccion = dr["Direccion"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]),
                        Puesto = dr["Puesto"].ToString(),
                    };
                }
            }

            return empleado;
        }

        // ============================================================
        // INSERTAR EMPLEADO (spEmpleadoInsertar)
        // ============================================================
        public bool Insertar(Empleado empleado)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("spEmpleadoInsertar", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombres", empleado.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", empleado.Apellidos);
                cmd.Parameters.AddWithValue("@Direccion", empleado.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", empleado.Telefono);
                cmd.Parameters.AddWithValue("@FechaNacimiento", empleado.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Puesto", empleado.Puesto);

                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ============================================================
        // ACTUALIZAR EMPLEADO (spEmpleadoActualizar)
        // ============================================================
        public bool Actualizar(Empleado empleado)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("spEmpleadoActualizar", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", empleado.Id);
                cmd.Parameters.AddWithValue("@Nombres", empleado.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", empleado.Apellidos);
                cmd.Parameters.AddWithValue("@Direccion", empleado.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", empleado.Telefono);
                cmd.Parameters.AddWithValue("@FechaNacimiento", empleado.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Puesto", empleado.Puesto);

                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ============================================================
        // ELIMINAR EMPLEADO (spEmpleadoEliminar)
        // ============================================================
        public bool Eliminar(int id)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("spEmpleadoEliminar", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
