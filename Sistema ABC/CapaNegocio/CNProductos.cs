using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
     public  class CNProductos
     {
        CapaDatos.CDProductos cProductos = new CapaDatos.CDProductos();
        //metodo para insertar productos proveniente de la capa daatos
        public void Añadir_Productos(string Codigo, string Nombre_Producto, int id_marca, int id_Categ, string Descripcion)
        {
            cProductos.InsertarProducto(Codigo, Nombre_Producto, id_marca, id_Categ, Descripcion);
        }

        //metodo de mostrarProductos proveniente de la Capa datos
        public DataTable Mostrar_Productos()
        {
            return cProductos.ListarProductos();
        }

        //metodo de editar productos proveniente de la capa de datos

        public void Editar_Productos(int id_Producto, string Codigo, string Nombre_Producto, int id_marca, int id_Categ, string Descripcion)
        {
            cProductos.Editar(id_Producto, Codigo, Nombre_Producto, id_marca, id_Categ, Descripcion);
        }
        //metodo para eliminar productos
        public void Eliminar_Productos(int id)
        {
            cProductos.eliminar(id);

        }

        ///mostrar Productos en el griv modal 
        public DataTable prod_modal()
        {
            return cProductos.mostrarProductosModal();
        }

     }
}
