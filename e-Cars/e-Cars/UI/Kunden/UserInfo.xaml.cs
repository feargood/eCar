using e_Cars.Datenbank;
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

namespace e_Cars.UI.Kunden
{
    /// <summary>
    /// Interaktionslogik für UserInfo.xaml
    /// </summary>
    public partial class UserInfo : UserControl
    {

        public Kunde kunde { get; set; }

        public UserInfo(Kunde k)
        {
            this.kunde = k;
            this.DataContext = this;
            InitializeComponent();
        }


        public string FullName
        {
            get
            {
                return kunde.Vorname + " " + kunde.Name;
            }
        }
    
    }
}
