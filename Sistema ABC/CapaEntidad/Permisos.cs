using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Permisos
    {
        public int id_Permiso { get; set; }
        public Rol objRol { get; set; }
        public string Nombre_Menu { get; set; }
        public string fechacreacion { get; set; }

    }
}
