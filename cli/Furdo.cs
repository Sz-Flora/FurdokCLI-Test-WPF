using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrandCLI
{
    public class Furdo
    {
        public string Nev { get; private set; }
        public string Cim { get; private set; }
        public int Ar { get; private set; }
        public int Vizhofok { get; private set; }

        public Furdo(string sor)
        {
            string[] adatok = sor.Split(';');
            this.Nev = adatok[0];
            this.Cim = adatok[1];
            this.Ar = int.Parse(adatok[2]);
            this.Vizhofok = int.Parse(adatok[3]);
        }

        public string IRSZ()
        {
            string[] cim = Cim.Split(" ");
            return cim[0];
        }

        public string Telepules()
        {
            string[] cim = Cim.Split(" ");
            return cim[1].Replace(",", "");
        }
    }
}
