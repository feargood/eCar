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

namespace e_Cars.UI.Cars
{
    /// <summary>
    /// Interaktionslogik für CarsInfo.xaml
    /// </summary>
    public partial class CarInfo : UserControl
    {
        public Datenbank.Car c { get; set; }
        public Datenbank.Status s { get; set; }

        public CarInfo()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public CarInfo(Datenbank.Car c)
            : this()
        {
            this.c = c;
            this.s = c.Status;
        }

        public string Seriennummer
        {
            get { return c.Seriennummer; }
            set { c.Seriennummer = value; }
        }

        public string Status
        {
            get
            {
                if (s == null)
                {
                    return "Kein Status vorhanden!";
                }
                
                return "Batterie " + s.Baterieladung + "%";
            }
        }

    }
}
