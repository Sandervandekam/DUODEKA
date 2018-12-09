using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.objects;

namespace dal.contexts
{
    public class UserContext : domain.interfaces.IUserRepository
    {
        public void create(User entity)
        {
            throw new NotImplementedException();
        }

        public void delete(User enity)
        {
            throw new NotImplementedException();
        }

        public void deleteById(int id)
        {
            throw new NotImplementedException();
        }

        public User read(int id)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnect.getConnection())
                {
                    conn.Open();

                    string query = "";

                    SqlCommand command = new SqlCommand(query, conn);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {


                            }
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public User read(User entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> readAll()
        {
            throw new NotImplementedException();
        }

        public void update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
