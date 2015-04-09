using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public class Klant
    {
        private int klantIDValue;
        public Klant(string naam ="Onbekende Klant", int id = 0)
        {
            this.Naam = naam ;
            this.KlantID = id;
        }
        
        public int KlantID
        {
            get { return klantIDValue; }
            set { klantIDValue = value; }
        }
        private string naamValue;

        public string Naam
        {
            get { return naamValue; }
            set { naamValue = value; }
        }
        public override string ToString()
        {
            return "Klant : " + Naam;
        }
        public string SchrijfString()
        {
            return KlantID + "#" + Naam;
        }
        
        
    }
}
