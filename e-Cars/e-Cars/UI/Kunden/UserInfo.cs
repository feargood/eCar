using e_Cars.Datenbank;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Cars.UI.Kunden
{
    public class UserInfo
    {
        public Kunde kunde { get; set; }
        public Adresse adress { get; set; }
        public Bank bank { get; set; }

        public UserInfo(Kunde k){
            if (k != null)
            {
                //using (Projekt2Entities con = new Projekt2Entities())
                //{

                //    kunde = con.Kunde.SingleOrDefault(s => s.Kunde_ID == k.Kunde_ID);
                //    adress = kunde.Adresse;
                //    bank = kunde.Bank;
                //}
            }
        }

        public String KundeName
        {
            get { return kunde.Name; }
        }

        public String Vorname
        {
            get { return kunde.Vorname; }
        }

        public String Ort
        {
            get { return adress.Ort; }
        }

        public String PLZ
        {
            get { return adress.PLZ; }
        }

        public String HausNummer
        {
            get { return adress.Hausnummer; }
        }

        public String Strasse
        {
            get { return adress.Strasse; }
        }

        public String BIC
        {
            get { return bank.BIC; }
        }

        public String IBAN
        {
            get { return bank.IBAN; }
        }
    
    }
}
