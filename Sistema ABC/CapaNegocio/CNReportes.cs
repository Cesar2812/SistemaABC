using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CNReportes
    {
       private CD_ReportesCompras objReporte=new CD_ReportesCompras();

        public List<ReporteCompra>Compra(string fechaCreacion,string fechaFin,int idproveedor)
        {
            return objReporte.Listar(fechaCreacion,fechaFin,idproveedor);   
        }

    }
}
