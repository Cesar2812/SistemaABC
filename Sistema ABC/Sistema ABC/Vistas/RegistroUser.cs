using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using Sistema_ABC.Utilidades;
using CapaEntidad;
using CapaNegocio;

namespace Sistema_ABC.Vistas
{

    public partial class RegistroUser : Form
    {
        public RegistroUser()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegistroUser_Load(object sender, EventArgs e)//cargar todos los combos en el modulo de Usuarios
        {
            comboActivo.Items.Add(new OpcionesDeCombo() { valor = 1, Texto = "Activo" });
            comboActivo.Items.Add(new OpcionesDeCombo() { valor = 0, Texto = "No Activo" });

            comboActivo.DisplayMember = "Texto";
            comboActivo.ValueMember = "Valor";
            comboActivo.SelectedIndex = 0;

            List<Rol> listarol = new CNRol().Listar();
            foreach (Rol item in listarol)
            {
                comboRol.Items.Add(new OpcionesDeCombo() { valor = item.id_Rol, Texto = item.Descripcion });


            }
            comboRol.DisplayMember = "Texto";
            comboRol.ValueMember = "Valor";
            comboRol.SelectedIndex = 0;

            try
            {
                foreach (DataGridViewColumn colum in dataGridUsers.Columns)
                {
                    if (colum.Visible == true && colum.Name != "btnSelec" && colum.Name != "Estado")
                    {
                        comboBusqueda.Items.Add(new OpcionesDeCombo() { valor = colum.Name, Texto = colum.HeaderText });
                    }

                }
                comboBusqueda.DisplayMember = "Texto";
                comboBusqueda.ValueMember = "Valor";
                comboBusqueda.SelectedIndex = 0;
            }
            catch
            {
            }

            //mostrar en el gric usuario
            List<Usuarios> listausuarios = new CNUsuarios().Listar();
            foreach (Usuarios item in listausuarios)
            {
                try
                {
                    dataGridUsers.Rows.Add(new object[] {"",item.id_Usuario,item.Nombre_User,item.account,item.pass,
                       item.objRolU.id_Rol,
                       item.objRolU.Descripcion,
                       item.Estado==true ?1 : 0,
                        item.Estado== true ? "Activo" : "No Activo"
                    });
                }
                catch
                {

                }
            }

        }

        private void butregistrar_Click(object sender, EventArgs e)//boton para registrar Usuario
        {
            string mensaje = string.Empty;

            Usuarios objusuario = new Usuarios()
            {
                id_Usuario = Convert.ToInt32(txtID.Text),
                Nombre_User = textNombre.Text,
                account = textuser.Text,
                pass = textpass.Text,
                objRolU = new Rol() { id_Rol = Convert.ToInt32(((OpcionesDeCombo)comboRol.SelectedItem).valor) },
                Estado = Convert.ToInt32(((OpcionesDeCombo)comboActivo.SelectedItem).valor) == 1 ? true : false
            };

            if (objusuario.id_Usuario == 0)
            {
                int idusuariocreado = new CNUsuarios().Registrar(objusuario, out mensaje);

                if (idusuariocreado != 0)
                {
                    try
                    {
                        MessageBox.Show("Usuario insertado");
                        dataGridUsers.Rows.Add(new object[] {"",idusuariocreado,textNombre.Text,textuser.Text,textpass.Text,
                           ((OpcionesDeCombo)comboRol.SelectedItem).valor.ToString(),
                             ((OpcionesDeCombo)comboRol.SelectedItem).Texto.ToString(),
                           ((OpcionesDeCombo)comboActivo.SelectedItem).valor.ToString(),
                            ((OpcionesDeCombo)comboActivo.SelectedItem).Texto.ToString()
                        });

                    }
                    catch
                    {
                    }
                    Limpiar();

                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                bool resultado = new CNUsuarios().editar(objusuario, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dataGridUsers.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["id_usuario"].Value = txtID.Text;
                    row.Cells["Nombre_User"].Value = textNombre.Text;
                    row.Cells["Usuario"].Value = textuser.Text;
                    row.Cells["Clave"].Value = textpass.Text;
                    row.Cells["idRol"].Value = ((OpcionesDeCombo)comboRol.SelectedItem).valor.ToString();
                    row.Cells["Rol"].Value = ((OpcionesDeCombo)comboRol.SelectedItem).Texto.ToString();
                    row.Cells["EstadoValor"].Value = ((OpcionesDeCombo)comboActivo.SelectedItem).valor.ToString();
                    row.Cells["Estado"].Value = ((OpcionesDeCombo)comboActivo.SelectedItem).Texto.ToString();

                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
        }

        public void Limpiar()
        {
            txtIndice.Text = "-1";
            txtID.Text = "0";
            textNombre.Text = "";
            textuser.Text = "";
            textpass.Text = "";
            textConfirm.Text = "";

            textNombre.Select();

        }

        private void dataGridUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)//boton para seleccionar usuario
        {
            if (dataGridUsers.Columns[e.ColumnIndex].Name == "btnSelec")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtID.Text = dataGridUsers.Rows[indice].Cells["id_usuario"].Value.ToString();
                    textNombre.Text = dataGridUsers.Rows[indice].Cells["Nombre_User"].Value.ToString();
                    textuser.Text = dataGridUsers.Rows[indice].Cells["Usuario"].Value.ToString();
                    textpass.Text = dataGridUsers.Rows[indice].Cells["Clave"].Value.ToString();
                    textConfirm.Text = dataGridUsers.Rows[indice].Cells["Clave"].Value.ToString();

                    foreach (OpcionesDeCombo oc in comboRol.Items)
                    {
                        if (Convert.ToInt32(oc.valor) == Convert.ToInt32(dataGridUsers.Rows[indice].Cells["idRol"].Value))
                        {
                            int indice_combo = comboRol.Items.IndexOf(oc);
                            comboRol.SelectedIndex = indice_combo;
                            break;

                        }
                    }

                    foreach (OpcionesDeCombo oc in comboActivo.Items)
                    {
                        if (Convert.ToInt32(oc.valor) == Convert.ToInt32(dataGridUsers.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_combo = comboActivo.Items.IndexOf(oc);
                            comboActivo.SelectedIndex = indice_combo;
                            break;

                        }
                    }

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)//boton eliminar
        {
            if (Convert.ToInt32(txtID.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar el usuario?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Usuarios objusuario = new Usuarios()
                    {
                        id_Usuario = Convert.ToInt32(txtID.Text)
                    };
                    bool respuesta = new CNUsuarios().eliminar(objusuario, out mensaje);

                    if (respuesta)
                    {
                        dataGridUsers.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                    }
                }
            }
            Limpiar();
        }

        private void pictureBox3_Click(object sender, EventArgs e)//filtro de Busqueda
        {
            string filtro = ((OpcionesDeCombo)comboBusqueda.SelectedItem).valor.ToString();
            if (dataGridUsers.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridUsers.Rows)
                {
                    if (row.Cells[filtro].Value.ToString().Trim().ToUpper().Contains(textBusquedas.Text.Trim().ToUpper()))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }

                }
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)//eliminar de la busqueda
        {
            textBusquedas.Text = "";
            foreach (DataGridViewRow row in dataGridUsers.Rows)
            {
                row.Visible = true;
            }
        }
    }
}
