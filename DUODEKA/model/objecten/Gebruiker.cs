using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUODEKA.model.objecten
{
    public class Gebruiker
    {
        public int Id { get; private set; }
        public String Naam { get; private set; }
        public List<Meeting> Meetings { get; private set; }

        public Gebruiker(int id, string naam)
        {
            Id = id;
            Naam = naam;
        }

        public override string ToString()
        {
            return Naam;
        }

        public Gebruiker(int meetingID)
        {
            MeetingID = meetingID;
        }
    }
}
