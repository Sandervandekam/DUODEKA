using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUODEKA.model.objecten
{
    public class Meeting
    {
        #region Properties
        public int Id { get; private set; }
        public DateTime Datum { get; private set; }
        public List<Gebruiker> Gebruikers { get; private set; }

        #endregion

        public Meeting(int id, DateTime datum)
        {
            Id = id;
            Datum = datum;
            Gebruikers = new List<Gebruiker>();
        }
    }
}
