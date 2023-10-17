using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using CapaEntidad;

namespace CapaDatos
{
    public class CDPUsuarios
    {
        public List<Usuarios> Listar()
        {
            List<Usuarios> lista = new List<Usuarios>();

            using (SqlConnection conection = new SqlConnection(ConexionUsers.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("Select u.id_Usuario,u.Nombre_User,u.account,u.pass,u.Estado,r.id_Rol,r.Descripcion from Usuario u");
                    query.AppendLine("inner join Rol r on r.id_Rol = u.id_Rol");

                    SqlCommand terminal = new SqlCommand(query.ToString(), conection);
                    terminal.CommandType = CommandType.Text;

                    conection.Open();
                    using (SqlDataReader dr = terminal.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Usuarios()
                            {
                                id_Usuario = Convert.ToInt32(dr["id_Usuario"]),
                                Nombre_User = dr["Nombre_User"].ToString(),
                                account = dr["account"].ToString(),
                                pass = dr["pass"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                objRolU = new Rol() { id_Rol = Convert.ToInt32(dr["id_Rol"]), Descripcion = dr["Descripcion"].ToString() }


                            });
                        }
                    }


                }
                catch (Exception ex)
                {
                    lista = new List<Usuarios>();

                }
            }

            return lista;

        }
        public int Registrar(Usuarios obj, out string Mensaje)
        {
            int idusuarioGenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConexionUsers.cadena))
                {
                    SqlCommand terminal = new SqlCommand("Insertar_Usuarios", conection);
                    terminal.Parameters.AddWithValue("@Nombre", obj.Nombre_User);
                    terminal.Parameters.AddWithValue("@Usuario", obj.account);
                    terminal.Parameters.AddWithValue("@pass", obj.pass);
                    terminal.Parameters.AddWithValue("@Estado", obj.Estado);
                    terminal.Parameters.AddWithValue("@id_Rol", obj.objRolU.id_Rol);
                    terminal.Parameters.Add("@idUsuarioResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    terminal.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    terminal.CommandType = CommandType.StoredProcedure;
                    conection.Open();
                    terminal.ExecuteNonQuery();

                    idusuarioGenerado = Convert.ToInt32(terminal.Parameters["@idUsuarioResultado"].Value);
                    Mensaje = terminal.Parameters["@Mensaje"].Value.ToString();


                }

            }
            catch (Exception ex)
            {
                idusuarioGenerado = 0;
                Mensaje = ex.Message;

            }


            return idusuarioGenerado;
        }

        public bool Editar(Usuarios obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConexionUsers.cadena))
                {
                    SqlCommand terminal = new SqlCommand("Editar_Usuarios", conection);
                    terminal.Parameters.AddWithValue("@idUsuario", obj.id_Usuario);
                    terminal.Parameters.AddWithValue("@Nombre", obj.Nombre_User);
                    terminal.Parameters.AddWithValue("@Usuario", obj.account);
                    terminal.Parameters.AddWithValue("@pass", obj.pass);
                    terminal.Parameters.AddWithValue("@Estado", obj.Estado);
                    terminal.Parameters.AddWithValue("@id_Rol", obj.objRolU.id_Rol);
                    terminal.Parameters.Add("@Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    terminal.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    terminal.CommandType = CommandType.StoredProcedure;
                    conection.Open();
                    terminal.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(terminal.Parameters["@Respuesta"].Value);
                    Mensaje = terminal.Parameters["@Mensaje"].Value.ToString();


                }

            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;

            }
            return respuesta;
        }

        public bool Eliminar(Usuarios obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConexionUsers.cadena))
                {
                    SqlCommand terminal = new SqlCommand("Eliminar_Usuarios", conection);
                    terminal.Parameters.AddWithValue("@idUsuario", obj.id_Usuario);
                    terminal.Parameters.Add("@Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    terminal.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    terminal.CommandType = CommandType.StoredProcedure;
                    conection.Open();
                    terminal.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(terminal.Parameters["@Respuesta"].Value);
                }

            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }
            return respuesta;

        }
    }
}
