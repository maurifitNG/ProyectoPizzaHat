using ProyectoPizzaHat.entities;
using ProyectoPizzaHat.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPizzaHat.controller
{
    class PedidoController
    {

        VentaDAO ventaDAO;
        ProductoDAO productoDAO;
        ClienteDAO clienteDAO;
        public PedidoController()
        {
            ventaDAO = new VentaDAO();
            productoDAO = new ProductoDAO();
            clienteDAO = new ClienteDAO();
        }

        public bool nuevoPedido(List<Producto> productos,Cliente cliente)
        {
            Cajero cajero = Program.cajeroLogueado;

            Console.WriteLine("**cajero");

            Console.WriteLine(cajero.rut);
            Console.WriteLine(cajero.nombre);
            Console.WriteLine("**cliente");
            Console.WriteLine(cliente.phone);
            Console.WriteLine(cliente.nombre);

            clienteDAO.agregar(cliente);


            Venta venta = new Venta();

            venta.fecha = DateTime.Now;
            venta.cliente = cliente;
            venta.cajero = cajero;

            ventaDAO.agregar(venta);
            int idVenta = ventaDAO.getLastVentaId();

            foreach (Producto producto in productos)
            {
                producto.idVenta = idVenta;
                productoDAO.agregar(producto);
                int id = productoDAO.getLastProductId();

                producto.id = id;
            }

          
            return false;
        }
    }
}
