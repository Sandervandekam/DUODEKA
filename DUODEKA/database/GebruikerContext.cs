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
                        string query = "Select PersoonID, MeetingID from Persoon where PersoonID = @PersoonID";

                        SqlCommand command = new SqlCommand(query, conn);

                        SqlParameter[] parameters = {
                        new SqlParameter("@PersoonID", id),
                        new SqlParameter("@MeetingID", id)

                    };

                        //  Werkt voor ieder aantal parameters
                        command.Parameters.Add(parameters);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    output = new Gebruiker(Convert.ToInt32(reader["PersoonID"]), Convert.ToInt32(reader["MeetingID"]));
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
            List<Gebruiker> output = new List<Gebruiker>();
            try
            {
                using (SqlConnection conn = DatabaseConnect.GetConnection())
                {
                    conn.Open();

                    string query = "select * from Persoon where MeetingID = @MeetingID";

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlParameter[] parameters = {

                        new SqlParameter("@MeetingID", meeting.id)
                    };

                    //  Werkt voor ieder aantal parameters
                    foreach (SqlParameter p in parameters)
                    {
                        command.Parameters.Add(p);
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                output.Add(new Gebruiker(Convert.ToInt32(reader["PersoonID"]), Convert.ToString(reader["Meeting"])));
                            }
                        }

                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return output;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gebruiker"></param>
        public void update(Gebruiker gebruiker)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnect.GetConnection())
                {
                    string query = "update Persoon set MeetingID = @MeetingID Where PersoonID = @GebruikerID";

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlParameter[] parameters = {
                        new SqlParameter("@GebruikerID", gebruiker.Id),
                        new SqlParameter("@MeetingID", meeting.id)
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
        public void delete(Gebruiker gebruiker)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnect.GetConnection())
                {
                    string query = "delete Persoon where PersoonID = @GebruikerID";

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlParameter[] parameters = {
                        new SqlParameter("@Gebruiker", gebruiker.Id)
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
    }
}
