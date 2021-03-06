﻿using e_Cars.Datenbank;
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
    /// Interaktionslogik für CarNew.xaml
    /// </summary>
    public partial class CarNew : UserControl, INotifyPropertyChanged
    {

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

        private MainWindow mw { get; set; }

        public CarNew(MainWindow mw)
        {
            this.mw = mw;
            InitializeComponent();
            this.DataContext = this;

            Projekt2Entities con = new Projekt2Entities();
            listStatus = con.Status.ToList();

            clearFields();

        }

        private void ButtonZurueck_Click(object sender, RoutedEventArgs e)
        {
            mw.setCarOverview();
        }


        private void ButtonAnlegen_Click(object sender, RoutedEventArgs e)
        {

            if (String.IsNullOrWhiteSpace(Seriennummer))
            {
                MessageBox.Show("Keine Seriennummer erfasst!");
                TextBoxSeriennummer.Focus();
                return;
            }

            if (checkData())
            {
                MessageBox.Show("Die Daten sind nicht richtig!");
                return;
            }

            Car c = new Car();
            c.Seriennummer = TextBoxSeriennummer.Text.Trim();

            using (Projekt2Entities con = new Projekt2Entities())
            {
                if (con.Car.Any(s => s.Seriennummer == c.Seriennummer))
                {
                    MessageBox.Show("Seriennummer bereits vergeben!");
                    TextBoxSeriennummer.Focus();
                    return;
                }

                c.Batterieladung = Batterieladung;
                c.Kilometerstand = Kilometerstand;
                c.Status_ID = selectedStatus.Status_ID;
                c.Tankvorgaenge = Tankvorgaenge;
                c.Wartungstermin = WartungsTermin;

                con.Car.Add(c);
                con.SaveChanges();
                MessageBox.Show("Das Fehrzeug wurde angelegt!");
                clearFields();
            }
        }

        private bool checkData()
        {

            bool bData = false;

            if  (String.IsNullOrWhiteSpace(Seriennummer))
            {
                bData = true;
            }

            if (WartungsTermin == null)
            {
                bData = true;
            }

            if (Batterieladung < 0 || Batterieladung > 100)
            {
                bData = true;
            }

            if (Kilometerstand == null)
            {
                bData = true;
            }

            if (selectedStatus == null)
            {
                bData = true;
            }
            
            return bData;
        }

        private void clearFields()
        {
            Seriennummer = null;
            WartungsTermin = null;
            Batterieladung = 0;
            Tankvorgaenge = 0;
            selectedStatus = null;
            Kilometerstand = null;

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

       
    }
}
