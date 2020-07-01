using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPizzaHat.utils
{
    class Database
    {
        MySqlConnection conexionBD;
        string cadenaConexion;

        public Database()
        {
            string servidor = "localhost"; //Nombre o ip del servidor de MySQL
            string bd = "pizza_db"; //Nombre de la base de datos
            string usuario = "root"; //Usuario de acceso a MySQL
            string password = ""; //Contraseña de usuario de acceso a MySQL

            //Crearemos la cadena de conexión concatenando las variables
            cadenaConexion = "Database=" + bd + "; Data Source=" + servidor + "; User Id=" + usuario + "; Password=" + password + "";

            //Instancia para conexión a MySQL, recibe la cadena de conexión
        }

        public void abrirConexion()
        {
            conexionBD = new MySqlConnection(cadenaConexion);
        }

        public MySqlDataReader ejecutarQuery(string query)
        {
            MySqlCommand mysqlQuery = new MySqlCommand(query);
            mysqlQuery.Connection = conexionBD;
            conexionBD.Open();

            return mysqlQuery.ExecuteReader();
        }

        public void cerrarConexion()
        {
            conexionBD.Close();
        }
    }
}
