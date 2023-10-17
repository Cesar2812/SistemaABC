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
    public class CDPMostrarTablaABC
    {
        Conexion conec = new Conexion();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader leerfilas;

        //Tabla de los porcentajes
        public DataTable MostrarTablaABC()
        {
            DataTable table = new DataTable();
            cmd.Connection = conec.OpenConexion();
            cmd.CommandText = "Mostrar_Porcenta";
            cmd.CommandType = CommandType.StoredProcedure;
            leerfilas = cmd.ExecuteReader();
            table.Load(leerfilas);
            leerfilas.Close();
            conec.closeConexion();
            return table;
        }

        //Tabla del Prodcuto A
        public DataTable MostrarA()
        {
            DataTable ta = new DataTable();
            cmd.Connection = conec.OpenConexion();
            cmd.CommandText = "MostrarProductoA";
            cmd.CommandType = CommandType.StoredProcedure;
            leerfilas = cmd.ExecuteReader();
            ta.Load(leerfilas);
            leerfilas.Close();
            conec.closeConexion();
            return ta;
        }

        //Tabla del Producto B
        public DataTable MostrarB()
        {
            DataTable tb = new DataTable();
            cmd.Connection = conec.OpenConexion();
            cmd.CommandText = "MostrarProductoB";
            cmd.CommandType = CommandType.StoredProcedure;
            leerfilas = cmd.ExecuteReader();
            tb.Load(leerfilas);
            leerfilas.Close();
            conec.closeConexion();
            return tb;

        }

        //Tabla del Producto C
        public DataTable MostrarC()
        {
            DataTable tc = new DataTable();
            cmd.Connection = conec.OpenConexion();
            cmd.CommandText = "MostrarProductoC";
            cmd.CommandType = CommandType.StoredProcedure;
            leerfilas = cmd.ExecuteReader();
            tc.Load(leerfilas);
            leerfilas.Close();
            conec.closeConexion();
            return tc;
        }

        //tabla del chart
        public DataTable MostrarDatosChart()
        {
            DataTable d = new DataTable();
            cmd.Connection = conec.OpenConexion();
            cmd.CommandText = "Ingresar_char";
            cmd.CommandType = CommandType.StoredProcedure;
            leerfilas = cmd.ExecuteReader();
            d.Load(leerfilas);
            leerfilas.Close();
            conec.closeConexion();

            return d;
        }

        //tabla del shart de rangos del ABC
        public DataTable MostarChartABC()
        {
            DataTable abc = new DataTable();

            cmd.Connection = conec.OpenConexion();
            cmd.CommandText = "Mostrar_Rangos";
            cmd.CommandType = CommandType.StoredProcedure;
            leerfilas = cmd.ExecuteReader();
            abc.Load(leerfilas);
            leerfilas.Close();
            conec.closeConexion();
            return abc;
        }


    }
}
