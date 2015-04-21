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

namespace e_Cars
{
    /// <summary>
    /// Interaktionslogik für Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {

        private MainWindow mw { get; set; }

        public Menu(MainWindow mw)
        {
            this.mw = mw;
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mw.setGMaps();
        }

        private void Button_Stammdatenverwalten_Click(object sender, RoutedEventArgs e)
        {
            mw.setMenuStammdatenVerwaltung();
        }

        private void Button_Reservierung_Click(object sender, RoutedEventArgs e)
        {
            mw.setReservierungOverview();
        }
    }
}
