using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Usuarios
    {
        public int id_Usuario { get; set; }
        public string Nombre_User { get; set; }
        public string account { get; set; }
        public string pass { get; set; }
        public Rol objRolU { get; set; }
        public bool Estado { get; set; }
    }
}
