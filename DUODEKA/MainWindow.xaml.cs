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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Bt_Click(object sender, RoutedEventArgs e)
        {
            DateTime datum = (DateTime)Cal_kalender.SelectedDate;
            meetingContext.create(new model.objecten.Meeting(logica.DatabaseTools.generateNewMeetingID(), datum));
        }
    }
}
