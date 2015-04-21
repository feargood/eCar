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
    /// Interaktionslogik für UserDetail.xaml
    /// </summary>
    public partial class UserDetail : UserControl
    {

        public MainWindow mw { get; set; }
        public UserInfo ui { get; set; }
        private Kunde k { get; set; }
        private Adresse a { get; set; }
        private Bank b { get; set; }

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

        private bool gesperrt;

        public bool Gesperrt
        {
            get { return gesperrt; }
            set
            {
                gesperrt = value;
                NotifyPropertyChanged("Gesperrt");
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public UserDetail(MainWindow mw, UserInfo ui)
        {

            this.mw = mw;
            this.ui = ui;

            if (ui != null)
            {
                using (Projekt2Entities con = new Projekt2Entities())
                {

                    k = con.Kunde.SingleOrDefault(s => s.Kunde_ID == ui.kunde.Kunde_ID);
                    a = k.Adresse;
                    b = k.Bank;

                    KundeName = k.Name;
                    Vorname = k.Vorname;
                    Gesperrt = k.Gesperrt;

                    if (a != null)
                    {
                        Strasse = a.Strasse;
                        HausNummer = a.Hausnummer;
                        Ort = a.Ort;
                        PLZ = a.PLZ;
                    }
                    else
                    {
                        Strasse = "";
                        HausNummer = "";
                        Ort = "";
                        PLZ = "";
                    }

                    if (b != null)
                    {
                        BIC = b.BIC;
                        IBAN = b.IBAN;
                    }
                    else
                    {
                        BIC = "";
                        IBAN = "";
                    }
                }
            }

            this.DataContext = this;
            InitializeComponent();

        }

        private void ButtonZurueck_Click(object sender, RoutedEventArgs e)
        {
            mw.setUserOverview();
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

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {

            if (checkData())
            {
                MessageBox.Show("Die Daten müssen vollständig sein bevor die Änderungen gespeichert werden können.");
                return;
            }

            using (Projekt2Entities con = new Projekt2Entities())
            {

                Kunde knew = con.Kunde.Single(s => s.Kunde_ID == k.Kunde_ID);

                Adresse anew = con.Adresse.SingleOrDefault(s => s.Adress_ID == knew.Adress_ID);
                if (anew == null)
                {
                    anew = new Adresse();
                    anew.Hausnummer = HausNummer;
                    anew.Ort = Ort;
                    anew.PLZ = PLZ;
                    anew.Strasse = Strasse;

                    con.Adresse.Add(anew);
                    con.SaveChanges();
                }

                anew.Hausnummer = HausNummer;
                anew.Ort = Ort;
                anew.PLZ = PLZ;
                anew.Strasse = Strasse;

                con.Entry(anew).State = System.Data.Entity.EntityState.Modified;

                Bank bnew = con.Bank.SingleOrDefault(s => s.Bank_ID == knew.Bank_ID);
                if (bnew == null)
                {
                    bnew = new Bank();
                    bnew.BIC = BIC;
                    bnew.IBAN = IBAN;

                    con.Bank.Add(bnew);
                    con.SaveChanges();
                }

                bnew.BIC = BIC;
                bnew.IBAN = IBAN;

                con.Entry(bnew).State = System.Data.Entity.EntityState.Modified;
                knew.Adress_ID = anew.Adress_ID;
                knew.Bank_ID = bnew.Bank_ID;
                knew.Name = KundeName;
                knew.Vorname = Vorname;
                knew.Gesperrt = Gesperrt;

                con.Entry(knew).State = System.Data.Entity.EntityState.Modified;
                con.SaveChanges();

                MessageBox.Show("Änderungen gespeichert!");
            }
        }

    }
}
