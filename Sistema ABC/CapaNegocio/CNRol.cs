using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CNRol
    {
        CPDRol obj_rol = new CPDRol();
        //permisos de roles
        public List<Rol> Listar()
        {
            return obj_rol.Listar();
        }
    }
}
