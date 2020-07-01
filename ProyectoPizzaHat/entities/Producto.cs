using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPizzaHat.entities
{
    class Producto
    {
       public int id { get; set; }
       public string nombre { get; set; }
       public int precio { get; set; }
       public  int cantidad { get; set; }
       public int idVenta { get; set; }
    }
}
