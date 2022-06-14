using CRUDCLIENTES.Models;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Security.Cryptography;

namespace CRUDCLIENTES.BDCliente
{
    public class UsuarioDatos
    {
        public string mensaje;

        public bool RegistrarUsuario(UsuarioModel usuarioModel)
        {
            bool user_Registrado;

            if (usuarioModel.Clave == usuarioModel.confirmarClave)
            {
                usuarioModel.Clave = ConvertirSha256(usuarioModel.Clave);
            }
            else
            {
                return false;
            }

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    SqlCommand cmd = new SqlCommand("sql_RegistrarUsuario", conexion);
                    cmd.Parameters.AddWithValue("Correo", usuarioModel.Correo);
                    cmd.Parameters.AddWithValue("Clave", usuarioModel.Clave);
                    cmd.Parameters.Add("Registrado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    cmd.ExecuteNonQuery();

                    user_Registrado = Convert.ToBoolean(cmd.Parameters["Registrado"].Value);
                    mensaje = (cmd.Parameters["Mensaje"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                user_Registrado = false;
            }

            return user_Registrado;
        }

        public string devuelveMensaje()
        {
            return mensaje;
        }


        public int LoginUsuario(UsuarioModel usuarioModel)
        {

            int acceso = 0;
            usuarioModel.Clave = ConvertirSha256(usuarioModel.Clave);

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    SqlCommand cmd = new SqlCommand("sql_ValidarUsuario", conexion);
                    cmd.Parameters.AddWithValue("Correo", usuarioModel.Correo);
                    cmd.Parameters.AddWithValue("Clave", usuarioModel.Clave);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conexion.Open();


                    acceso = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                }
            }
            catch (Exception ex)
            {
                return acceso = 0;
            }

            return acceso;

        }



        public string ConvertirSha256(string texto)
        {
            if (texto == null)
            {
                return "";
            }


            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] resultado = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in resultado)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}
