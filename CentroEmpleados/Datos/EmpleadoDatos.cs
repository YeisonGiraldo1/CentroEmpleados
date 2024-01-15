using CentroEmpleados.Models;
using System.Data.SqlClient;
using System.Data;

namespace CentroEmpleados.Datos
{
    public class EmpleadoDatos
    {
        public List<EmpleadoModel> Listar()
        {

            var oLista = new List<EmpleadoModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new EmpleadoModel()
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Nombres = dr["Nombres"].ToString(),
                            Apellidos = dr["Apellidos"].ToString(),
                            Documento = Convert.ToInt32(dr["Documento"]),
                            Telefono = Convert.ToInt32(dr["Telefono"]),
                            Correo = dr["Correo"].ToString(),


                        });

                    }
                }

            }

            return oLista;
        }





        public EmpleadoModel Obtener(int Id)
        {

            var oEmpleado = new EmpleadoModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oEmpleado.Id = Convert.ToInt32(dr["Id"]);
                        oEmpleado.Nombres = dr["Nombres"].ToString();
                        oEmpleado.Apellidos = dr["Apellidos"].ToString();
                        oEmpleado.Documento = Convert.ToInt32(dr["Documento"]);
                        oEmpleado.Telefono = Convert.ToInt32(dr["Telefono"]);
                        oEmpleado.Correo = dr["Correo"].ToString();

                    }
                }

            }

            return oEmpleado;
        }






        public bool Guardar(EmpleadoModel oempleado)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("Nombres", oempleado.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", oempleado.Apellidos);
                    cmd.Parameters.AddWithValue("Documento", oempleado.Documento);
                    cmd.Parameters.AddWithValue("Telefono", oempleado.Telefono);
                    cmd.Parameters.AddWithValue("Correo", oempleado.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }


            return rpta;
        }






        public bool Editar(EmpleadoModel oempleado)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("Id", oempleado.Id);
                    cmd.Parameters.AddWithValue("Nombres", oempleado.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", oempleado.Apellidos);
                    cmd.Parameters.AddWithValue("Documento", oempleado.Documento);
                    cmd.Parameters.AddWithValue("Telefono", oempleado.Telefono);
                    cmd.Parameters.AddWithValue("Correo", oempleado.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }


            return rpta;
        }






        public bool Eliminar(int Id)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("Id", Id);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }


            return rpta;
        }




    }
}

