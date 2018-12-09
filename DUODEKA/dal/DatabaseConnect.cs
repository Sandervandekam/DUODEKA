using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal
{
    public class DatabaseConnect
    {
        const string connectionstring = @"Data Source=LAPTOP-VEQDN5L3\SQLEXPRESS;Initial Catalog=DUODEKA;Integrated Security=True";
        public static SqlConnection getConnection() {
            return new SqlConnection(connectionstring);
        }
    }
}
