using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using CapaDatos;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Sistema_ABC.Vistas
{
    public partial class MDIMenu : Form
    {
        private int childFormNumber = 0;
        private static Usuarios usuarioActual;
        CapaDatos.Conexion conection = new CapaDatos.Conexion();

        public MDIMenu(Usuarios objUsuario)
        {
            InitializeComponent();
            usuarioActual = objUsuario;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MDIMenu_Load(object sender, EventArgs e)
        {
            List<Permisos> listapermisos = new CNPermisos().Listar(usuarioActual.id_Usuario);


            foreach (ToolStripMenuItem item in menuStrip.Items)
            {
                bool encontrado = listapermisos.Any(n => n.Nombre_Menu == item.Name);
                if (encontrado == false)
                {
                    item.Visible = false;
                }
            }
            lblUsuario.Text = usuarioActual.Nombre_User;
        }

        private void registrarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroUser frmRegistros = new RegistroUser();
            frmRegistros.MdiParent = this;
            frmRegistros.Show();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proveedores proveedores = new Proveedores();
            proveedores.MdiParent=this;
            proveedores.Show();
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void negocioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngresoDeProductos frmIngresos = new IngresoDeProductos();
            frmIngresos.MdiParent = this;
            frmIngresos.Show();

        }

        private void SubMenuNegocio_Click(object sender, EventArgs e)
        {
            DatosNegocio frmNegocio = new DatosNegocio();
            frmNegocio.MdiParent = this;
            frmNegocio.Show();
        }

        private void realizarCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compras FrmCompras = new Compras(usuarioActual);
            FrmCompras.MdiParent = this;
            FrmCompras.Show();
        }

        private void cerrarSesionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                //para evitar la duplicacion
                conection.OpenConexion();
                string query = "delete ABC";
                SqlCommand cmdcomando = new SqlCommand(query, conection.conexion);
                SqlDataReader adaptador;
                adaptador = cmdcomando.ExecuteReader();
                conection.closeConexion();
            }
            catch
            {

            }
            this.Close();
        }

        private void verDetalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetalleCompra detail = new frmDetalleCompra();
            detail.MdiParent = this;
            detail.Show();
        }

        private void clasificacionABCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbc fabc=new frmAbc();
            fabc.MdiParent = this;
            fabc.Show();    
        }

        private void reportesDeComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportesCompras comprasRport=new frmReportesCompras();
            comprasRport.MdiParent = this;
            comprasRport.Show();    
        }
    }
}
