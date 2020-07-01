using ProyectoPizzaHat.controller;
using ProyectoPizzaHat.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPizzaHat
{
    public partial class Login : Form
    {
        LoginController loginController;
        public Login()
        {
            InitializeComponent();
            loginController = new LoginController();
        }
        private void txt_usuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = txt_usuario.Text;
            string pass = txt_password.Text;

            bool usuarioLogueado = loginController.loginCajero(usuario, pass);

            if (usuarioLogueado)
            {
                this.Hide();
                var pedidoView = new PedidoView();
                pedidoView.Closed += (s, args) => this.Close();
                pedidoView.Show();
            }
            else
            {
                labelError.Visible = true;
            }


        }       
    }
}
