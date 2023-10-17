using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class CNPermisos
    {
         CDPermisos obj_permisos=new CDPermisos();
        //permisos de roles
        public List<Permisos> Listar(int id_user)
        {
            return obj_permisos.Listar(id_user);
        }
    }
}
