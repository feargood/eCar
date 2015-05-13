using e_Cars.Datenbank;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

namespace e_Cars.UI.Kunden
{
    /// <summary>
    /// Interaktionslogik für UserOverview.xaml
    /// </summary>
    public partial class UserOverview : UserControl, INotifyPropertyChanged
    {
        private MainWindow mw { get; set; }
        public UserOverview(MainWindow mw)
        {
            this.mw = mw;
            this.DataContext = this;
            InitializeComponent();

        }

        private List<UserInfo> listuserinfo = null;
        public List<UserInfo> listUserInfo
        {
            get { return listuserinfo; }
            set
            {
                listuserinfo = value;
                NotifyPropertyChanged("listUserInfo");
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

        private void loadData()
        {
            // Hier die User Daten laden...
            listUserInfo = getListOfUserInfo(null);
        }

        private List<UserInfo> getListOfUserInfo(string filter)
        {

            List<UserInfo> listUserInfo = new List<UserInfo>();
            using (Projekt2Entities con = new Projekt2Entities())
            {
                foreach (Kunde k in con.Kunde)
                {
                    UserInfo ui = new UserInfo(k);
                    listUserInfo.Add(ui);
                }
            }

            return listUserInfo;
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            mw.setMenuStammdatenVerwaltung();
        }

        private void ButtonCreateNew_Click(object sender, RoutedEventArgs e)
        {
            mw.setUserNew();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            loadData();
        }

        private void myListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ((FrameworkElement)e.OriginalSource).DataContext as UserInfo;
            if (item != null)
            {
                    mw.setUserDetail(item);
            }
        }
    }
}
