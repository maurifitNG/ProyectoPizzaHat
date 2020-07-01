using ProyectoPizzaHat.entities;
using ProyectoPizzaHat.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPizzaHat.controller
{
    class LoginController
    {
        CajeroDAO cajeroDAO;

        public LoginController()
        {
            cajeroDAO = new CajeroDAO();
        }
        public bool loginCajero(string usuario, string pass)
        {
           Cajero cajero = cajeroDAO.buscar(usuario, pass);

          
            Program.cajeroLogueado = cajero;

            Console.WriteLine("Rut");

            Console.WriteLine(cajero.rut);

            if (cajero != null && !String.IsNullOrEmpty(cajero.rut))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
