using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Examen_1613550
{
    class Coneccion_Sql : cls_abs_conexion_base
    {

        private SqlConnection conexion = new SqlConnection();
        private SqlCommand comando;
        private SqlDataReader lector;  
        public Coneccion_Sql(string host, string user, string password, string database)
        {
            this.host = host;
            this.user = user;
            this.password = password;
            this.database = database;

            stringConeccion = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=True",host,database);

            conexion.ConnectionString = stringConeccion;  

        }
        public override void open()
        {
            try
            { 
                conexion.Open();
                Console.WriteLine("*************************************************");
                Console.WriteLine("         INICIANDO APERTURA DE CONECCION A SQL  ");
                Console.WriteLine("*************************************************");
                Console.WriteLine("====SERVER :{0} , BASE DE DATOS : {1}", host, database);
                Console.WriteLine("*************************************************");
                Console.WriteLine("");
            }
            catch(Exception E)
            { Console.WriteLine("Coneccion Fallida"+E.Message); }
        }

        public override void close()
        {
            conexion.Close();
            Console.WriteLine("");
            Console.WriteLine("Conexcion cerrada con el servidor {0}", host);

        }

        public override DataTable obtener_datos(string query)
        {
            DataTable resultado = new DataTable();

            comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = query;
            
            lector = comando.ExecuteReader();

            resultado.Load(lector);

            comando.Dispose();
            lector.Close();
            Console.WriteLine("");
            return resultado;

        }

    }





   
}
