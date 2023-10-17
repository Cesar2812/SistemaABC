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
using CapaEntidad;

namespace Sistema_ABC.Vistas
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void checkBoxPass_CheckedChanged_1(object sender, EventArgs e)//para ver la contraseña
        {
            try
            {
                if (checkBoxPass.Checked == false)
                {
                    textpass.UseSystemPasswordChar = true;
                }
                else
                {
                    textpass.UseSystemPasswordChar = false;
                }
            }
            catch (Exception ey)
            {
                MessageBox.Show(ey.ToString());
            }


        }
        public void fr_closing(object sender, FormClosingEventArgs e)
        {
            textuser.Text = "";
            textpass.Text = "";
            this.Show();

        }

        private void btnIniciar_Click(object sender, EventArgs e)//iniciar Login
        {
            try
            {
                List<Usuarios> test = new CNUsuarios().Listar();
                Usuarios user = new CNUsuarios().Listar().Where(u => u.account == textuser.Text && u.pass == textpass.Text).FirstOrDefault();
                if (user != null)
                {
                    MDIMenu menu = new MDIMenu(user);
                    menu.Show();
                    this.Hide();
                    menu.FormClosing += fr_closing;

                }
                else
                {
                    MessageBox.Show("Usuario no encontrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
