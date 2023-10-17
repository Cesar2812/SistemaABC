using CapaEntidad;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDatos
{
     public class CDCompras
     {
        public int obtnerCorrerlativo()
        {
            int idCorrelativo = 0;
            using (SqlConnection conection = new SqlConnection(ConexionUsers.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine(" select count(*)+1 from Compra");
                    SqlCommand terminal = new SqlCommand(query.ToString(), conection);
                    terminal.CommandType = CommandType.Text;
                    conection.Open();
                    
                    idCorrelativo=Convert.ToInt32(terminal.ExecuteScalar());


                }
                catch (Exception ex)
                {
                    idCorrelativo = 0;

                }
            }
            return idCorrelativo;
        }

        //Registrar la Compra
        public bool Registrar(Compra objcompra,DataTable DetalleCompra,out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            using (SqlConnection conection = new SqlConnection(ConexionUsers.cadena))
            {
                try
                {
                   
                    SqlCommand terminal = new SqlCommand("RegistrarCompraa", conection);
                    terminal.Parameters.AddWithValue("idusuario", objcompra.od_usuario.id_Usuario);
                    terminal.Parameters.AddWithValue("idproveed", objcompra.od_Proveedor.id_Prov);
                    terminal.Parameters.AddWithValue("TipoDeDocumento",objcompra.TipoDeDocumento);
                    terminal.Parameters.AddWithValue("NumeroDocumento",objcompra.NumeroDocumento);
                    terminal.Parameters.AddWithValue("MontoTotal", objcompra.MontoTotal);
                    terminal.Parameters.AddWithValue("DetalleCompra",DetalleCompra);
                    terminal.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    terminal.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    terminal.CommandType = CommandType.StoredProcedure;

                    conection.Open();

                    terminal.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(terminal.Parameters["Resultado"].Value);
                    Mensaje = terminal.Parameters["Mensaje"].Value.ToString();


                }
                catch (Exception ex)
                {
                    respuesta = false;
                    Mensaje = ex.Message;

                }
            }
            return respuesta;

        }

        public Compra ObtnerCompra(string numero)
        {
            Compra objec = new Compra();

            using (SqlConnection conection = new SqlConnection(ConexionUsers.cadena))
            {
                try
                {
                    
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("Select c.id_Compra,");
                    query.AppendLine("u.Nombre_User,");
                    query.AppendLine("pr.Documento,pr.RazonSocial,");
                    query.AppendLine("c.TipoDeDocumento,c.NumeroDocumento,c.MontoTotal,convert(char(10),c.FechaCreacion,103)[FechaCreacion]");
                    query.AppendLine("from Compra c");
                    query.AppendLine("inner join Usuario u on u.id_Usuario=c.id_usuario");
                    query.AppendLine("inner join Proveedor pr on pr.id_Prov=c.id_Proveedor");
                    query.AppendLine(" where c.NumeroDocumento=@numero");


                    SqlCommand terminal = new SqlCommand(query.ToString(), conection);
                    terminal.Parameters.AddWithValue("@numero",numero);
                    terminal.CommandType = CommandType.Text;
                   
                    conection.Open();

                    using (SqlDataReader dr = terminal.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            objec = new Compra()
                            {
                                id_Compra = Convert.ToInt32(dr["id_Compra"]),
                                od_usuario = new Usuarios() { Nombre_User = dr["Nombre_User"].ToString() },
                                od_Proveedor = new Proveedor() { Documento = dr["Documento"].ToString(), RazonSocial = dr["RazonSocial"].ToString() },
                                TipoDeDocumento = dr["TipoDeDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"].ToString()),
                                FechaCreacion = dr["FechaCreacion"].ToString()
                                
                            };
                        }
                    }
                    string v = "";

                }
                catch (Exception ex)
                {
                    objec = new Compra();

                }
            }

            return objec;
        }

        public List<DetalleCompra>obtenerDetail(int idCompra)
        {
            List<DetalleCompra> olista = new List<DetalleCompra>();
            try
            {
                using(SqlConnection Conexion =new SqlConnection(ConexionUsers.cadena))
                {
                    Conexion.Open();
                    StringBuilder consulta=new StringBuilder();
                    consulta.AppendLine(" select Nombre_Producto,DetalleCompra.PrecioDeCompra,Cantidad,Montototal");
                    consulta.AppendLine("from DetalleCompra");
                    consulta.AppendLine("inner join Productos on DetalleCompra.idProducto=Productos.id_Producto");
                    consulta.AppendLine(" where idCompra=@idCompra");

                    SqlCommand cmd = new SqlCommand(consulta.ToString(), Conexion);
                    cmd.Parameters.AddWithValue("@idCompra", idCompra);
                    cmd.CommandType=System.Data.CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            olista.Add(new DetalleCompra()
                            {
                                o_idProducto=new Producto() { Nombre_Producto = dr["Nombre_Producto"].ToString() },
                                PrecioDeCompra = Convert.ToDecimal( dr["PrecioDeCompra"].ToString()),
                                Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                                Montototal = Convert.ToDecimal(dr["Montototal"].ToString())
                            });
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                olista = new List<DetalleCompra>();
            }
            return olista;
        }
     }
}
