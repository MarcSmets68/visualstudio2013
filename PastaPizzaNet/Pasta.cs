using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public class Pasta : Gerecht
    {
        public Pasta(string naam,int prijs, string omschrijving = " ")
            :base(naam,prijs)
        {
            this.Omschrijving = omschrijving;
        }
        private string omschrijvingValue;

        public string Omschrijving
        {
            get { return omschrijvingValue; }
            set { omschrijvingValue = value; }
        }
        public override string ToString()
        {
            return base.ToString() + ' ' + Omschrijving + ' ';
        }
        
    }
}
