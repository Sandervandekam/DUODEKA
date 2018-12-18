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
    public class MeetingContext
    {
        #region methods

        /// <summary>
        /// Slaat een Meeting op in het database
        /// </summary>
        /// <param name="meeting"></param>
        public void create(Meeting meeting){
            try
            {
                using (SqlConnection conn = DatabaseConnect.GetConnection())
                {
                    string query = "insert into Meeting (MeetingID, Datum) values (@MeetingID, @Datum)";

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlParameter[] parameters = {
                        new SqlParameter("@MeetingID", meeting.Id),
                        new SqlParameter("@Datum", meeting.Datum)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Meeting Read(int id) {
            Meeting output = null;
            try
            {
                using (SqlConnection conn = DatabaseConnect.GetConnection())
                {
                    string query = "Select MeetingID, Datum from Meeting where MeetingID = @MeetingID";

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlParameter[] parameters = {
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
                                output = new Meeting(Convert.ToInt32(reader["MeetingID"]), Convert.ToDateTime(reader["Datum"]));
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<Meeting> readByDate(DateTime date)
        {
            List<Meeting> output = new List<Meeting>();
            try
            {
            using (SqlConnection conn = DatabaseConnect.GetConnection())
            {
                    conn.Open();

                    string query = "select * from Meeting where Datum = @Datum";

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlParameter[] parameters = {
                        
                        new SqlParameter("@Datum", date)
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
                               output.Add(new Meeting(Convert.ToInt32(reader["MeetingID"]), Convert.ToDateTime(reader["Datum"])));
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
        /// <param name="meeting"></param>
        public void update(Meeting meeting) {
            try
            {
                using (SqlConnection conn = DatabaseConnect.GetConnection())
                {
                    string query = "update Meeting set Datum = @Datum where MeetingID = @MeetingID";

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlParameter[] parameters = {
                        new SqlParameter("@MeetingID", meeting.Id),
                        new SqlParameter("@Datum", meeting.Datum)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="meeting"></param>
        public void delete(Meeting meeting) {
            try
            {
                using (SqlConnection conn = DatabaseConnect.GetConnection())
                {
                    string query = "delete Meeting where MeetingID = @MeetingID";

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlParameter[] parameters = {
                        new SqlParameter("@MeetingID", meeting.Id)
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
        
        #endregion
    }
}
