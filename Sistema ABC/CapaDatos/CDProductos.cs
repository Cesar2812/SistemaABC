using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Collections;

namespace CapaDatos
{
    public class CDProductos
    {
        public Conexion conection = new Conexion();//cadena de conexion a la base

        SqlCommand cmd = new SqlCommand();
        SqlDataReader leerfilas;


        //metodo para almacenar los productos
        public void InsertarProducto(string Codigo, string Nombre_Producto, int id_marca, int id_Categ, string Descripcion)
        {
            try
            {
                cmd.Connection = conection.OpenConexion();
                cmd.CommandText = "InsertarProductos";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", Codigo);
                cmd.Parameters.AddWithValue("@NombreProd", Nombre_Producto);
                cmd.Parameters.AddWithValue("@idMarca ", id_marca);
                cmd.Parameters.AddWithValue("@idCategoria ", id_Categ);
                cmd.Parameters.AddWithValue("@descripcion", Descripcion);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                conection.closeConexion();

            }
            catch
            {

            }
        }
        //metodo para mostrar los Productos en el Grid
        public DataTable ListarProductos()
        {

            DataTable table = new DataTable();
            cmd.Connection = conection.OpenConexion();
            cmd.CommandText = "Mostrar_Productos";
            cmd.CommandType = CommandType.StoredProcedure;
            leerfilas = cmd.ExecuteReader();
            table.Load(leerfilas);
            leerfilas.Close();
            conection.closeConexion();

            return table;

        }
        //metodo para editar productos
        public void Editar(int id_Producto, string Codigo, string Nombre_Producto, int id_marca, int id_Categ, string Descripcion)
        {
            try
            {
                cmd.Connection = conection.OpenConexion();
                cmd.CommandText = "update Productos set Codigo='" + Codigo + "',Nombre_Producto='" + Nombre_Producto + "',id_marca='" + id_marca + "',id_categ='" + id_Categ + "',Descripcion='" + Descripcion +"' where id_Producto=" + id_Producto;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                conection.closeConexion();

            }
            catch
            {

            }
        }

        //metodo para eliminar
        public void eliminar(int idProd)
        {
            cmd.Connection = conection.OpenConexion();
            cmd.CommandText = "delete Productos where id_Producto=" + idProd;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            conection.closeConexion();
        }

        //para mostrar productos en la tabla modal
        public DataTable mostrarProductosModal()
        {
            DataTable tablemodal = new DataTable();
            cmd.Connection = conection.OpenConexion();
            cmd.CommandText = "Mostrar_modalProd";
            cmd.CommandType = CommandType.StoredProcedure;
            leerfilas = cmd.ExecuteReader();
            tablemodal.Load(leerfilas);
            leerfilas.Close();
            conection.closeConexion();
            return tablemodal;
        }

    }
}
