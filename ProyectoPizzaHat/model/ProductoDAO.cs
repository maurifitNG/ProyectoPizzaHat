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
    class ProductoDAO
    {
        private Database database;
        public ProductoDAO()
        {
            database = new Database();
        }

        public bool agregar (Producto producto)
        {
            bool resultado = false;

            try  //Agregamos try-catch para capturar posibles errores de conexión o sintaxis.
            {
                database.abrirConexion();

                string query = "INSERT INTO producto (nombre, precio, cantidad) VALUES('" + producto.nombre + "', '" + producto.precio + "', '" + producto.cantidad + "'); ";

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

        public int getLastProductId()
        {
            int id = 0;

            try  //Agregamos try-catch para capturar posibles errores de conexión o sintaxis.
            {
                database.abrirConexion();

                string query = "SELECT LAST_INSERT_ID();";

                MySqlDataReader reader = database.ejecutarQuery(query); //Ejecuta la consulta y crea un MySqlDataReader

                while (reader.Read())
                {
                    string result = reader.GetString(0);

                    if (!String.IsNullOrEmpty(result))
                    {
                        id = Int32.Parse(result);
                    }
                }

                return id;

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message); //Si existe un error aquí muestra el mensaje
            }
            finally
            {
                database.cerrarConexion(); //Cierra la conexión a MySQL
            }
            return id;
        }
    }
}
