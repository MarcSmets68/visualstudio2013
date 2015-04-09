using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public class Pizza : Gerecht
    {
        public Pizza(string naam, List<String> onderdelen, decimal prijs=8m)
            :base(naam,prijs)
        {
            this.Onderdelen = onderdelen;
        }
        private List<String> onderdelenValue;

        public List<String> Onderdelen
        {
            get { return onderdelenValue; }
            set { onderdelenValue = value; }
        }
        public override string ToString()
        {
            StringBuilder tekst = new StringBuilder(base.ToString());
            if (Onderdelen != null)
            {
                foreach (var onderdeel in Onderdelen)
                {
                    if (Onderdelen.IndexOf(onderdeel) == Onderdelen.Count - 1)
                    {
                        tekst.Append(onderdeel + ' ');
                    }
                    else
                    {
                        tekst.Append(onderdeel + " - ");
                    }
                }
               
            }
            return tekst.ToString();
                
            

        }
        
    }
}
