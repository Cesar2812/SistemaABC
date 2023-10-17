using CapaDatos;
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
using System.Data.SqlClient;
using ClosedXML.Excel;
using SpreadsheetLight;
using SpreadsheetLight.Drawing;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Sistema_ABC.Vistas
{
    public partial class frmAbc : Form
    {
        IngresoDeProductos ingresar = new IngresoDeProductos();

        CapaNegocio.CNabc abc = new CapaNegocio.CNabc();//Capa de Negocio ABC
        Conexion conection = new Conexion();//cadena de conexion base de datos
        public frmAbc()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
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

        private void frmAbc_Load(object sender, EventArgs e)
        {
            dataGridProcentaje.DataSource = abc.Listar_Porce();

            //metodo para el shart del ABC como tal
            DataTable dtRangos = new DataTable();
            dtRangos = abc.ListarChartRangos();
            int filas = dtRangos.Rows.Count;
            for (int k = 0; k <= filas - 1; k++)
            {
                chartRangos.Series["Series1"].Points.AddXY(dtRangos.Rows[k]["Producto"], dtRangos.Rows[k]["Rango"]);
            }

            decimal acumulado = Convert.ToDecimal(dataGridProcentaje.Rows[0].Cells["Porcentaje"].Value);

            dataGridProcentaje.Rows[0].Cells["PorcentajeAcumulado"].Value = acumulado;

            for (int i = 0; i < dataGridProcentaje.Rows.Count - 1; i++)
            {
                acumulado += Convert.ToDecimal(dataGridProcentaje.Rows[i + 1].Cells["Porcentaje"].Value);
                dataGridProcentaje.Rows[i + 1].Cells["PorcentajeAcumulado"].Value = acumulado;
            }
            //tomando datos para el ABC
            SqlCommand terminal = new SqlCommand("insert into ABC (id_PPro,Precio,PorcentajeFinal) values(@id,@PrecioTotal,@Porcentajeacum)", conection.conexion);
            conection.OpenConexion();
            try
            {
                foreach (DataGridViewRow row in dataGridProcentaje.Rows)
                {
                    terminal.Parameters.Clear();

                    terminal.Parameters.AddWithValue("@id", Convert.ToInt32(row.Cells["ID"].Value));
                    terminal.Parameters.AddWithValue("@PrecioTotal", Convert.ToInt32(row.Cells["PrecioTotal"].Value));
                    terminal.Parameters.AddWithValue("@Porcentajeacum", Convert.ToDecimal(row.Cells["PorcentajeAcumulado"].Value));

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
            ///metodo para el shart
            DataTable dtabc = new DataTable();
            dtabc = abc.ListarChart();
            int xfilas = dtabc.Rows.Count;
            decimal suma = 0;
            for (int i = 0; i <= xfilas - 1; i++)
            {
                chartABC.Series["Productos"].Points.AddXY(dtabc.Rows[i]["Nombre"], dtabc.Rows[i]["ValorPorcentualFinal"]);
                string c = "";
                suma = suma + Convert.ToDecimal(dtabc.Rows[i]["PrecioTotal"]);
            }
            labelSuma.Text = "C$" + suma.ToString();


            dataA.DataSource = abc.ListarA();
            dataB.DataSource = abc.ListarB();
            dataC.DataSource = abc.ListarC();
        }

        
    }
}
