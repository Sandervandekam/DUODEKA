using DUODEKA.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUODEKA.logica
{
    public class DatabaseTools
    {
        private static Random rnd = new Random();
        private static MeetingContext meetingContext = new MeetingContext();

        public static int generateNewMeetingID(){
            int id = 1;
            while (meetingContext.read(id) != null) {
                id = rnd.Next(999999999);
            }
            return id;
        }
    }
}
