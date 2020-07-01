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
    class CajeroDAO
    {
        private Database database;
        public CajeroDAO()
        {
            database = new Database();
        }

        public Cajero buscar(string  usuario, string pass) {
            Cajero cajero = new Cajero();
            try  //Agregamos try-catch para capturar posibles errores de conexión o sintaxis.
            {
                database.abrirConexion();

                string query = "SELECT rut, nombre FROM cajero WHERE nombre='"+ usuario + "' AND pass='"+pass+"'; ";

                MySqlDataReader reader = database.ejecutarQuery(query); //Ejecuta la consulta y crea un MySqlDataReader

                while (reader.Read())
                {
                    //datos += reader.GetString(0) + "\n";
                    cajero.rut = reader["rut"].ToString();
                    cajero.nombre = reader["nombre"].ToString();
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message); //Si existe un error aquí muestra el mensaje
            }
            finally
            {
                database.cerrarConexion(); //Cierra la conexión a MySQL
            }
            return cajero;
        }
        }
    }

