using DUODEKA.database;
using DUODEKA.model.objecten;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUODEKA.logica
{
    public static class MeetingPlanner
    {
        private static Random rnd = new Random();
        private static MeetingContext meetingContext = new MeetingContext();
        private static GebruikerContext gebruikerContext = new GebruikerContext();

        public static int generateNewMeetingID(){
            int id = 1;
            while (meetingContext.read(id) != null) {
                id = rnd.Next(999999999);
            }
            return id;
        }

        public static Meeting vindDatum(DateTime startDatum, int aantalDagen, List<Gebruiker> gebruikers)
        {
            DateTime geselecteerdeDatum = new DateTime();
            DateTime besteDatum = startDatum.AddDays(aantalDagen + 1);
            DateTime index = startDatum;
            int aantalMensenBesteDatum = 1;

            //  Algoritme zoek datum
            //  Datum waarin de meeste mensen geen meeting hebben
            /*
             * ? Tot wanneer moet je zoeken //wanneer iedereen kan of wanneer de meeste mensen kunnen
             * ? Wanneer is een datum niet langer relevant //als er een beter datum is gevonden
             */

            while (DateTime.Compare(startDatum.AddDays(aantalDagen), index) == 1)
            {
                int aantalMensenDatVandaagKan = 0;

                foreach (Gebruiker g in gebruikers)
                {
                    if (!g.Meetings.Contains(new Meeting(index)))
                        aantalMensenDatVandaagKan += 1;
                }

                //  deze dag
                if (aantalMensenDatVandaagKan > aantalMensenBesteDatum)
                {
                    besteDatum = index;
                    aantalMensenBesteDatum = aantalMensenDatVandaagKan;
                }

                //  volgende dag
                index.AddDays(1);
            }

            if (DateTime.Compare(startDatum.AddDays(aantalDagen), besteDatum) == 1)
            {
                return null;
            }
            else
            {
                return new Meeting(generateNewMeetingID(), geselecteerdeDatum);
            }
        }
    }
}
