using e_Cars.Datenbank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Cars.UI.Cars
{
    public class CarInfo
    {

        public CarInfo(Car c)
        {
            // Todo hier noch die daten prüfen
            this.c = c;
            this.s = c.Status;
        }

        public Datenbank.Car c { get; set; }
        public Datenbank.Status s { get; set; }

        public string Seriennummer
        {
            get { return c.Seriennummer; }
            set { c.Seriennummer = value; }
        }

        public string Wartungstermin
        {
            get
            {
                if (c.Wartungstermin.HasValue)
                {
                    return c.Wartungstermin.GetValueOrDefault().ToLongDateString();
                }
                return null;
            }
        }

        public string Kilometer
        {
            get
            {
                if (c.Kilometerstand.HasValue)
                {
                    return c.Kilometerstand.GetValueOrDefault().ToString();
                }
                return null;
            }
        }
        public string Batterieladung
        {
            get
            {
                if (c.Batterieladung.HasValue)
                {
                    return c.Batterieladung.GetValueOrDefault().ToString() + "%";
                }
                return null;
            }
        }

        public string Tankvorgaenge
        {
            get
            {
                return c.Tankvorgaenge + "";
            }
        }

    }
}
