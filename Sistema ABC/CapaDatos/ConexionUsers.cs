using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CapaDatos
{
    public  class ConexionUsers
    {
        public static string cadena = ConfigurationManager.ConnectionStrings["Sistema_ABC.Properties.Settings.cn"].ToString();

    }
}
