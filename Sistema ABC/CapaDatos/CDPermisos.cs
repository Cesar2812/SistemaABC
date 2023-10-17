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
    public class CDPermisos
    {
        public List<Permisos> Listar(int idUsuario)
        {
            List<Permisos> lista = new List<Permisos>();

            using (SqlConnection conection = new SqlConnection(ConexionUsers.cadena))
            {
                try
                {
                    StringBuilder consulta = new StringBuilder();
                    consulta.AppendLine("select p.idRol,p.Nombre_Menu from Permisos p");
                    consulta.AppendLine("inner join Rol r on r.id_Rol=p.idRol");
                    consulta.AppendLine("inner join Usuario u on u.id_Rol=r.id_Rol");
                    consulta.AppendLine("where u.id_Usuario=@idUsuario");

                    SqlCommand terminal = new SqlCommand(consulta.ToString(), conection);
                    terminal.Parameters.AddWithValue("@idUsuario", idUsuario);
                    terminal.CommandType = CommandType.Text;

                    conection.Open();

                    using (SqlDataReader dr = terminal.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Permisos()
                            {
                                objRol = new Rol() { id_Rol = Convert.ToInt32(dr["idRol"]) },
                                Nombre_Menu = dr["Nombre_Menu"].ToString(),

                            });
                        }
                    }


                }
                catch (Exception ex)
                {
                    lista = new List<Permisos>();

                }
            }

            return lista;

        }
    }
}
