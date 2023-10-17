using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;

namespace CapaDatos
{
    public  class CD_ReportesCompras
    {
        public List<ReporteCompra> Listar(string fechaCreacion,string fechaFin,int idproveedor)
        {
            List<ReporteCompra> lista = new List<ReporteCompra>();

            using (SqlConnection conection = new SqlConnection(ConexionUsers.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    SqlCommand terminal = new SqlCommand("ReporteCompras", conection);
                    terminal.Parameters.AddWithValue("fechaCreacion", fechaCreacion);
                    terminal.Parameters.AddWithValue("fechaFin", fechaFin);
                    terminal.Parameters.AddWithValue("idproveedor", idproveedor);
                    terminal.CommandType = CommandType.StoredProcedure;
                    

                    conection.Open();
                    using (SqlDataReader dr = terminal.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteCompra()
                            {
                                FechaCreacion = dr["fechaCreacion"].ToString(),
                                TipoDocumento = dr["TipoDeDocumento"].ToString(),
                                NumeroDcoumento = dr["NumeroDocumento"].ToString(),
                                MontoTotal = dr["MontoTotal"].ToString(),
                                UsuarioRegistro =dr["UsuarioRegistro"].ToString(),
                                DocumentoProveedor = dr["DcocumentoProveedor"].ToString(),
                                RazonSocial = dr["RazonSocial"].ToString(),
                                CodigoProducto = dr["CodigoProducto"].ToString(),
                                NombreProduto = dr["NombreProducto"].ToString(),
                                Marca = dr["Marca"].ToString(),
                                Categoria = dr["Categoria"].ToString(),
                                PrecioDeCompra = dr["PrecioDeCompra"].ToString(),
                                PrecioDeVenta = dr["PrecioDeVenta"].ToString(),
                                Cantidad = dr["Cantidad"].ToString(),
                                SubTotal = dr["Montototal"].ToString()



                            });
                        }
                    }


                }
                catch (Exception ex)
                {
                    lista = new List<ReporteCompra>();

                }
            }

            return lista;

        }

    }
}
