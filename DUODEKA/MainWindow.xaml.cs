using DUODEKA.model.objecten;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DUODEKA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        database.MeetingContext meetingContext = new database.MeetingContext();
        database.GebruikerContext gebruikerContext = new database.GebruikerContext();
        private DateTime selectedDate;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Bt_Click(object sender, RoutedEventArgs e)
        {
            //  Variabelen voor het algoritme
            DateTime startDatum = (DateTime)Cal_kalender.SelectedDate;
            int aantalDagen = 14;
            List<Gebruiker> gebruikers = new List<Gebruiker>();

            //  vind een datum en maak daar een meeting voor
            Meeting gevondenMeeting = logica.MeetingPlanner.vindDatum(startDatum, aantalDagen, gebruikers);

            // sla de meeting op
            meetingContext.create(gevondenMeeting);

            //  update tabellen
            updateMeetings(gevondenMeeting.Datum);
        }

        private void updateMeetings(DateTime date) {
            if (!date.Equals(selectedDate))
                Cal_kalender.SelectedDate = date;
            try
            {
                Meeting[] meetings = meetingContext.readByDate(date).ToArray();
                LbBeschikbarePersonen.Items.Clear();
                LbBeschikbarePersonen.Items.Add(meetings);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cal_kalender_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedDate = (DateTime)Cal_kalender.SelectedDate;
            updateMeetings(selectedDate);
        }

        private void LbBeschikbarePersonen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Meeting geselecteerdeMeeting = (Meeting) LbBeschikbarePersonen.SelectedItem;
            Gebruiker[] gebruikers = gebruikerContext.readByMeetingID(geselecteerdeMeeting.Id);
            LbIngeplandePersonen.Items.Clear();
            LbIngeplandePersonen.Items.Add(gebruikers);
        }
    }
}
