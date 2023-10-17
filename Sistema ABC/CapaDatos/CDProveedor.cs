﻿using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace CapaDatos
{
    public  class CDProveedor
    {
        //Listar Proveedor
        public List<Proveedor> Listar()
        {
            List<Proveedor> lista = new List<Proveedor>();

            using (SqlConnection conection = new SqlConnection(ConexionUsers.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("Select id_Prov,Documento,RazonSocial,Correo,Telefono,Estado from Proveedor");
                    

                    SqlCommand terminal = new SqlCommand(query.ToString(), conection);
                    terminal.CommandType = CommandType.Text;

                    conection.Open();
                    using (SqlDataReader dr = terminal.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Proveedor()
                            {
                                id_Prov = Convert.ToInt32(dr["id_Prov"]),
                                Documento = dr["Documento"].ToString(),
                                RazonSocial = dr["RazonSocial"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Proveedor>();
                }
            }
            return lista;
        }

        //Registrar Proveedor
        public int Registrar(Proveedor obj, out string Mensaje)
        {
            int idProveedorGenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConexionUsers.cadena))
                {
                    SqlCommand terminal = new SqlCommand("Ingresar_Proveedor", conection);
                    terminal.Parameters.AddWithValue("@Documento", obj.Documento);
                    terminal.Parameters.AddWithValue("@RazonSocial", obj.RazonSocial);
                    terminal.Parameters.AddWithValue("@Correo", obj.Correo);
                    terminal.Parameters.AddWithValue("@Telefono", obj.Telefono);
                    terminal.Parameters.AddWithValue("@Estado", obj.Estado);
                    terminal.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    terminal.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    terminal.CommandType = CommandType.StoredProcedure;
                    conection.Open();
                    terminal.ExecuteNonQuery();

                    idProveedorGenerado = Convert.ToInt32(terminal.Parameters["Resultado"].Value);
                    Mensaje = terminal.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                idProveedorGenerado = 0;
                Mensaje = ex.Message;

            }
            return idProveedorGenerado;
        }

        //Editar Proveedor
        public bool Editar(Proveedor obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConexionUsers.cadena))
                {
                    SqlCommand terminal = new SqlCommand("Editar_Proveedor", conection);
                    terminal.Parameters.AddWithValue("@Id_Proveedor", obj.id_Prov);
                    terminal.Parameters.AddWithValue("@Documento", obj.Documento);
                    terminal.Parameters.AddWithValue("@RazonSocial", obj.RazonSocial);
                    terminal.Parameters.AddWithValue("@Correo", obj.Correo);
                    terminal.Parameters.AddWithValue("@Telefono", obj.Telefono);
                    terminal.Parameters.AddWithValue("@Estado", obj.Estado);
                    terminal.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    terminal.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    terminal.CommandType = CommandType.StoredProcedure;
                    conection.Open();
                    terminal.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(terminal.Parameters["Resultado"].Value);
                    Mensaje = terminal.Parameters["Mensaje"].Value.ToString();


                }

            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;

            }
            return respuesta;
        }


        //Eliminar Proveedor
        public bool Eliminar(Proveedor obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConexionUsers.cadena))
                {
                    SqlCommand terminal = new SqlCommand("Eliminar_Proveedor", conection);
                    terminal.Parameters.AddWithValue("@Id_Proveedor", obj.id_Prov);
                    terminal.Parameters.Add("@Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    terminal.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    terminal.CommandType = CommandType.StoredProcedure;
                    conection.Open();
                    terminal.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(terminal.Parameters["@Resultado"].Value);
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
