using e_Cars.Datenbank;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace e_Cars.UI.Tankstellen
{
    /// <summary>
    /// Interaktionslogik für TankstelleNew.xaml
    /// </summary>
    public partial class TankstelleNew : UserControl, INotifyPropertyChanged
    {
        MainWindow mw { get; set; }

        private string state;
        public String State
        {
            get { return state; }
            set
            {
                state = value;
                NotifyPropertyChanged("State");
            }
        }
        private string standort;
        public String Standort
        {
            get { return standort; }
            set
            {
                standort = value;
                NotifyPropertyChanged("Standort");
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public TankstelleNew(MainWindow mw)
        {
            this.mw = mw;
            this.DataContext = this;
            InitializeComponent();
        }

        private void ButtonZurueck_Click(object sender, RoutedEventArgs e)
        {
            mw.setTankstelleOverview();
        }

        private void ButtonAnlegen_Click(object sender, RoutedEventArgs e)
        {

            if (!String.IsNullOrWhiteSpace(State) ||
                !String.IsNullOrWhiteSpace(Standort) ||
                WartungsTermin != null)
            {
                using (Projekt2Entities con = new Projekt2Entities())
                {
                    Tankstelle t = new Tankstelle();
                    
                    
                    con.Tankstelle.Add(t);
                    con.SaveChanges();

                    MessageBox.Show("Tankstelle angelegt");
                }
            }
            else
            {
                MessageBox.Show("Felder nicht gefüllt!");
            }
        }
    }
}
