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
using Sistema_ABC.Utilidades;
using Sistema_ABC.FormulariosModales;
using CapaNegocio;

namespace Sistema_ABC.Vistas
{
    public partial class Compras : Form
    {
        private Usuarios user;
        public Compras(Usuarios obuser = null)
        {
            user = obuser;
            InitializeComponent();
        }

        //cerrar la ventana de Compras
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Compras_Load(object sender, EventArgs e)
        {
            //llenando el combo de tipo de documentos
            comboTipoDoc.Items.Add(new OpcionesDeCombo() { valor = "Boleta", Texto = "Boleta" });
            comboTipoDoc.Items.Add(new OpcionesDeCombo() { valor = "Factura", Texto = "Factura" });
            comboTipoDoc.DisplayMember = "Texto";
            comboTipoDoc.ValueMember = "Valor";
            comboTipoDoc.SelectedIndex = 0;

            //para la fecha
            textFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            textIdProd.Text = "0";
            textIdProv.Text = "0";  

        }

        private void btnBuscarProv_Click(object sender, EventArgs e)//buscar proveedor y añadirlo al text
        {
            using (var modal = new modalProv())
            {
                var result = modal.ShowDialog(); 
                
                if(result==DialogResult.OK)
                {

                    textIdProv.Text = modal._proveedor.id_Prov.ToString();
                    textDocumento.Text = modal._proveedor.Documento.ToString(); 
                    textRazonSocial.Text = modal._proveedor.RazonSocial.ToString();
                }
                else
                {
                    textDocumento.Select();
                }
                
            }
        }

        private void btnbuscarProducto_Click(object sender, EventArgs e)//buscar producto y poner los datos en el fill
        {
           using(var modal=new modalProd())
           {
                var result = modal.ShowDialog();
                if (result==DialogResult.OK) {
                    textIdProd.Text=modal._prod.id_Producto.ToString();
                    texCodProd.Text=modal._prod.Codigo.ToString();
                    textProd.Text=modal._prod.Nombre_Producto.ToString();
                    textCompra.Select();
                
                }
                else
                {
                    texCodProd.Select();
                }
           }

        }

        private void btnAgregarCompra_Click(object sender, EventArgs e)
        {
            decimal precioCompar = 0;
            decimal precioventa = 0;
            bool producto_exist = false;
            if (int.Parse(textIdProd.Text) == 0)
            {
                MessageBox.Show("Debe de selecionar un producto","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            if(!decimal.TryParse(textCompra.Text,out precioCompar))
            {
                MessageBox.Show("Precio Compra-Formato de moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (!decimal.TryParse(textVenta.Text, out precioventa))
            {
                MessageBox.Show("Precio Venta-Formato de moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            foreach(DataGridViewRow fil in dataCompras.Rows)
            {
                if (fil.Cells["idProducto"].Value.ToString() == textIdProd.Text)
                {
                    producto_exist = true;
                    break;
                }
            }
            if (!producto_exist)
            {
                dataCompras.Rows.Add(new object[]
                {
                    textIdProd.Text,
                    textProd.Text,
                    precioCompar.ToString("0.00"),
                    precioventa.ToString("0.00"),
                    textCantida.Value.ToString(),
                    (textCantida.Value * precioCompar).ToString("0.00")
                    
                });
                CalcularTotal();
                limpiarpro();
                textProd.Select();
            }
        }

        private void limpiarpro()
        {
            textIdProd.Text = "0";
            texCodProd.Text = "";
            textProd.Text = "";
            textCompra.Text = "";
            textVenta.Text = "";
            textCantida.Value = 1;
        }

        private void CalcularTotal()
        {
            decimal total= 0;
            if(dataCompras.Rows.Count > 0)
            {
                foreach(DataGridViewRow row in dataCompras.Rows)
                {
                    total += Convert.ToDecimal(row.Cells["MontoTotal"].Value.ToString());
                }
            }
            textTotalPagar.Text = total.ToString("0.00");
        }

        private void dataCompras_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 6)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.basura_removebg_preview.Width;
                var h = Properties.Resources.basura_removebg_preview.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.basura_removebg_preview,new Rectangle(x, y, w, h)); 
                e.Handled = true;

            }
        }

        private void dataCompras_CellContentClick(object sender, DataGridViewCellEventArgs e)//para eliminar en el griv
        {
            if (dataCompras.Columns[e.ColumnIndex].Name == "boton")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    dataCompras.Rows.RemoveAt(indice);
                    CalcularTotal();
                }
            }
        }

        private void textCompra_KeyPress(object sender, KeyPressEventArgs e)//validar el textcompra
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if(textCompra.Text.Trim().Length==0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void textVenta_KeyPress(object sender, KeyPressEventArgs e)//validar el text venta
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (textVenta.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }

        }

        private void btnRegistrar_Click(object sender, EventArgs e)//registrar Compra
        {
            if (Convert.ToInt32(textIdProv.Text) == 0)
            {
                MessageBox.Show("Deebe seleccionar un proveedor", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dataCompras.Rows.Count < 1)
            {
                MessageBox.Show("Deebe ingresar productos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable detalle_compra = new DataTable();
            detalle_compra.Columns.Add("idProducto", typeof(int));
            detalle_compra.Columns.Add("PrecioDeCompra", typeof(decimal));
            detalle_compra.Columns.Add("PrecioDeVenta", typeof(decimal));
            detalle_compra.Columns.Add("Cantidad", typeof(int));
            detalle_compra.Columns.Add("Montototal", typeof(decimal));

            foreach(DataGridViewRow row in dataCompras.Rows)
            {
                detalle_compra.Rows.Add(
                    new object[]
                    {
                        Convert.ToInt32(row.Cells["idProducto"].Value.ToString()),
                        row.Cells["PrecioDeCompra"].Value.ToString(),
                        row.Cells["PrecioDeVenta"].Value.ToString(),
                        row.Cells["Cantidad"].Value.ToString(),
                        row.Cells["Montototal"].Value.ToString(),
                    }); 
            }
            string y = "";
            int correlativo = new CNCompra().obtenerCorrelativo();
            string numerodoc = string.Format("{0:0000}", correlativo);

            Compra oCompra = new Compra()
            {
                od_usuario = new Usuarios() { id_Usuario = user.id_Usuario },
                od_Proveedor = new Proveedor() { id_Prov = Convert.ToInt32(textIdProv.Text) },
                TipoDeDocumento = ((OpcionesDeCombo)comboTipoDoc.SelectedItem).Texto,
                NumeroDocumento = numerodoc,
                MontoTotal = Convert.ToDecimal(textTotalPagar.Text)
            };

            string mensaje = string.Empty;
            bool respues = new CNCompra().Registrar(oCompra, detalle_compra, out mensaje);

            if (respues)
            {
                var result = MessageBox.Show("Numero de Compra generado:\n" + numerodoc + "\n\n¿Desea trasladar al portapapeles?",
                    "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    Clipboard.SetText(numerodoc);
                }
                textIdProv.Text = "0";
                textRazonSocial.Text = "";
                dataCompras.Rows.Clear();
                CalcularTotal();
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
    }
}
