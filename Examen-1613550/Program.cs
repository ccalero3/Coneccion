using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace Examen_1613550
{
    class Program
    {
        static void Main(string[] args)
        {

            //Conectando a Sql primera forma de conectarse 


            Coneccion_Sql mssql = new Coneccion_Sql("SAMSUNG-PC", "SA", "1245", "academia");

            mssql.open();




            DataTable resultado = mssql.obtener_datos("SELECT * FROM adm_alumnos");

            foreach (DataRow filas in resultado.Rows)
            {
                Console.WriteLine("C_carnet= {0} Nombres = {1} Apellidos = {2}", filas.ItemArray[0], filas.ItemArray[1], filas.ItemArray[2]);
            }

            mssql.close();
            Console.ReadKey();
            //Conectando a PosgreSQL Segunda Coenccion

            List<cls_abs_conexion_base> Coneccion = new List<cls_abs_conexion_base>();
            Coneccion.Add(new cls_coneccion_postgre("localhost", "postgres", "1234", "Nomina1"));
            Coneccion[0].open();

            DataTable resultado2 = Coneccion[0].obtener_datos("SELECT * from empleado");


            foreach (DataRow filas in resultado2.Rows)
            {
                Console.WriteLine("ID_Carnet = {0} Nombre= {1} Apellido= {2}", filas.ItemArray[0], filas.ItemArray[1], filas.ItemArray[2]);

            }
            Console.WriteLine("");
            Console.WriteLine("Conexcion cerrada con el servidor Postgres");

            Console.ReadKey();



        }
    }
}
