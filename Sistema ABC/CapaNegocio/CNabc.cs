using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public  class CNabc
    {

        CapaDatos.CDPMostrarTablaABC abc = new CapaDatos.CDPMostrarTablaABC();
        //Tabla de Porcentajes
        public DataTable Listar_Porce()
        {
            return abc.MostrarTablaABC();
        }

        //Tabala del Producto A
        public DataTable ListarA()
        {
            return abc.MostrarA();
        }
        //Tabla del Prducto B
        public DataTable ListarB()
        {
            return abc.MostrarB();
        }
        //tabla del Producto C
        public DataTable ListarC()
        {
            return abc.MostrarC();
        }

        //Listar Datos en el chart 
        public DataTable ListarChart()
        {

            return abc.MostrarDatosChart();
        }

        //Listar datos en el chart de Rangos

        public DataTable ListarChartRangos()
        {

            return abc.MostarChartABC();
        }
    }
}
