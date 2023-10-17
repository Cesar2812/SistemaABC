using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public  class CNProveedor
    {
        CDProveedor obj_prov = new CDProveedor(); 
        public List<Proveedor> Listar()
        {
            return obj_prov.Listar();
        }
        public int Registrar(Proveedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el Documento del Proveedor\n";

            }
            if (obj.RazonSocial == "")
            {
                Mensaje += "Es necesaria la Razon social del Proveedor\n";
            }
            if (obj.Correo == "")
            {
                Mensaje += "Es necesario el correo  del Proveedor\n";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return obj_prov.Registrar(obj, out Mensaje);

            }
        }
        public bool editar(Proveedor obj, out String Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el Documento del Proveedor\n";

            }
            if (obj.RazonSocial == "")
            {
                Mensaje += "Es necesaria la Razon social del Proveedor\n";
            }
            if (obj.Correo == "")
            {
                Mensaje += "Es necesario el correo  del Proveedor\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return obj_prov.Editar(obj, out Mensaje);

            }
        }
        public bool eliminar(Proveedor obj, out String Mensaje)
        {
            return obj_prov.Eliminar(obj, out Mensaje);
        }
    }
}
