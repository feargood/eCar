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

        private double? kmstand;
        public double? KM_Stand
        {
            get { return kmstand; }
            set
            {
                kmstand = value;
                NotifyPropertyChanged("KM_Stand");
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

        public CarDetail(MainWindow mw, CarInfo ci)
        {
            this.mw = mw;
            this.ci = ci;
            InitializeComponent();

            this.DataContext = this;

            if (this.ci != null)
            {
                Seriennummer = ci.c.Seriennummer;
                Gesperrt = ci.c.Gesperrt.GetValueOrDefault(false);
                ReservierungGesperrt = ci.c.ReservierungGesperrt.GetValueOrDefault(false);
                SpontaneNutzungGesperrt = ci.c.SpontaneNutzungGesperrt.GetValueOrDefault(false);

                if (ci.s != null)
                {
                    WartungsTermin = ci.s.Wartungstermin;
                    Batterieladung = ci.s.Baterieladung.GetValueOrDefault();
                    KM_Stand = ci.s.KM_Stand;
                }
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

        private void TextBoxKMStand_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void ButtonAenderungenSpeichern_Click(object sender, RoutedEventArgs e)
        {

            bool bChanged = false;

            using (Projekt2Entities con = new Projekt2Entities())
            {

                Car c = con.Car.Single(s => s.Car_ID == ci.c.Car_ID);

                Status status;
                if (ci.s != null)
                {
                    status = con.Status.Single(s => s.Status_ID == ci.c.Status_ID);
                }
                else
                {
                    status = new Status();
                }

                // Prüfen ob Status änderungen...
                if (ci.s == null
                    || !Equals(ci.s.KM_Stand, KM_Stand)
                    || !Equals(ci.s.Baterieladung, Batterieladung)
                    || !Equals(ci.s.Wartungstermin, WartungsTermin))
                {
                    // Wenn ja die Änderungen speichern...    
                    status.KM_Stand = KM_Stand;
                    status.Baterieladung = Batterieladung;
                    status.Wartungstermin = WartungsTermin;

                    if (status.Status_ID == 0)
                    {
                        con.Status.Add(status);
                        con.SaveChanges();
                    }
                    else
                    {
                        con.Entry(status).State = System.Data.Entity.EntityState.Modified;
                        con.SaveChanges();
                    }

                    ci.s = status;

                    bChanged = true;
                }

                // Prüfe ob Seriennummer geändert
                if (bChanged == true
                    || !Equals(ci.c.Seriennummer, Seriennummer))
                {
                    // Wenn ja die Änderungen speichern...
                    c.Seriennummer = Seriennummer;
                    c.Status_ID = status.Status_ID;

                    con.Entry(c).State = System.Data.Entity.EntityState.Modified;
                    con.SaveChanges();

                    c.Status_ID = status.Status_ID;

                    ci.c = c;

                    bChanged = true;
                }

                 // Prüfe ob Sperrkennzeichen geändert
                if (bChanged == true
                    || !Equals(ci.c.Gesperrt, Gesperrt)
                    || !Equals(ci.c.SpontaneNutzungGesperrt, SpontaneNutzungGesperrt)
                    || !Equals(ci.c.ReservierungGesperrt, ReservierungGesperrt)
                    )
                {
                    c.Gesperrt = Gesperrt;
                    c.ReservierungGesperrt = ReservierungGesperrt;
                    c.SpontaneNutzungGesperrt = SpontaneNutzungGesperrt;

                    con.Entry(c).State = System.Data.Entity.EntityState.Modified;
                    con.SaveChanges();

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
