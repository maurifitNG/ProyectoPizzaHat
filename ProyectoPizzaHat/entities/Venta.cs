using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPizzaHat.entities
{
    class Venta
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public Cajero cajero { get; set; }
        public Cliente cliente { get; set; }
        public int total { get; set; }
    }
}
