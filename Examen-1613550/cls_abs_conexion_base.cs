using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Examen_1613550
{
    public abstract class cls_abs_conexion_base
    {
        protected string host;
        protected string user;
        protected string password;
        protected string database;
        protected string stringConeccion;

        public abstract void open();

        public abstract void close();

        public abstract DataTable obtener_datos(string query);

    }
}
