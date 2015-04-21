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
    /// Interaktionslogik für TankstellenOverview.xaml
    /// </summary>
    public partial class TankstelleOverview : UserControl, INotifyPropertyChanged
    {

        private MainWindow mw { get; set; }


        private List<TankstelleInfo> listtankstelleinfo = null;


        public List<TankstelleInfo> listTankstelleInfo
        {
            get { return listtankstelleinfo; }
            set
            {
                listtankstelleinfo = value;
                NotifyPropertyChanged("listTankstelleInfo");
            }
        }


        public TankstelleOverview(MainWindow mw)
        {
            this.mw = mw;
            this.DataContext = this;
            InitializeComponent();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            mw.setMenuStammdatenVerwaltung();
        }

        private void ButtonCreateNew_Click(object sender, RoutedEventArgs e)
        {
            mw.setTankstelleNew();
        }

        private List<TankstelleInfo> getListOfTankstelleInfo(string filter)
        {
            List<TankstelleInfo> listTankstelleInfo = new List<TankstelleInfo>();
            using (Projekt2Entities con = new Projekt2Entities())
            {
                foreach (Tankstelle t in con.Tankstelle)
                {
                    TankstelleInfo ti = new TankstelleInfo(t);
                    listTankstelleInfo.Add(ti);
                }
            }
            return listTankstelleInfo;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            listTankstelleInfo = getListOfTankstelleInfo(null);
        }

        private void myListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ((FrameworkElement)e.OriginalSource).DataContext as TankstelleInfo;
            if (item != null)
            {
                mw.setTankstelleDetail(item);
            }
        }

    }


}
