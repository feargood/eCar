using e_Cars.Datenbank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Cars.UI.Tankstellen
{
    public class TankstelleInfo
    {

        public Tankstelle tankstelle { get; set; }
        public TankstelleInfo(Tankstelle t)
        {
            this.tankstelle = t;
        }

        public string Wartungsdatum
        {
            get
            {
                return null;
            }
        }

        public string Standort
        {
            get
            {
                return null;
            }
        }

        public int ID
        {
            get
            {
                return tankstelle.Tankstelle_ID;
            }
        }

    }
}
