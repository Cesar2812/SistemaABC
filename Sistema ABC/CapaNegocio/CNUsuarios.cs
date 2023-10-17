using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CNUsuarios
    {
        CDPUsuarios obj_users = new CDPUsuarios();
        //login
        public List<Usuarios> Listar()
        {
            return obj_users.Listar();
        }
        public int Registrar(Usuarios obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Nombre_User == "")
            {
                Mensaje += "Es necesario el Nombre del Usuario\n";

            }
            if (obj.account == "")
            {
                Mensaje += "Es necesario el Nombre de Usuario\n";
            }
            if (obj.pass == "")
            {
                Mensaje += "Es necesaria la clave del usuario\n";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return obj_users.Registrar(obj, out Mensaje);

            }
        }
        public bool editar(Usuarios obj, out String Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Nombre_User == "")
            {
                Mensaje += "Es necesario el Nombre del Usuario\n";

            }
            if (obj.account == "")
            {
                Mensaje += "Es necesario el Nombre de Usuario\n";
            }
            if (obj.pass == "")
            {
                Mensaje += "Es necesaria la clave del usuario\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return obj_users.Editar(obj, out Mensaje);

            }
        }
        public bool eliminar(Usuarios obj, out String Mensaje)
        {
            return obj_users.Eliminar(obj, out Mensaje);
        }


    }
}
