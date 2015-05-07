using e_Cars.UI.Cars;
using e_Cars.UI.Kunden;
using e_Cars.UI.Map;
using e_Cars.UI.Reservierung;
using e_Cars.UI.Tankstellen;
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
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private CarOverview co { get; set; }
        private UserOverview uo { get; set; }
        private TankstelleOverview to { get; set; }
        private ReservierungOverview ro { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            setMenu();
        }

        internal void setMenu()
        {
            MainGrid.Children.Clear();
            Menu m = new Menu(this);
            MainGrid.Children.Add(m);
        }

        internal void setMenuStammdatenVerwaltung()
        {
            MainGrid.Children.Clear();
            MenuStammdatenVerwalten msv = new MenuStammdatenVerwalten(this);
            MainGrid.Children.Add(msv);
        }

        internal void setCarOverview(bool reset = false)
        {
            MainGrid.Children.Clear();

            if (reset == true)
            {
                this.co = null;
            }

            if (this.co == null)
            {
                this.co = new CarOverview(this);
            }

            MainGrid.Children.Add(co);
        }

        internal void setCarNew()
        {
            MainGrid.Children.Clear();
            CarNew cn = new CarNew(this);
            MainGrid.Children.Add(cn);
        }

        internal void setCarDetail(CarInfo ci)
        {
            MainGrid.Children.Clear();
            CarDetail cd = new CarDetail(this, ci);
            MainGrid.Children.Add(cd);
        }

        internal void setUserOverview(bool reset = false)
        {
            MainGrid.Children.Clear();
            if (reset == true)
            {
                this.uo = null;
            }
            if (this.uo == null)
            {
                this.uo = new UserOverview(this);
            }
            MainGrid.Children.Add(uo);
        }

        internal void setUserNew()
        {
            MainGrid.Children.Clear();
            UserNew un = new UserNew(this);
            MainGrid.Children.Add(un);
        }

        internal void setUserDetail(UserInfo ui)
        {
            MainGrid.Children.Clear();
            UserDetail ud = new UserDetail(this, ui);
            MainGrid.Children.Add(ud);
        }

        internal void setTankstelleOverview(bool reset = false)
        {
            MainGrid.Children.Clear();
            if (reset == true)
            {
                this.to = null;
            }
            if (this.to == null)
            {
                this.to = new TankstelleOverview(this);
            }
            MainGrid.Children.Add(to);
        }

        internal void setTankstelleNew()
        {
            MainGrid.Children.Clear();
            TankstelleNew tn = new TankstelleNew(this);
            MainGrid.Children.Add(tn);
        }

        internal void setTankstelleDetail(TankstelleInfo item)
        {
            MainGrid.Children.Clear();
            TankstelleDetail td = new TankstelleDetail(this, item);
            MainGrid.Children.Add(td);
        }

        internal void setGMaps()
        {
            MainGrid.Children.Clear();
            GMaps map = new GMaps(this);
            MainGrid.Children.Add(map);
        }

        internal void setReservierungOverview(bool reset = false)
        {
            MainGrid.Children.Clear();
            if (reset == true)
            {
                this.ro = null;
            }
            if (this.ro == null)
            {
                this.ro = new ReservierungOverview(this);
            }
            MainGrid.Children.Add(ro);
        }
    }
}
