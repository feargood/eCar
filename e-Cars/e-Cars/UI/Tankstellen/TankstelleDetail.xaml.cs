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
    /// Interaktionslogik für TankstelleDetail.xaml
    /// </summary>
    public partial class TankstelleDetail : UserControl
    {

        MainWindow mw { get; set; }

        TankstelleInfo ti { get; set; }


        public TankstelleDetail(MainWindow mw, TankstelleInfo ti)
        {

            this.mw = mw;
            this.ti = ti;

            this.DataContext = this;

            InitializeComponent();
        }

        private void ButtonZurueck_Click(object sender, RoutedEventArgs e)
        {
            mw.setTankstelleOverview();
        }

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

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
