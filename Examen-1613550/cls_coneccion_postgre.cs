using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;
using NpgsqlTypes;


namespace Examen_1613550
{
    class cls_coneccion_postgre : cls_abs_conexion_base
    {
        NpgsqlCommand comando;
        NpgsqlConnection conn= new NpgsqlConnection();
        NpgsqlDataReader dt;
        public cls_coneccion_postgre(string host, string user, string password, string database)
        {

            this.host = host;
            this.user = user;
            this.password = password;
            this.database = database;

            stringConeccion = string.Format("Host={0};Username={1};Password={2};Database={3}", host,user ,password , database);

            conn.ConnectionString = stringConeccion;

        }

        public override void open()
        {
            try
            {
                conn.Open();
                Console.WriteLine("*************************************************");
                Console.WriteLine("         SEGUNDA APERTURA DE CONECCION A POSTGRE ");
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
            conn.Close();
            Console.WriteLine("");
            Console.WriteLine("Conexcion cerrada con el servidor {0}", host);
        }

        public override DataTable obtener_datos(string query)
        {
            DataTable resultado = new DataTable();

            comando = new NpgsqlCommand();

            comando.Connection = conn;
            comando.CommandText = query;

            dt = comando.ExecuteReader();

            resultado.Load(dt);

            comando.Dispose();
            dt.Close();
            close();
            return resultado;
        }


    }
}
