using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace e_Cars.UI.Map
{
    /// <summary>
    /// Interaktionslogik für GMaps.xaml
    /// </summary>
    public partial class GMaps : UserControl
    {

        String sURL = AppDomain.CurrentDomain.BaseDirectory + "html/GMaps.html";
        private MainWindow mw { get; set; }

        public GMaps(MainWindow mw)
        {
            this.mw = mw;
            InitializeComponent();

            Uri uri = new Uri(sURL);
            
            webBrowser1.Navigate(uri);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            webBrowser1.InvokeScript("newLoc");      
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            webBrowser1.InvokeScript("setMarker");      
        }

        private void webBrowser1_Loaded(object sender, RoutedEventArgs e)
        {

            //dynamic activeX = this.webBrowser1.GetType().InvokeMember("ActiveXInstance",
            //        BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            //        null, this.webBrowser1, new object[] { });

            //activeX.Silent = true;

            ((WebBrowser)sender).ObjectForScripting = new HtmlInteropInternalTestClass();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            mw.setMenu();
        }
    }


    // Object used for communication from JS -> WPF
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public class HtmlInteropInternalTestClass
    {
        //public void endDragMarkerCS(Decimal Lat, Decimal Lng)
        //{
        //    ((MainWindow)Application.Current.MainWindow).tbLocation.Text = Math.Round(Lat, 5) + "," + Math.Round(Lng, 5);
        //}
    }

}
