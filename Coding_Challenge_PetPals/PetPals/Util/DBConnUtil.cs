using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Util
{
    internal class DBConnUtil
    {
        static SqlConnection connection = null;
        
        public static SqlConnection GetConnection()
        {
            connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["PetPalsDB"].ConnectionString;
            return connection;
        }
    }
}