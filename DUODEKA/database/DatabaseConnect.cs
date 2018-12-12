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
        const string ConnectionString = @"Data Source = LAPTOP - VEQDN5L3\SQLEXPRESS;Initial Catalog = DUODEKA; Integrated Security = True";
        public static SqlConnection GetConnection() {
            return new SqlConnection(ConnectionString);
        }
    }
}
