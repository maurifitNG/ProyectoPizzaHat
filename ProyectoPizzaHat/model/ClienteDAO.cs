using MySql.Data.MySqlClient;
using ProyectoPizzaHat.entities;
using ProyectoPizzaHat.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPizzaHat.model
{
    class ClienteDAO
    {
        private Database database;
        public ClienteDAO()
        {
            database = new Database();
        }

        public bool agregar(Cliente cliente)
        {
            bool resultado = false;

            try  //Agregamos try-catch para capturar posibles errores de conexión o sintaxis.
            {
                database.abrirConexion();

                string query = "INSERT INTO cliente (phone, nombre) VALUES('" + cliente.phone + "', '" + cliente.nombre + "'); ";

                MySqlDataReader reader = database.ejecutarQuery(query); //Ejecuta la consulta y crea un MySqlDataReader

                reader.Read();

                Console.WriteLine("Registro agregado");

                resultado = true;


            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message); //Si existe un error aquí muestra el mensaje
            }
            finally
            {
                database.cerrarConexion(); //Cierra la conexión a MySQL
            }
            return resultado;
        }
    }
}
