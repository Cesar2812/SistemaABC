using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class CNCompra
    {
        private CDCompras objCompras=new CDCompras();
        public int obtenerCorrelativo()
        {
            return objCompras.obtnerCorrerlativo();
        }
        public bool Registrar(Compra obj,DataTable DetalleCompra, out string Mensaje)
        {
            return objCompras.Registrar(obj, DetalleCompra, out Mensaje);  
        }

        public Compra obtnerCompra(string numero)
        {
            Compra oCompra = objCompras.ObtnerCompra(numero);

            if(oCompra.id_Compra != 0)
            {
                List<DetalleCompra> oDetalle = objCompras.obtenerDetail(oCompra.id_Compra);
                
                oCompra.obDetalle= oDetalle;
            }
            return oCompra; 
        }




    }
}
