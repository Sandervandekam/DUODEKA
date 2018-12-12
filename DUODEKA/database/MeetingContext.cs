using DUODEKA.model.objecten;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUODEKA.database
{
    public class MeetingContext
    {
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

        public Meeting read(int id) {
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

        public void update(Meeting meeting) { }
        public void delete(Meeting meeting) { }
        public void deleteById(int id) { }
    }
}
