using CRUDCLIENTES.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUDCLIENTES.BDCliente
{
    public class ClienteDatos
    {
        /*
         Este metodo es el encagardo devolverme toda la info de la BD.
         */
        public List<ClienteModel> Listar()
        {
            var listaClientes = new List<ClienteModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("tb_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listaClientes.Add(new ClienteModel()
                        {
                            IdCliente = Convert.ToInt32(reader["IdCliente"]),
                            Nombre = reader["Nombre"].ToString(),
                            Apellido = reader["Apellido"].ToString(),
                            DPI = reader["DPI"].ToString(),
                            NIT = reader["NIT"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            Correo = reader["Correo"].ToString()

                        });
                    }

                }
            }

            return listaClientes;
        }

        /*
         Este metodo es el encagardo devolverme la info determinado ID de la BD.
         */
        public ClienteModel Obtener(int idCliente)
        {
            var objectCliente = new ClienteModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("tb_Obtener", conexion);
                cmd.Parameters.AddWithValue("IdCliente", idCliente);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        objectCliente.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                        objectCliente.Nombre = reader["Nombre"].ToString();
                        objectCliente.Apellido = reader["Apellido"].ToString();
                        objectCliente.DPI = reader["DPI"].ToString();
                        objectCliente.NIT = reader["NIT"].ToString();
                        objectCliente.Telefono = reader["Telefono"].ToString();
                        objectCliente.Correo = reader["Correo"].ToString();
                    }
                }

            }
            return objectCliente;
        }

        /*
         Este metodo es el encagardo guardar nueva informacion en la BD.
         */
        public bool Guardar(ClienteModel clienteModel)
        {
            bool resultado;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("tb_Guardar", conexion);
                    cmd.Parameters.AddWithValue("Nombre", clienteModel.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", clienteModel.Apellido);
                    cmd.Parameters.AddWithValue("DPI", clienteModel.DPI);
                    cmd.Parameters.AddWithValue("NIT", clienteModel.NIT);
                    cmd.Parameters.AddWithValue("Telefono", clienteModel.Telefono);
                    cmd.Parameters.AddWithValue("Correo", clienteModel.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                resultado = true;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                resultado = false;
            }

            return resultado;
        }

        /*
         Este metodo es el encagardo de actualizar la info de la BD.
         */
        public bool Editar(ClienteModel clienteModel)
        {
            bool resultado;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("tb_Editar", conexion);
                    cmd.Parameters.AddWithValue("IdCliente", clienteModel.IdCliente);
                    cmd.Parameters.AddWithValue("Nombre", clienteModel.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", clienteModel.Apellido);
                    cmd.Parameters.AddWithValue("DPI", clienteModel.DPI);
                    cmd.Parameters.AddWithValue("NIT", clienteModel.NIT);
                    cmd.Parameters.AddWithValue("Telefono", clienteModel.Telefono);
                    cmd.Parameters.AddWithValue("Correo", clienteModel.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                resultado = true;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                resultado = false;
            }

            return resultado;
        }

        /*
         Este metodo es el encagardo de eliminar info de un id en la BD.
         */
        public bool Eliminar(int idCliente)
        {
            bool resultado;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("tb_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("IdCliente", idCliente);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                resultado = true;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                resultado = false;
            }

            return resultado;
        }






    }

}
