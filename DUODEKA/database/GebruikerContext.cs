using DUODEKA.model.objecten;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUODEKA.database
{
    //  Summaries vullen
    //  Methoden afmaken
    public class GebruikerContext
    {
        public void create(Gebruiker gebruiker)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnect.GetConnection())
                {
                    string query = "insert into Persoon (PersoonID, Naam) values (@PersoonID, @Naam)";

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlParameter[] parameters = {
                        new SqlParameter("@PersoonID", gebruiker.Id),
                        new SqlParameter("@Naam", gebruiker.Naam)
                    };

                    //  Werkt voor ieder aantal parameters
                    command.Parameters.Add(parameters);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw;
            };
        }
        public Gebruiker read(int id)
        {
            {
                Gebruiker output = null;
                try
                {
                    using (SqlConnection conn = DatabaseConnect.GetConnection())
                    {
                        string query = "Select PersoonID, Naam from Persoon where PersoonID = @PersoonID";

                        SqlCommand command = new SqlCommand(query, conn);

                        SqlParameter[] parameters = {
                        new SqlParameter("@PersoonID", id)

                    };

                        //  Werkt voor ieder aantal parameters
                        command.Parameters.Add(parameters);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    output = new Gebruiker(Convert.ToInt32(reader["PersoonID"]), Convert.ToString(reader["Naam"]));
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                };

                return output;

            }
        }

        internal Gebruiker[] readByMeetingID(int id)
        {
            throw new NotImplementedException();
        }

        public void update(Gebruiker gebruiker) { }
        public void delete(Gebruiker gebruiker) { } 
    }
}
