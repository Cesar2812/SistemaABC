using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Producto
    {
        public int id_Producto { get; set; }
        public string Codigo { get; set; }
        public string Nombre_Producto { get; set;}
        
        public string Descipcion {  get; set; }
        public int Stock {  get; set; }
        public decimal PrecioDeCompra {  get; set; }

        public decimal PrecioDeVenta { get; set; }  


    }
}
