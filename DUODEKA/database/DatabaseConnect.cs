            using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUODEKA.database
{
    public class DatabaseConnect
    {
        //  TODO: fix connectionString
        const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False; Integrated Security = True";
        public static SqlConnection GetConnection() {
            return new SqlConnection(ConnectionString);
        }
    }
}
