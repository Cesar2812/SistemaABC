using CapaDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using ClosedXML.Excel;
using SpreadsheetLight;
using SpreadsheetLight.Drawing;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Sistema_ABC.Vistas
{
    public partial class IngresoDeProductos : Form
    {
        CapaNegocio.CNProductos _Prod = new CapaNegocio.CNProductos();//instancia de la capa de negocio
        Conexion conection = new Conexion();//cadena de conexion base de datos
        CapaDatos.CDProductos _c2 = new CapaDatos.CDProductos();//instancia de la capa de datos


        string operacion = "Insertar";
        string id_Produ, porcen, to, inv, com, ven;
        //variables para almacenar codigo
        string producto = "";
        string codigo;

        public IngresoDeProductos()
        {
            InitializeComponent();
        }
        private void IngresoDeProductos_Load(object sender, EventArgs e)//metodo para cargar el griv de productos al iniciar
        {
            ListarCategorias();
            dataGridProd.DataSource = _Prod.Mostrar_Productos();
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)//cargar datos en el combo de Marcas en base a la Categoria
        {
            try
            {
                if (cmbCategoria.SelectedValue.ToString() != null)
                {
                    string idCateg = cmbCategoria.SelectedValue.ToString();
                    ListarMarcas(idCateg);


                }
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.ToString());
            }
        }
        public void ListarCategorias()//listar categorias en el combobox
        {
            try
            {
                conection.OpenConexion();
                SqlCommand cmd = new SqlCommand("Select id_Categoria,Nombre_Categoria from Categorias", conection.conexion);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable DT = new DataTable();
                da.Fill(DT);
                conection.closeConexion();

                DataRow fila = DT.NewRow();
                fila["Nombre_Categoria"] = "Selecciona una categoria";
                DT.Rows.InsertAt(fila, 0);

                cmbCategoria.ValueMember = "id_Categoria";
                cmbCategoria.DisplayMember = "Nombre_Categoria";
                cmbCategoria.DataSource = DT;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        
        public void ListarMarcas(string id_Categoria)
        {
            try
            {
                conection.OpenConexion();
                SqlCommand cmd = new SqlCommand("Select id_Marca,Nombre_Marca from Marcas where id_Categoria=@id_Categoria", conection.conexion);
                cmd.Parameters.AddWithValue("id_Categoria", id_Categoria);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conection.closeConexion();

                DataRow dr = dt.NewRow();
                dr["Nombre_Marca"] = "Selecciona una Marca";
                dt.Rows.InsertAt(dr, 0);

                cmbMarca.ValueMember = "id_Marca";
                cmbMarca.DisplayMember = "Nombre_Marca";
                cmbMarca.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }


        private void btnAgregar_Click(object sender, EventArgs e)//agregar productos al Griv de Productos
        {
            try
            {
                if (operacion == "Insertar")
                {
                    _Prod.Añadir_Productos(textCodigo.Text, textProd.Text, Convert.ToInt32(cmbMarca.SelectedValue), Convert.ToInt32(cmbCategoria.SelectedValue), textDescripcion.Text);

                    MessageBox.Show("Producto Insertado");
                }
                else if (operacion == "Editar")
                {
                    _Prod.Editar_Productos(Convert.ToInt32(id_Produ),
                    textCodigo.Text, textProd.Text, Convert.ToInt32(cmbMarca.SelectedValue),
                    Convert.ToInt32(cmbCategoria.SelectedValue), textDescripcion.Text);
                    //opc = "Insertar";
                    MessageBox.Show("Producto Editado Correctamente");
                    dataGridProd.DataSource = _Prod.Mostrar_Productos();
                }
                dataGridProd.DataSource = _Prod.Mostrar_Productos();
                ///Limpiar texfields
                textCodigo.Clear();
                textDescripcion.Clear();
                textProd.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        
        private void btnAgregarCodigo_Click(object sender, EventArgs e)// boton para agregar codigo al producto
        {
            try
            {
                if (textProd.Text == " ")
                {
                    MessageBox.Show("Escriba el Producto");
                }
                else
                {
                    textCodigo.Text = "";
                    producto = textProd.Text + " " + cmbCategoria.Text + " " + cmbMarca.Text;
                    textCodigo.Text = generarCodigo(producto);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)//bton editar
        {
            try
            {
                if (dataGridProd.SelectedRows.Count > 0)
                {
                    operacion = "Editar";
                    id_Produ = dataGridProd.CurrentRow.Cells["ID"].Value.ToString();
                    textProd.Text = dataGridProd.CurrentRow.Cells["Nombre"].Value.ToString();
                    cmbCategoria.Text = dataGridProd.CurrentRow.Cells["Categoria"].Value.ToString();
                    cmbMarca.Text = dataGridProd.CurrentRow.Cells["Marca"].Value.ToString();
                    textDescripcion.Text = dataGridProd.CurrentRow.Cells["Descripcion"].Value.ToString();
                    inv = dataGridProd.CurrentRow.Cells["Inventario"].Value.ToString();
                    com = dataGridProd.CurrentRow.Cells["PrecioDeCompra"].Value.ToString();
                    ven = dataGridProd.CurrentRow.Cells["PrecioDeVenta"].Value.ToString();
                    to = dataGridProd.CurrentRow.Cells["Total"].Value.ToString();
                    porcen = dataGridProd.CurrentRow.Cells["Porcentaje"].Value.ToString();
                   
                }
                else
                {
                    MessageBox.Show("Debe Selecionar un Producto");
                }

            }
            catch
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)//bton eliminar
        {
            _Prod.Eliminar_Productos(Convert.ToInt32(dataGridProd.CurrentRow.Cells[0].Value.ToString()));
            MessageBox.Show("Producto eliminado correctamente");
            dataGridProd.DataSource = _Prod.Mostrar_Productos();
        }

        private void dataGridProd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                operacion = "Editar";
                id_Produ = dataGridProd.CurrentRow.Cells["ID"].Value.ToString();
                textProd.Text = dataGridProd.CurrentRow.Cells["Nombre"].Value.ToString();
                cmbCategoria.Text = dataGridProd.CurrentRow.Cells["Categoria"].Value.ToString();
                cmbMarca.Text = dataGridProd.CurrentRow.Cells["Marca"].Value.ToString();
                textDescripcion.Text = dataGridProd.CurrentRow.Cells["Descripcion"].Value.ToString();
                inv = dataGridProd.CurrentRow.Cells["Inventario"].Value.ToString();
                com = dataGridProd.CurrentRow.Cells["PrecioDeCompra"].Value.ToString();
                ven = dataGridProd.CurrentRow.Cells["PrecioDeVenta"].Value.ToString();
                to = dataGridProd.CurrentRow.Cells["Total"].Value.ToString();
                porcen = dataGridProd.CurrentRow.Cells["Porcentaje"].Value.ToString();
            }
            catch
            {
            }
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        ////Metodo para añadir codigo ramdon
        public string generarCodigo(string product)
        {
            try
            {
                string[] cadena = product.Split(' ').ToArray();
                codigo = "";
                for (int i = 0; i < cadena.Length; i++)
                {
                    codigo += cadena[i].Substring(0, 1).ToUpper();

                }

                codigo = codigo + "-";
                Random codigo2 = new Random();
                int valor = codigo2.Next(1, 2500);
                codigo += valor.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return codigo;
        }

        private void txtBusquedas_TextChanged(object sender, EventArgs e)//filro de busquedas
        {
            try
            {
                string cadena = txtBusquedas.Text;
                dataGridProd.Columns.Clear();
                dataGridProd.DataSource = null;
                if (string.IsNullOrEmpty(cadena) || string.IsNullOrWhiteSpace(cadena))
                {
                    CapaDatos.CDProductos _c2 = new CapaDatos.CDProductos();//instancia de la capa de datos
                    dataGridProd.DataSource = _c2.ListarProductos();
                }
                else
                {

                    DataTable table = new DataTable();
                    SqlCommand cmd = new SqlCommand();
                    _c2.conection = new CapaDatos.Conexion();
                    SqlDataReader leerfilas;
                    cmd.Connection = conection.OpenConexion();
                    cmd.CommandText = "Search_Productos";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TextoBusqueda", cadena);
                    int? TipoBusqueda;

                    switch (comboOptions.Text)
                    {
                        case "Nombre":
                            TipoBusqueda = 1;
                            break;

                        case "Marca":
                            TipoBusqueda = 2;
                            break;

                        case "Categoria":
                            TipoBusqueda = 3;
                            break;

                        case "Codigo":
                            TipoBusqueda = 4;
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
                    dataGridProd.DataSource = table;
                    conection.conexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnoExcel_Click(object sender, EventArgs e)//boton para generar reporte de Excel
        {
            if (dataGridProd.Rows.Count < 1)
            {
                MessageBox.Show("No hay Datos para Exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else {
                MessageBox.Show("¿Desea Guardar el Reporte en el ordenador?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                MessageBox.Show("Reporte Generado");
                SLDocument sl = new SLDocument();
                System.Drawing.Bitmap bm = new System.Drawing.Bitmap(@"C:\Users\Cesar Cerda\Desktop\Ferreteria2.png");
                byte[] ba;
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    bm.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    ms.Close();
                    ba = ms.ToArray();
                }
                SLPicture pic = new SLPicture(ba, DocumentFormat.OpenXml.Packaging.ImagePartType.Png);
                pic.SetPosition(0, 0);
                pic.ResizeInPixels(150, 100);
                sl.InsertPicture(pic);
                sl.SetCellValue("F5", "Reporte de Productos");
                SLStyle syle = sl.CreateStyle();
                syle.Font.FontName = "Arial";
                syle.Font.FontSize = 14;
                syle.Font.Bold = true;

                sl.SetCellStyle("F5", syle);
                sl.MergeWorksheetCells("F5", "I5");
                int cabecera = 7;
                int celdainicial = 7;
                sl.RenameWorksheet(SLDocument.DefaultFirstSheetName, "Productos");//asignando cabeceras
                sl.SetCellValue("B" + cabecera, "ID");
                sl.SetCellValue("C" + cabecera, "Codigo");
                sl.SetCellValue("D" + cabecera, "Nombre");
                sl.SetCellValue("E" + cabecera, "Marca");
                sl.SetCellValue("F" + cabecera, "Categoria");
                sl.SetCellValue("G" + cabecera, "Descripcion");
                sl.SetCellValue("H" + cabecera, "Inventario");
                sl.SetCellValue("I" + cabecera, "PrecioDeCompra");
                sl.SetCellValue("J" + cabecera, "PrecioDeVenta");
                sl.SetCellValue("K" + cabecera, "Total");
                sl.SetCellValue("L" + cabecera, "Porcentaje");

                SLStyle estiloColumna = sl.CreateStyle();
                estiloColumna.Font.FontName = "Arial";
                estiloColumna.Font.FontSize = 12;
                estiloColumna.Font.Bold = true;
                estiloColumna.Font.FontColor = System.Drawing.Color.Black;
                estiloColumna.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.Yellow, System.Drawing.Color.Lime);
                sl.SetCellStyle("B" + cabecera, "L" + cabecera, estiloColumna);

                //recoriendo el Griv
                foreach (DataGridViewRow row in dataGridProd.Rows)
                {
                    cabecera++;
                    sl.SetCellValue("B" + cabecera, row.Cells[0].Value.ToString());
                    sl.SetCellValue("C" + cabecera, row.Cells[1].Value.ToString());
                    sl.SetCellValue("D" + cabecera, row.Cells[2].Value.ToString());
                    sl.SetCellValue("E" + cabecera, row.Cells[3].Value.ToString());
                    sl.SetCellValue("F" + cabecera, row.Cells[4].Value.ToString());
                    sl.SetCellValue("G" + cabecera, row.Cells[5].Value.ToString());
                    sl.SetCellValue("H" + cabecera, row.Cells[6].Value.ToString());//stock
                    sl.SetCellValue("I" + cabecera, row.Cells[7].Value.ToString());
                    sl.SetCellValue("J" + cabecera, row.Cells[8].Value.ToString());//precio venta
                    sl.SetCellValue("K" + cabecera, row.Cells[9].Value.ToString());
                    sl.SetCellValue("L" + cabecera, row.Cells[10].Value.ToString());

                }
                SLStyle estiloborde = sl.CreateStyle();
                estiloborde.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
                estiloborde.Border.LeftBorder.Color = System.Drawing.Color.Black;
                estiloborde.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
                estiloborde.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
                estiloborde.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
                sl.SetCellStyle("B" + celdainicial, "L" + cabecera, estiloborde);


                sl.AutoFitColumn("B", "L");
                sl.SaveAs(@"C:\Users\Cesar Cerda\Desktop\ReporteInvenatrio.xlsx");

            }

        }
        private void btCalcular_Click(object sender, EventArgs e)//boton Calcular Datos Para el ABC
        {
            decimal multCantidadInv = 0;
            decimal TotalCantidadInv = 0;
            decimal Porcentaej = 0;
            decimal Porcentaje2;
            try
            {
                for (int i = 0; i < dataGridProd.Rows.Count; i++)
                {
                    int cantidad = Convert.ToInt32(dataGridProd.Rows[i].Cells["Inventario"].Value);
                    decimal precio = Convert.ToDecimal(dataGridProd.Rows[i].Cells["PrecioDeVenta"].Value);
                    multCantidadInv = cantidad * precio;
                    dataGridProd.Rows[i].Cells["Total"].Value = multCantidadInv;//se añade para efectos de prueba
                    TotalCantidadInv += Convert.ToDecimal(dataGridProd.Rows[i].Cells["Total"].Value);
                }
                label10.Text = "C$" + TotalCantidadInv.ToString();//para mostrar la suma a manera de prueba


                for (int i = 0; i < dataGridProd.Rows.Count; i++)
                {
                    Porcentaej = (Convert.ToDecimal(dataGridProd.Rows[i].Cells["Total"].Value) / TotalCantidadInv) * 100;
                    Porcentaje2 = Math.Round(Porcentaej, 2);
                    dataGridProd.Rows[i].Cells["Porcentaje"].Value = Porcentaje2;//se añade para efectos de prueba
                }

            }
            catch
            {

            }

            //tomar datos de la tabla para porcentaje y el producto
            SqlCommand terminal = new SqlCommand("insert into Porcentajes (id_Pro,PrecioTotal,porc)values(@id,@PrecioTotal,@Porcentaje)", conection.conexion);
            conection.OpenConexion();
            try
            {
                foreach (DataGridViewRow row in dataGridProd.Rows)
                {
                    terminal.Parameters.Clear();

                    terminal.Parameters.AddWithValue("@id", Convert.ToInt32(row.Cells["ID"].Value));
                    terminal.Parameters.AddWithValue("@PrecioTotal", Convert.ToInt32(row.Cells["Total"].Value));
                    terminal.Parameters.AddWithValue("@Porcentaje", Convert.ToDecimal(row.Cells["Porcentaje"].Value));

                    terminal.ExecuteNonQuery();

                }

            }
            catch
            {

            }
            finally
            {
                conection.closeConexion();
            }
            try
            {
                ///para evitar errores de duplicacion
                conection.OpenConexion();
                string consulta = "delete Porcentajes";
                SqlCommand cdm = new SqlCommand(consulta, conection.conexion);
                SqlDataReader comanddo;
                comanddo = cdm.ExecuteReader();
                conection.closeConexion();
            }
            catch
            {

            }
            try
            {
                SqlCommand dfg = new SqlCommand("insert into Porcentajes (id_Pro,PrecioTotal,porc)values(@id,@PrecioTotal,@Porcentaje)", conection.conexion);
                conection.OpenConexion();

                foreach (DataGridViewRow row2 in dataGridProd.Rows)
                {
                    terminal.Parameters.Clear();

                    terminal.Parameters.AddWithValue("@id", Convert.ToInt32(row2.Cells["ID"].Value));
                    terminal.Parameters.AddWithValue("@PrecioTotal", Convert.ToInt32(row2.Cells["Total"].Value));
                    terminal.Parameters.AddWithValue("@Porcentaje", Convert.ToDecimal(row2.Cells["Porcentaje"].Value));

                    terminal.ExecuteNonQuery();

                }

            }
            catch
            {

            }
            finally
            {
                conection.closeConexion();
            }
        }
    }
}
