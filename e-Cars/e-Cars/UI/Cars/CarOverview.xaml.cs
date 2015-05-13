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

namespace e_Cars.UI.Cars
{
    /// <summary>
    /// Interaktionslogik für CarOverview.xaml
    /// </summary>
    public partial class CarOverview : UserControl, INotifyPropertyChanged
    {
        private MainWindow mw { get; set; }
        public CarOverview(MainWindow mw)
        {
            this.mw = mw;
            this.DataContext = this;
            InitializeComponent();
        }

        private List<CarInfo> listcarsinfo = null;
        public List<CarInfo> listCarsInfo
        {
            get
            {
                return listcarsinfo;
            }
            set
            {
                listcarsinfo = value;
                NotifyPropertyChanged("listCarsInfo");
            }
        }

        private void loadData()
        {
            // Hier die Car Daten laden...
            listCarsInfo = getListOfCarsInfo(null);
        }

        private List<CarInfo> getListOfCarsInfo(string filter)
        {
            List<CarInfo> listCarsInfo = new List<CarInfo>();
            using (Projekt2Entities con = new Projekt2Entities())
            {
                foreach (Car c in con.Car)
                {

                    


                    
                    CarInfo ci = new CarInfo(c);
                    listCarsInfo.Add(ci);
                }
            }
            return listCarsInfo;
        }

        private void myListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ((FrameworkElement)e.OriginalSource).DataContext as CarInfo;
            if (item != null)
            {
                mw.setCarDetail(item);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            loadData();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            mw.setMenuStammdatenVerwaltung();
        }

        private void ButtonCreateNew_Click(object sender, RoutedEventArgs e)
        {
            mw.setCarNew();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

    }
}
