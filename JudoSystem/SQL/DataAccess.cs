using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JudoSystem.Models
{
    public class DataAccess
    {
        public static string ConnectionString { get; set; }

        public DataAccess(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public DataAccess()
        {
        }

        //public static DataAccess getConnection()
        //{
        //   // return new MySqlConnection(ConnectionString);
        //}
    }
}
