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
    /// Interaktionslogik für MenuStammdatenVerwalten.xaml
    /// </summary>
    public partial class MenuStammdatenVerwalten : UserControl
    {

        private MainWindow mw { get; set; }
        public MenuStammdatenVerwalten(MainWindow mw)
        {
            this.mw = mw; 
            InitializeComponent();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            mw.setMenu();
        }

        private void ButtonAuto_Click(object sender, RoutedEventArgs e)
        {
            // neues CarOverview setzen
            mw.setCarOverview(true);
        }

        private void ButtonKunde_Click(object sender, RoutedEventArgs e)
        {
            // neues UserOverview setzen
            mw.setUserOverview(true);
        }

        private void ButtonTankstelle_Click(object sender, RoutedEventArgs e)
        {
            mw.setTankstelleOverview(true);
        }

    }
}
