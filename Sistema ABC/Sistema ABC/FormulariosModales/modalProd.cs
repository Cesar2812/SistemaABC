using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using DocumentFormat.OpenXml.Packaging;
using Sistema_ABC.Vistas;
using CapaEntidad;
using CapaDatos;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Sistema_ABC.FormulariosModales
{
    public partial class modalProd : Form
    {
        CapaNegocio.CNProductos cpro = new CapaNegocio.CNProductos();
        CapaDatos.CDProductos _c2 = new CapaDatos.CDProductos();//instancia de la capa de datos
        Conexion conection = new Conexion();//cadena de conexion base de datos

        public Producto _prod { get; set; }
        public modalProd()
        {
            InitializeComponent();
        }

        private void modalProd_Load(object sender, EventArgs e)
        {
            dataProdModal.DataSource = cpro.prod_modal();
        }

        private void dataProdModal_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icolumn = e.ColumnIndex;

            if (irow >= 0 && icolumn > 0)
            {
                _prod = new Producto()
                {
                    id_Producto = Convert.ToInt32(dataProdModal.Rows[irow].Cells[0].Value.ToString()),
                    Codigo = (dataProdModal.Rows[irow].Cells[1].Value.ToString()),
                    Nombre_Producto = (dataProdModal.Rows[irow].Cells[2].Value.ToString()),
                };
                

            }
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void txtBusquedas_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cadena = txtBusquedas.Text;
                dataProdModal.Columns.Clear();
                dataProdModal.DataSource = null;
                if (string.IsNullOrEmpty(cadena) || string.IsNullOrWhiteSpace(cadena))
                {
                    CapaDatos.CDProductos _c2 = new CapaDatos.CDProductos();//instancia de la capa de datos
                    dataProdModal.DataSource = _c2.mostrarProductosModal();
                }
                else
                {

                    DataTable table = new DataTable();
                    SqlCommand cmd = new SqlCommand();
                    _c2.conection = new CapaDatos.Conexion();
                    SqlDataReader leerfilas;
                    cmd.Connection = conection.OpenConexion();
                    cmd.CommandText = "BuscarProd";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TextoBusqueda", cadena);
                    int? TipoBusqueda;

                    switch (comboOptions.Text)
                    {
                        case "Nombre":
                            TipoBusqueda = 1;
                            break;

                        case "Categoria":
                            TipoBusqueda = 2;
                            break;

                        case "Codigo":
                            TipoBusqueda = 3;
                            break;

                        default:
                            TipoBusqueda = null;
                            break;
                    }

                    cmd.Parameters.AddWithValue("@TipoSearch", TipoBusqueda);
                    leerfilas = cmd.ExecuteReader();
                    table.Load(leerfilas);
                    leerfilas.Close();
                    conection.closeConexion();
                    dataProdModal.DataSource = table;
                    conection.conexion.Close();
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        } 
}   }
    

        

