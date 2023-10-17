using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;

namespace Sistema_ABC.Vistas
{
    public partial class DatosNegocio : Form
    {
        public DatosNegocio()
        {
            InitializeComponent();
        }

        public Image byteToImage(byte[]imagebytes)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(imagebytes, 0, imagebytes.Length);
            Image imagen = new Bitmap(ms);

            return imagen;
        }

        private void DatosNegocio_Load(object sender, EventArgs e)
        {
            bool obtenido = true;
            byte[] byteImagen = new CNNegocio().obtenerLogo(out obtenido);
            if (obtenido)
            {
                pictureBoxLogo.Image = byteToImage(byteImagen);
            }
            Negocio datos = new CNNegocio().obtenerdatos();
            txtNombre.Text = datos.Nombre;
            txtRUC.Text = datos.RUC;
            txtDirecccion.Text = datos.Direccion;
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = "Files|*.jpg;*.jpeg;*.png";

            if (openfile.ShowDialog() == DialogResult.OK)
            {
                byte[] byteImage=File.ReadAllBytes(openfile.FileName);
                bool respuesta = new CNNegocio().ActualizarLogo(byteImage,out Mensaje);

                if(respuesta)
                {
                    pictureBoxLogo.Image= byteToImage(byteImage);
                }
                else
                {
                    MessageBox.Show(Mensaje,"Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string message=string.Empty;
            Negocio objNegocio = new Negocio()
            {
                Nombre = txtNombre.Text,
                RUC = txtRUC.Text,
                Direccion = txtDirecccion.Text
            };
            bool Respuest = new CNNegocio().GuardarDatos(objNegocio, out message);

            string ca = "";
            if (Respuest)
            {
                MessageBox.Show("Los cambios fueron guardados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("No se pudieron guardar los datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;

            Negocio obj = new Negocio()
            {
                Nombre=txtNombre.Text,
                RUC=txtRUC.Text,
                Direccion=txtDirecccion.Text
            };

            bool resp=new CNNegocio().GuardarDatos(obj, out Mensaje);
            
            
                if (resp==false)
                {
                 MessageBox.Show("Los Datos no se guardaron", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 
                }
                else
                {
                  MessageBox.Show("Los Datos se guardadron correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

        }
    }
}
