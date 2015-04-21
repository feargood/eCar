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

namespace e_Cars.UI.Reservierung
{
    /// <summary>
    /// Interaktionslogik für ReservierungOverview.xaml
    /// </summary>
    public partial class ReservierungOverview : UserControl
    {
        public MainWindow mw { get; set; }
        public ReservierungOverview(MainWindow mw)
        {
            this.mw = mw;
            InitializeComponent();
        }

        private void ButtonCreateNew_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            mw.setMenu();
        }

        private void myListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        
    }
}
