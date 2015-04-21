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

namespace e_Cars.UI.Kunden
{
    /// <summary>
    /// Interaktionslogik für UserNew.xaml
    /// </summary>
    public partial class UserNew : UserControl, INotifyPropertyChanged
    {

        private MainWindow mw { get; set; }

        private string name;
        public String KundeName
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged("KundeName");
            }
        }

        private string vorname;
        public String Vorname
        {
            get { return vorname; }
            set
            {
                vorname = value;
                NotifyPropertyChanged("Vorname");
            }
        }

        private string ort;
        public String Ort
        {
            get { return ort; }
            set
            {
                ort = value;
                NotifyPropertyChanged("Ort");
            }
        }

        private string plz;
        public String PLZ
        {
            get { return plz; }
            set
            {
                plz = value;
                NotifyPropertyChanged("PLZ");
            }
        }

        private string hausnummer;
        public String HausNummer
        {
            get { return hausnummer; }
            set
            {
                hausnummer = value;
                NotifyPropertyChanged("HausNummer");
            }
        }

        private string strasse;
        public String Strasse
        {
            get { return strasse; }
            set
            {
                strasse = value;
                NotifyPropertyChanged("Strasse");
            }
        }

        private string bic;
        public String BIC
        {
            get { return bic; }
            set
            {
                bic = value;
                NotifyPropertyChanged("BIC");
            }
        }

        private string iban;
        public String IBAN
        {
            get { return iban; }
            set
            {
                iban = value;
                NotifyPropertyChanged("IBAN");
            }
        }

        
        public UserNew(MainWindow mw)
        {
            this.mw = mw;
            this.DataContext = this;
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private void ButtonZurueck_Click(object sender, RoutedEventArgs e)
        {
            mw.setUserOverview();
        }

        private void clearFields()
        {

            KundeName = "";
            Vorname = "";
            PLZ = "";
            Ort = "";
            Strasse = "";
            HausNummer = "";
            BIC = "";
            IBAN = "";

        }


        private bool checkData()
        {

            bool bData = false;

            if (String.IsNullOrWhiteSpace(KundeName))
            {
                bData = true;
            }
            if (String.IsNullOrWhiteSpace(Vorname))
            {
                bData = true;
            }
            if (String.IsNullOrWhiteSpace(PLZ))
            {
                bData = true;
            }
            if (String.IsNullOrWhiteSpace(Ort))
            {
                bData = true;
            }
            if (String.IsNullOrWhiteSpace(Strasse))
            {
                bData = true;
            }
            if (String.IsNullOrWhiteSpace(HausNummer))
            {
                bData = true;
            }
            if (String.IsNullOrWhiteSpace(BIC))
            {
                bData = true;
            }
            if (String.IsNullOrWhiteSpace(IBAN))
            {
                bData = true;
            }

            return bData;

        }

        private void ButtonAnlegen_Click(object sender, RoutedEventArgs e)
        {

            if (checkData())
            {
                MessageBox.Show("Die Daten müssen vollständig sein bevor sie gespeichert werden können.");
                return;
            }

            Kunde k = new Kunde();
            k.Name = KundeName;
            k.Vorname = Vorname;
      
            Adresse a = new Adresse();
            a.Ort = Ort;
            a.PLZ = PLZ;
            a.Strasse = Strasse;
            a.Hausnummer = HausNummer;

            Bank b = new Bank();
            b.BIC = BIC;
            b.IBAN = IBAN;

            using (var con = new Projekt2Entities())
            {

                con.Adresse.Add(a);
                con.Bank.Add(b);
                con.SaveChanges();

                k.Bank_ID = b.Bank_ID;
                k.Adress_ID = a.Adress_ID;

                con.Kunde.Add(k);
                con.SaveChanges();

            }

            clearFields();

        }
    }
}
