using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using CapaEntidad;
using System.Data;

namespace CapaDatos
{
    public class Conexion
    {
        //cadena de conexion a la base
        public SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-VRFB2RU;Initial Catalog=SistemaFerreteria;Integrated Security=True");

        public SqlConnection OpenConexion()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();

            }
            return conexion;
        }

        public SqlConnection closeConexion()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
            return conexion;
        }






    }
}
