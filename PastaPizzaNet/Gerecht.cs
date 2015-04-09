using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public abstract class Gerecht 
    {
       
        public Gerecht(string naam,decimal prijs=8m)
        {
            this.Naam = naam;
            this.Prijs = prijs;
        }
        private string naamValue;

        public string Naam
        {
            get { return naamValue; }
            set { naamValue = value; }
        }
        private decimal prijsValue;

        public decimal Prijs
        {
            get { return prijsValue; }
            set { prijsValue = value; }
        }
        public override string ToString()
        {
            
            return "Gerecht :" + Naam + " <" + Prijs + " euro> ";
        }

       
    }
}
