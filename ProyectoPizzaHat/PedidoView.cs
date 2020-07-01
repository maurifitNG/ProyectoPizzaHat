using MySql.Data.MySqlClient.Memcached;
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
    public partial class PedidoView : Form
    {
        PedidoController pedidoController;
        public PedidoView()
        {
            InitializeComponent();

            pedidoController = new PedidoController();
        }

        private void TxtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void PedidoView_Load(object sender, EventArgs e)
        {
           
        }

        private void BtnAddPedido_Click(object sender, EventArgs e)
        {
            List<Producto> productos = new List<Producto>();

            if (CantPizzaFamiliar.Text != "")
            {
                Producto producto = new Producto();
                producto.nombre = "Pizza Familiar";
                producto.cantidad = Int32.Parse(CantPizzaFamiliar.Text);
                producto.precio = 22000;

                productos.Add(producto);
            }

            if (CantPizzaMediana.Text != "")
            {
                Producto producto = new Producto();
                producto.nombre = "Pizza Mediana";
                producto.cantidad = Int32.Parse(CantPizzaMediana.Text);
                producto.precio = 12000;

                productos.Add(producto);
            }

            if (CantPizzaIndividual.Text != "")
            {
                Producto producto = new Producto();
                producto.nombre = "Pizza Individual";
                producto.cantidad = Int32.Parse(CantPizzaIndividual.Text);
                producto.precio = 8000;

                productos.Add(producto);
            }

            if (CantBebidaFamiliar.Text != "")
            {
                Producto producto = new Producto();
                producto.nombre = "Bebida Familiar";
                producto.cantidad = Int32.Parse(CantBebidaFamiliar.Text);
                producto.precio = 5000;

                productos.Add(producto);
            }

            if (CantBebidaIndividual.Text != "")
            {
                Producto producto = new Producto();
                producto.nombre = "Bebida Individual";
                producto.cantidad = Int32.Parse(CantBebidaIndividual.Text);
                producto.precio = 1500;

                productos.Add(producto);
            }

            Cliente cliente = new Cliente();

            cliente.nombre = TxtNombreCliente.Text;
            cliente.phone = Int32.Parse(TxtTelefonoCliente.Text);

            PedidoDataGrid.DataSource = productos;
            PedidoDataGrid.Columns["id"].Visible = false;

            pedidoController.nuevoPedido(productos, cliente);

            int totalPedido = obtenerTotalPedido(productos);
            LabelTotal.Text = totalPedido.ToString();

        }

        int obtenerTotalPedido(List<Producto> productos)
        {
            int suma = 0;
            foreach(Producto producto in productos)
            {
                suma = suma + producto.precio * producto.cantidad;
            }
            return suma;
        }
      
    }
}
