using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
     public class Compra
     {
        public int id_Compra {  get; set; }
        public Usuarios od_usuario { get; set; }
        public Proveedor od_Proveedor {  get; set; }
        public string TipoDeDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public decimal MontoTotal {  get; set; }
        public List<DetalleCompra> obDetalle {  get; set; }
        public string FechaCreacion {  get; set; }

     }
}
