using e_Cars.Datenbank;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace e_Cars.UI.Cars
{
    /// <summary>
    /// Interaktionslogik für CarsDetails.xaml
    /// </summary>
    public partial class CarDetail : UserControl, INotifyPropertyChanged
    {

        private CarInfo ci { get; set; }
        private MainWindow mw { get; set; }
        
        private string seriennummer;
        public String Seriennummer
        {
            get { return seriennummer; }
            set
            {
                seriennummer = value;
                if (seriennummer != null)
                {
                    seriennummer = seriennummer.Trim();
                }
                NotifyPropertyChanged("Seriennummer");
            }
        }

        private bool gesperrt;

        public bool Gesperrt
        {
            get { return gesperrt; }
            set
            {
                gesperrt = value;
                NotifyPropertyChanged("Gesperrt");
            }
        }

        private bool reservierunggesperrt;

        public bool ReservierungGesperrt
        {
            get { return reservierunggesperrt; }
            set
            {
                reservierunggesperrt = value;
                NotifyPropertyChanged("ReservierungGesperrt");
            }
        }


        private bool spontanenutzunggesperrt;

        public bool SpontaneNutzungGesperrt
        {
            get { return spontanenutzunggesperrt; }
            set
            {
                spontanenutzunggesperrt = value;
                NotifyPropertyChanged("SpontaneNutzungGesperrt");
            }
        }
        

        private DateTime? wartungstermin;
        public DateTime? WartungsTermin
        {
            get { return wartungstermin; }
            set
            {
                wartungstermin = value;
                NotifyPropertyChanged("WartungsTermin");
            }
        }

        private double? kilometerstand;
        public double? Kilometerstand
        {
            get { return kilometerstand; }
            set
            {
                kilometerstand = value;
                NotifyPropertyChanged("Kilometerstand");
            }
        }

        private int tankvorgaenge;
        public int Tankvorgaenge
        {
            get { return tankvorgaenge; }
            set
            {
                tankvorgaenge = value;
                NotifyPropertyChanged("Tankvorgaenge");
            }
        }

        private int batterieladung = 0;
        public int Batterieladung
        {
            get { return batterieladung; }
            set
            {
                batterieladung = value;
                NotifyPropertyChanged("Batterieladung");
            }
        }

        private List<Status> liststatus = new List<Status>();

        public List<Status> listStatus
        {
            get { return liststatus; }
            set
            {
                liststatus = value;
                NotifyPropertyChanged("listStatus");
            }
        }

        private Status selectedstatus;
        public Status selectedStatus
        {
            get { return selectedstatus; }

            set
            {
                if (selectedstatus != value)
                {
                    selectedstatus = value;
                    NotifyPropertyChanged("selectedStatus");
                }
            }
        }

        public CarDetail(MainWindow mw, CarInfo ci)
        {
            this.mw = mw;
            this.ci = ci;
            InitializeComponent();


            Projekt2Entities con = new Projekt2Entities();
            listStatus = con.Status.ToList();
            

            this.DataContext = this;

            if (this.ci != null)
            {
                Seriennummer = ci.c.Seriennummer;
                Gesperrt = ci.c.Gesperrt.GetValueOrDefault(false);
                ReservierungGesperrt = ci.c.ReservierungGesperrt.GetValueOrDefault(false);
                SpontaneNutzungGesperrt = ci.c.SpontaneNutzungGesperrt.GetValueOrDefault(false);

                WartungsTermin = ci.c.Wartungstermin;
                Batterieladung = ci.c.Batterieladung.GetValueOrDefault(0);
                Kilometerstand = ci.c.Kilometerstand;

                Tankvorgaenge = ci.c.Tankvorgaenge;

                selectedStatus = listStatus.SingleOrDefault(s => s.Status_ID == ci.c.Status_ID);

            }
        }

        private void ButtonZurueck_Click(object sender, RoutedEventArgs e)
        {
            mw.setCarOverview();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9.-]+");
            return !regex.IsMatch(text);
        }

        private void TextBoxPasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private void Event_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void ButtonAenderungenSpeichern_Click(object sender, RoutedEventArgs e)
        {

            bool bChanged = false;

            using (Projekt2Entities con = new Projekt2Entities())
            {

                Car c = con.Car.Single(s => s.Car_ID == ci.c.Car_ID);

                // Prüfe ob Seriennummer geändert
                if (bChanged == true
                    || !Equals(ci.c.Seriennummer, Seriennummer)
                    || !Equals(ci.c.Kilometerstand, Kilometerstand)
                    || !Equals(ci.c.Batterieladung, Batterieladung)
                    || !Equals(ci.c.Wartungstermin, WartungsTermin)

                    || !Equals(ci.c.Gesperrt, Gesperrt)
                    || !Equals(ci.c.SpontaneNutzungGesperrt, SpontaneNutzungGesperrt)
                    || !Equals(ci.c.ReservierungGesperrt, ReservierungGesperrt)

                    || !Equals(ci.c.Tankvorgaenge, Tankvorgaenge)

                    || !Equals(ci.c.Status_ID, selectedStatus.Status_ID)


                    )
                {
                    // Wenn ja die Änderungen speichern...
                    c.Seriennummer = Seriennummer;
                    c.Kilometerstand = Kilometerstand;
                    c.Batterieladung = Batterieladung;
                    c.Wartungstermin = WartungsTermin;
                    
                    c.Gesperrt = Gesperrt;
                    c.ReservierungGesperrt = ReservierungGesperrt;
                    c.SpontaneNutzungGesperrt = SpontaneNutzungGesperrt;

                    c.Tankvorgaenge = Tankvorgaenge;

                    c.Status_ID = selectedStatus.Status_ID;

                    con.Entry(c).State = System.Data.Entity.EntityState.Modified;
                    con.SaveChanges();

                    //c.Status_ID = status.Status_ID;

                    ci.c = c;

                    bChanged = true;
                }

            }

            if (bChanged)
            {
                MessageBox.Show("Änderungen gespeichert.");
            }
            else
            {
                MessageBox.Show("Keine Änderungen");
            }

        }

        private void ButtonFahrzeugOrten_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonFahrtenliste_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonReservierung_Click(object sender, RoutedEventArgs e)
        {

        }

      
    }
}
